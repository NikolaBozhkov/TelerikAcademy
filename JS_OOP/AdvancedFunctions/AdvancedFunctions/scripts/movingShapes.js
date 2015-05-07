/// <reference path="jquery-2.1.1.min.js" />
var movingShapes = function () {
    var divs = [];
    var divTypes = [];
    var width = 50 + 'px';
    var height = 35 + 'px';
    var rectTrajectoryWidth = 300;
    var rectTrajectoryHeight = 150;
    var rectTrajectoryX = 100;
    var rectTrajectoryY = 100;
    var displacement = 5;
    var circleTrajectoryRadius = 150;
    var circleTrajectoryX = 700;
    var circleTrajectoryY = 200;
    var angle = 0.01;

    function generateRandomColor() {
        var color,
            red,
            green,
            blue;

        red = Math.round(Math.random() * 255);
        green = Math.round(Math.random() * 255);
        blue = Math.round(Math.random() * 255);
        
        color = 'rgb(' + red + ', ' + green + ', ' + blue + ')';
        return color;
    }

    function generateDiv() {
        var div = $('<div/>');

        div.css('width', width)
            .css('height', height)
            .css('position', 'absolute')
            .css('background-color', generateRandomColor())
            .css('color', generateRandomColor())
            .css('border-color', generateRandomColor());

        return div;
    }

    function add(movementType) {
        movementType = movementType || 'rect';
        var div = generateDiv();

        if (movementType === 'rect') {
            $(div).css('top', rectTrajectoryY)
                .css('left', rectTrajectoryX);

            divTypes.push('rect');
        }
        
        if (movementType === 'ellipse') {
            $(div).css('top', circleTrajectoryY)
                .css('left', rectTrajectoryX + circleTrajectoryRadius);

            divTypes.push('ellipse');
        }

        divs.push(div);
        $('body').append(div);
    }

    function moveAroundRect(div) {
        var $div = $(div);
        var newLeft,
            newTop;

        if ($div.css('top') === rectTrajectoryX + 'px') { // Moving right
            newLeft = parseInt($div.css('left')) + displacement;

            if (newLeft < rectTrajectoryX + rectTrajectoryWidth) {
                $div.css('left', newLeft + 'px');
            } else {
                $div.css('left', rectTrajectoryX + rectTrajectoryWidth + 'px');
            }
        }

        if ($div.css('left') === rectTrajectoryX + rectTrajectoryWidth + 'px') { // Moving down
            newTop = parseInt($div.css('top')) + displacement;

            if (newTop < rectTrajectoryY + rectTrajectoryHeight) {
                $div.css('top', newTop + 'px');
            } else {
                $div.css('top', rectTrajectoryY + rectTrajectoryHeight + 'px');
            }
        }

        if ($div.css('top') === rectTrajectoryY + rectTrajectoryHeight + 'px') { // Moving left
            newLeft = parseInt($div.css('left')) - displacement;

            if (newLeft > rectTrajectoryX) {
                $div.css('left', newLeft + 'px');
            } else {
                $div.css('left', rectTrajectoryX + 'px');
            }
        }

        if ($div.css('left') === rectTrajectoryX + 'px') { // Moving up
            newTop = parseInt($div.css('top')) - displacement;

            if (newTop > rectTrajectoryY) {
                $div.css('top', newTop + 'px');
            } else {
                $div.css('top', rectTrajectoryY + 'px');
            }
        }
    }

    function moveAroundCircle(div, angle) {
        var newLeft = Math.round(circleTrajectoryX + circleTrajectoryRadius * Math.cos(angle)) + 'px';
        var newTop = Math.round(circleTrajectoryY + circleTrajectoryRadius * Math.sin(angle)) + 'px';

        $(div).css('left', newLeft).css('top', newTop);
    }

    (function animate() {
        for (var i = 0; i < divs.length; i++) {
            if (divTypes[i] === 'rect') {
                moveAroundRect(divs[i]);
            }

            if (divTypes[i] === 'ellipse') {
                var numberOFEllipseDivs = divTypes.filter(function (a) {  
                    return a === 'ellipse' 
                }).length;

                moveAroundCircle(divs[i], angle + i * 2 * Math.PI / numberOFEllipseDivs);
            }
        }

        angle += 0.05;
        requestAnimationFrame(animate);
    }());

    return {
        add: add
    }
}();

$('#addToRectButton').on('click', function () {
    movingShapes.add('rect');
});

$('#addToCircleButton').on('click', function () {
    movingShapes.add('ellipse');
});