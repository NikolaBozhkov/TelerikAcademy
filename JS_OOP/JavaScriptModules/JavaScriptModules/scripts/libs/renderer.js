var renderer = (function () {
    // Private
    function drawCell(x, y, color, ctx) {
        ctx.fillStyle = color;
        ctx.fillRect(x * gameConfig.CELL_SIZE, y * gameConfig.CELL_SIZE,
                     gameConfig.CELL_SIZE, gameConfig.CELL_SIZE);

        ctx.strokeStyle = "#fff";
        ctx.strokeRect(x * gameConfig.CELL_SIZE, y * gameConfig.CELL_SIZE,
                       gameConfig.CELL_SIZE, gameConfig.CELL_SIZE);
    };

    function renderSnake(snake, ctx) {
        var current,
            i;

        for (i = 0; i < snake.components.length; i++) {
            current = snake.components[i];
            drawCell(current.x, current.y, '#000', ctx);
        }
    }

    function renderFood(food, ctx) {
        drawCell(food.x, food.y, '#555', ctx);
    }

    function renderScore(snake, ctx) {
        var textWidth,
            score = (snake.components.length * gameConfig.FOOD_POINTS) - (gameConfig.SNAKE_INITIAL_LENGTH * gameConfig.FOOD_POINTS),
            text = "Score: " + score;

        ctx.fillStyle = "#000";
        ctx.font = "bold 15px Consolas";
        textWidth = ctx.measureText(text);
        ctx.fillText(text, gameConfig.FIELD_WIDTH - textWidth.width - 5, 15);
    }

    // Public
    function renderAll(snake, food, ctx) {
        renderSnake(snake, ctx);
        renderFood(food, ctx);
        renderScore(snake, ctx);
    }

    function clearField(ctx) {
        ctx.fillStyle = "#fff";
        ctx.strokeStyle = "#000";
        ctx.fillRect(0, 0, gameConfig.FIELD_WIDTH, gameConfig.FIELD_HEIGHT);
        ctx.strokeRect(0, 0, gameConfig.FIELD_WIDTH, gameConfig.FIELD_HEIGHT);
    }

    function showEndGameScreen(snake, ctx) {
        var GAMEOVER_SCREEN_X = (gameConfig.FIELD_WIDTH - gameConfig.GAMEOVER_SCREEN_WIDTH) / 2,
            GAMEOVER_SCREEN_Y = (gameConfig.FIELD_HEIGHT - gameConfig.GAMEOVER_SCREEN_HEIGHT) / 2;

        ctx.fillStyle = "#000";
        ctx.fillRect(GAMEOVER_SCREEN_X, GAMEOVER_SCREEN_Y,
            gameConfig.GAMEOVER_SCREEN_WIDTH, gameConfig.GAMEOVER_SCREEN_HEIGHT);

        ctx.fillStyle = "#fff";
        ctx.font = "20px solid Consolas";
        ctx.fillText("GAME OVER", GAMEOVER_SCREEN_X + 15, GAMEOVER_SCREEN_Y + (gameConfig.GAMEOVER_SCREEN_HEIGHT / 2));
    }

    return {
        renderAll: renderAll,
        clearField: clearField,
        showEndGameScreen: showEndGameScreen
    };
}());