var gameConfig = (function () {
    return Object.freeze({
        CELL_SIZE: 10,
        FOOD_POINTS: 10,
        FIELD_WIDTH: 640,
        FIELD_HEIGHT: 480,
        GAMEOVER_SCREEN_WIDTH: 150,
        GAMEOVER_SCREEN_HEIGHT: 100,

        SNAKE_INITIAL_LENGTH: 5,
        LEFT_ARROW_KEY_NUMBER: 37,
        UP_ARROW_KEY_NUMBER: 38,
        RIGHT_ARROW_KEY_NUMBER: 39,
        DOWN_ARROW_KEY_NUMBER: 40,

        UP_DIRECTION: 'up',
        DOWN_DIRECTION: 'down',
        LEFT_DIRECTION: 'left',
        RIGHT_DIRECTION: 'right'
    });
}());