/// <reference path="../JsConsole/scripts/js-console.js" />
define(['JsConsole/scripts/js-console'], function () {
    var topScoreBoard = (function () {
        function add(nickname, score) {
            localStorage.setItem(nickname, score.toString());
        }

        function reset() {
            localStorage.clear();
        }

        function display() {
            var nickname, score, i;

            jsConsole.writeLine('---------------Score Board---------------')
            for (i = 0, len = localStorage.length; i < len; i++) {
                nickname = localStorage.key(i);
                score = localStorage.getItem(nickname);

                jsConsole.writeLine((i + 1) + '.' + nickname + ' - ' + score);
            }

            jsConsole.writeLine('-----------------------------------------');
        }

        return {
            add: add,
            reset: reset,
            display: display
        }
    }());

    return topScoreBoard;
});