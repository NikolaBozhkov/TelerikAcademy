/// <reference path="raphael-min.js" />
/// <reference path="kinetic-v5.1.0.min.js" />
window.onload = function () {
    document.getElementById('svg-container').style.position = 'absolute';
    document.getElementById('canvas-container').style.position = 'absolute';

    var paper = Raphael('svg-container', 1280, 800);

    var canvas = document.createElement("canvas");
    var ctx = canvas.getContext('2d');
    canvas.width = 1280;
    canvas.height = 800;
    document.getElementById('canvas-container').appendChild(canvas);

    var createPosition = function (x, y) {
        return {
            x: x,
            y: y
        }
    };

    // Speed should be given as speed per second in pixels(P/S)
    var createInteractive = function (position, speed) {
        return {
            position: position,
            speed: speed,
            imageReady: false,
            image: new Image()
        }
    };

    // Handle keyboard controls
    var keysDown = {};

    addEventListener("keydown", function (e) {
        keysDown[e.keyCode] = true;
    }, false);

    addEventListener("keyup", function (e) {
        delete keysDown[e.keyCode];
    }, false);

    var moveObject = function (interactive, canvas, ctx, modifier) {
        if (37 in keysDown && interactive.position.x > 0) { // Player holding left
            if (scaled) {
                ctx.scale(-1, 1);
                scaled = false;
            }

            interactive.position.x -= interactive.speed * modifier;
        }
        if (39 in keysDown && interactive.position.x < canvas.width) { // Player holding right
            if (!scaled) {
                ctx.scale(-1, 1);
                scaled = true;
            }

            interactive.position.x += interactive.speed * modifier;
        }
    };
    
    var renderObject = function (interactive, ctx) {
        if (interactive.imageReady) {
            if (scaled) {
                ctx.clearRect(0, 0, -1280, 800);
                ctx.drawImage(interactive.image, -interactive.position.x, interactive.position.y);
            }
            else {
                ctx.clearRect(0, 0, 1280, 800);
                ctx.drawImage(interactive.image, interactive.position.x, interactive.position.y);
            }
        }
    };

    var then = Date.now(); // Then stands for the time it was before the next call of the function
    var run = function (interactive, canvas, ctx) {
        var now = Date.now();
        var delta = now - then; // Our modifier to ensure constant speed

        moveObject(interactive, canvas, ctx, delta / 1000);
        renderObject(interactive, ctx);

        then = now;
        requestAnimationFrame(function () {
            run(interactive, canvas, ctx);
        });
    };

    // Our mario
    var scaled = false;
    var position = createPosition(canvas.width / 2, canvas.height - 190);
    var mario = createInteractive(position, 512);

    // Loading the image of mario
    mario.image.onload = function () {
        mario.imageReady = true;
    }
    mario.image.src = "../images/super-mario-walk.png";

    paper.image("../images/super-mario-background.png", 0, 0, 1280, 800);

    run(mario, canvas, ctx);
};