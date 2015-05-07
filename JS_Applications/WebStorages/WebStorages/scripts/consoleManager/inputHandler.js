/// <reference path="messenger.js" />
/// <reference path="../JsConsole/scripts/js-console.js" />
define(['consoleManager/messenger', 'JsConsole/scripts/js-console'], function (messenger) {
    var inputHandler = (function () {
        // private
        function checkIfNumberIsForSheepsAndRams(guessNumber) {
            var i, j, stringNumber;

            stringNumber = guessNumber.toString();

            for (i = 0; i < 4; i++) {
                for (j = i + 1; j < 4; j++) {
                    if (stringNumber[i] === stringNumber[j]) {
                        return false;
                    }
                }
            }

            return true;
        }

        // public 
        function checkIfGuessNumberIsValid(guessNumber) {
            var isValid = !isNaN(guessNumber) && 
                guessNumber.toString().length === 4 && 
                checkIfNumberIsForSheepsAndRams(guessNumber);

            if (isValid) {
                return true;
            }
            else {
                return false;
            }
        }

        function readInput(selector) {
            return jsConsole.read(selector);
        }

        return {
            checkIfGuessNumberIsValid: checkIfGuessNumberIsValid,
            readInput: readInput
        }
    }());

    return inputHandler;
});