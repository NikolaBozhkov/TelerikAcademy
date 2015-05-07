/// <reference path="../JsConsole/scripts/js-console.js" />
define(['JsConsole/scripts/js-console'], function () {
    var messenger = (function () {
        function showWelcomeScreenMessage() {
            jsConsole.writeLine('Welcome to "Sheeps and Rams"!');
            jsConsole.writeLine('Commands: resetscoreboard(which resets the score board)');
            jsConsole.writeLine('          showscoreboard(which shows the score board)');
            jsConsole.writeLine('Rules: Enter a number with different digits, 0 cannot be first digit.');
            jsConsole.writeLine('       sheeps are the digits you have right, rams are the digits that are sheeps in the right place.');
            jsConsole.writeLine('------------------------------------------');
        }

        function showWrongInputMessage() {
            jsConsole.writeLine('Unrecognized command or invalid number. Please try again.');
        }

        function showGameWonMessage(attemps) {
            jsConsole.writeLine('Congratulations you won in ' + attemps + ' attemps!');
        }

        function showNicknameRequestMessage() {
            jsConsole.writeLine('Enter you nickname for the top score board.');
        }

        function showRequestReplayMessage() {
            jsConsole.write('Would you like to play again(y/n).\n');
        }

        function showSheepsAndRamsMessage(sheeps, rams, guessNumber) {
            jsConsole.writeLine('You have ' + sheeps + ' sheeps and ' + rams + ' rams. Your guess: ' + guessNumber);
        }

        return {
            showWelcomeScreenMessage: showWelcomeScreenMessage,
            showWrongInputMessage: showWrongInputMessage,
            showRequestReplayMessage: showRequestReplayMessage,
            showSheepsAndRamsMessage: showSheepsAndRamsMessage,
            showGameWonMessage: showGameWonMessage,
            showNicknameRequestMessage: showNicknameRequestMessage
        }
    }());

    return messenger;
});