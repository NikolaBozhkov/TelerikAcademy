var gameEngine = (function () {
    // Private
    var canvas,
        ctx,
        loop;

    var snake,
        food,
        currentKeyCode = gameConfig.RIGHT_ARROW_KEY_NUMBER;

    canvas = document.createElement('canvas');
    canvas.width = gameConfig.FIELD_WIDTH;
    canvas.height = gameConfig.FIELD_HEIGHT;
    canvas.style.border = '15px solid black';
    ctx = canvas.getContext('2d');
    document.getElementById('canvas-container').appendChild(canvas);

    window.addEventListener("keydown", function (e) {
        currentKeyCode = e.keyCode;
    });

    function changeDirection() {
        if (gameConfig.RIGHT_ARROW_KEY_NUMBER === currentKeyCode
                && snake.direction !== gameConfig.LEFT_DIRECTION) {
            snake.direction = gameConfig.RIGHT_DIRECTION;
        }
        else if (gameConfig.DOWN_ARROW_KEY_NUMBER === currentKeyCode
                && snake.direction !== gameConfig.UP_DIRECTION) {
            snake.direction = gameConfig.DOWN_DIRECTION;
        }
        else if (gameConfig.LEFT_ARROW_KEY_NUMBER === currentKeyCode
                && snake.direction !== gameConfig.RIGHT_DIRECTION) {
            snake.direction = gameConfig.LEFT_DIRECTION;
        }
        else if (gameConfig.UP_ARROW_KEY_NUMBER === currentKeyCode
                && snake.direction !== gameConfig.DOWN_DIRECTION) {
            snake.direction = gameConfig.UP_DIRECTION;
        }
    }

    function update() {
        changeDirection();
        snakeEngine.getNewHeadPosition(snake);

        if (snakeEngine.checkIfCollided(snake)) {
            renderer.showEndGameScreen(snake, ctx);
            clearInterval(loop);
            return;
        }

        snakeEngine.move(snake, food);
        renderer.clearField(ctx);
        renderer.renderAll(snake, food, ctx);
    }

    // Public
    function start() {
        snake = new Snake();
        food = {
            x: Math.round(Math.random()
                * ((gameConfig.FIELD_WIDTH / gameConfig.CELL_SIZE) - 1)),
            y: Math.round(Math.random()
                * ((gameConfig.FIELD_HEIGHT / gameConfig.CELL_SIZE) - 1))
        };

        renderer.renderAll(snake, food, ctx);

        loop = setInterval(update, 100);
    }

    return {
        start: start
    };
}());