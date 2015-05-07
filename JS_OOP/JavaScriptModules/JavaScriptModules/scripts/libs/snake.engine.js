var snakeEngine = (function () {
    // Private
    function checkIfOnFood(food, head) {
        if (food.x === head.x && food.y === head.y) {
            return true;
        }
        else {
            return false;
        }
    }

    function generateFood(food) {
        food.x = Math.round(Math.random()
            * ((gameConfig.FIELD_WIDTH / gameConfig.CELL_SIZE) - 1));

        food.y = Math.round(Math.random()
            * ((gameConfig.FIELD_HEIGHT / gameConfig.CELL_SIZE) - 1));
    }

    // Public
    function move(snake, food) {
        var tail;

        if (checkIfOnFood(food, snake.head)) {
            // If on food create new head and don't touch the tail
            tail = {
                x: snake.head.x,
                y: snake.head.y
            };

            generateFood(food);
        }
        else {
            // Put the tail infront of the old head
            tail = snake.components.pop();
            tail.x = snake.head.x;
            tail.y = snake.head.y;
        }

        snake.components.unshift(tail);
    }

    function getNewHeadPosition(snake) {
        if (snake.direction === gameConfig.LEFT_DIRECTION) {
            snake.head.x--;
        }
        else if (snake.direction === gameConfig.UP_DIRECTION) {
            snake.head.y--;
        }
        else if (snake.direction === gameConfig.RIGHT_DIRECTION) {
            snake.head.x++;
        }
        else if (snake.direction === gameConfig.DOWN_DIRECTION) {
            snake.head.y++;
        }
    }

    function checkIfCollided(snake) {
        var current,
            i;

        if (snake.head.x < 0 || gameConfig.FIELD_WIDTH / gameConfig.CELL_SIZE <= snake.head.x
                || snake.head.y < 0 || gameConfig.FIELD_HEIGHT / gameConfig.CELL_SIZE <= snake.head.y) {
            return true;
        }

        for (i = 0; i < snake.components.length; i++) {
            current = snake.components[i];

            if (current.x === snake.head.x && current.y === snake.head.y) {
                return true;
            }
        }

        return false;
    }

    return {
        move: move,
        getNewHeadPosition: getNewHeadPosition,
        checkIfCollided: checkIfCollided
    };
}());