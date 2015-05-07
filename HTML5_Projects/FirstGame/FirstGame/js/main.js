// Create canvas
var canvas = document.createElement("canvas");
var ctx = canvas.getContext("2d");
canvas.width = 512;
canvas.height = 480;
document.body.querySelector(".canvasHolder").appendChild(canvas);

// Images
var bgReady = false;
var bgImage = new Image();
bgImage.src = "../images/background.png";
bgImage.onload = function () {
    bgReady = true;
};

var heroReady = false;
var heroImage = new Image();
heroImage.src = "../images/hero.png";
heroImage.onload = function () {
    heroReady = true;
};

var monsterReady = false;
var monsterImage = new Image();
monsterImage.src = "../images/monster.png";
monsterImage.onload = function () {
    monsterReady = true;
};

// Game objects
function createLivingBeing(x, y) {
    var livingBeing = {
        x: x,
        y: y
    };

    return livingBeing;
}

function createHero(x, y, speed) {
    var hero = createLivingBeing(x, y);
    hero.speed = speed; // pixels per second
    return hero;
}

var hero = createHero(0, 0, 256);
var monster = createLivingBeing(0, 0);
var monstersCaught = 0;

// Handle keyboard controls
var keysDown = {};

addEventListener("keydown", function (e) {
    keysDown[e.keyCode] = true;
}, false);

addEventListener("keyup", function (e) {
    delete keysDown[e.keyCode];
}, false);

// Caught monster
var reset = function (start) {
    if (start) {
        hero.x = canvas.width / 2;
        hero.y = canvas.height / 2;
    }

    // Throw the monster somewhere on the screen randomly
    monster.x = 32 + Math.random() * (canvas.width - 96);
    monster.y = 32 + Math.random() * (canvas.height - 96);
}

// Update game objects
var update = function (modifier) {
    if (38 in keysDown && hero.y > 32) {
        hero.y -= hero.speed * modifier;
    }
    
    if (40 in keysDown && hero.y < canvas.height - 64) {
        hero.y += hero.speed * modifier;
    }

    if (37 in keysDown && hero.x > 32) {
        hero.x -= hero.speed * modifier;
    }

    if (39 in keysDown && hero.x <= canvas.width - 64) {
        hero.x += hero.speed * modifier;
    }

    if (hero.x <= (monster.x + 32)
            && monster.x <= (hero.x + 32)
            && hero.y <= (monster.y + 32)
            && monster.y <= (hero.y + 32)) {
        monstersCaught++;
        reset();
    }
};

// Render objects
var render = function () {
    if (bgReady) {
        ctx.drawImage(bgImage, 0, 0);
    }

    if (heroReady) {
        ctx.drawImage(heroImage, hero.x, hero.y);
    }

    if (monsterReady) {
        ctx.drawImage(monsterImage, monster.x, monster.y);
    }

    // Score
    ctx.fillStyle = "#000";
    ctx.font = "24px Consolas";
    ctx.textAlign = "left";
    ctx.textBaseline = "top";
    ctx.fillText("Monsters caught: " + monstersCaught, 32, 32);
};

// Main game loop
var main = function () {
    var now = Date.now();
    var delta = now - then;

    update(delta / 1000);
    render();

    then = now;

    // Cross-browser support for requestAnimationFrame
    var w = window;
    requestAnimationFrame = w.requestAnimationFrame || w.webkitRequestAnimationFrame || w.msRequestAnimationFrame || w.mozRequestAnimationFrame;
    requestAnimationFrame(main);
};

// Start the game
var then = Date.now();
reset(true);
main();
