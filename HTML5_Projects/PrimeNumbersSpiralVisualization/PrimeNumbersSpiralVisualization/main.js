/// <reference path="Scripts/jquery-2.1.1.js" />
(function () {
    var i, j, len,
        length = 10000000,
        primes = new Array(length);

    var canvas,
        ctx,
        size = 10,
        x,
        y;

    for (i = 2, len = Math.sqrt(length); i < len; i++) {
        if (primes[i] === undefined) {
            for (j = i * i; j < length; j += i) {
                primes[j] = 1;
            }
        }
    }

    canvas = document.createElement('canvas');
    canvas.width = 6290;
    canvas.height = 10000;
    ctx = canvas.getContext('2d');
    document.body.appendChild(canvas);

    x = 0;
    y = 0;

    ctx.fillRect(0, 0, 6290, 10000);
    ctx.fillStyle = '#0f0';
    for (i = 2; i < length; i++, x += size) {
        if (x > canvas.width) {
            x = 0;
            y += size;
        }

        if (primes[i] === undefined) {
            ctx.fillRect(x, y, size, size);
        }
    }
}());