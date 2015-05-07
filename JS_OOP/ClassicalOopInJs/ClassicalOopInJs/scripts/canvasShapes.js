var canvasShapes = function () {
    function Rect(x, y, width, height) {
        if (!(this instanceof arguments.callee)) {
            return new Rect(x, y, width, height);
        }

        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    Rect.prototype.draw = function (context) {
        context.rect(this.x, this.y, this.width, this.height);
        context.stroke();
    }

    function Circle(x, y, radius) {
        if (!(this instanceof arguments.callee)) {
            return new Circle(x, y, radius);
        }

        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    Circle.prototype.draw = function (context) {
        context.beginPath();
        context.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
        context.stroke();
    }

    function Line(fromX, fromY, toX, toY) {
        if (!(this instanceof arguments.callee)) {
            return new Line(fromX, fromY, toX, toY);
        }

        this.fromX = fromX
        this.fromY = fromY;
        this.toX = toX;
        this.toY = toY;
    }

    Line.prototype.draw = function (context) {
        context.beginPath();
        context.moveTo(this.fromX, this.fromY);
        context.lineTo(this.toX, this.toY);
        context.stroke();
    }

    return {
        Rect: Rect,
        Circle: Circle,
        Line: Line
    }
}();