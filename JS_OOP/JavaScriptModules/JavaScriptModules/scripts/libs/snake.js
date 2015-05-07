var Snake = (function () {
    function Snake() {
        this.components = [];
        this.direction = gameConfig.RIGHT_DIRECTION;

        for (var i = gameConfig.SNAKE_INITIAL_LENGTH - 1; i >= 0 ; i--) {
            this.components.push({
                x: i,
                y: 0
            });
        }

        this.head = {
            x: this.components[0].x,
            y: this.components[0].y
        };
    }

    return Snake;
}());