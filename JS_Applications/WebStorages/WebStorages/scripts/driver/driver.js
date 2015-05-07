define(['consoleManager/messenger', 'topScoreBoard/topScoreBoard', 'consoleManager/inputHandler', 'randomGenerator/randomGenerator'], function (messenger, topScoreBoard, inputHandler, randomGenerator) {
    var driver = (function () {
        // private
        var secretNumber = randomGenerator.generateRandomSheepsAndRamsNumber(),
            attemps = 0,
            input,
            _inputSelector,
            _inputButtonSelector,
            selectingToReset = false,
            askedForNickname = false;

        // returns array with sheeps and rams count [sheeps, rams]
        function countSheepsAndRams(guessNumber, secretNumber) {
            var sheeps = 0,
                rams = 0,
                ramsIndexes = [],
                secretNumString = secretNumber.toString(),
                guessNumString = guessNumber.toString(),
                i;

            for (i = 0; i < secretNumString.length; i++) {
                if (secretNumString[i] === guessNumString[i]) {
                    rams++;
                    ramsIndexes.push(i);
                }
            }

            for (i = 0; i < guessNumString.length; i++) {
                if (secretNumString.indexOf(guessNumString[i]) >= 0 && ramsIndexes.indexOf(i) === -1) {
                    sheeps++;
                }
            }

            return [sheeps, rams];
        }

        function selectCommand() {
            var guessNumber = parseInt(input);

            if (selectingToReset) {
                if (input === 'n') {
                    selectingToReset = false;
                    document.querySelector(_inputButtonSelector).removeEventListener(onInputButtonClick);
                }
                else if (input === 'y') {
                    selectingToReset = false;
                    restart();
                }
            }
            else if (askedForNickname) {
                askedForNickname = false;
                topScoreBoard.add(input, attemps);

                selectingToReset = true;
                messenger.showRequestReplayMessage();
            }
            else {
                switch (input) {
                    case 'showscoreboard':
                        topScoreBoard.display();
                        break;

                    case 'resetscoreboard':
                        topScoreBoard.reset();
                        break;

                    default:
                        if (inputHandler.checkIfGuessNumberIsValid(guessNumber)) {
                            var sheepsAndRams = countSheepsAndRams(guessNumber, secretNumber);
                            attemps++;

                            if (sheepsAndRams[1] === 4) {
                                messenger.showGameWonMessage(attemps);

                                askedForNickname = true;
                                messenger.showNicknameRequestMessage();
                            }
                            else {
                                messenger.showSheepsAndRamsMessage(sheepsAndRams[0], sheepsAndRams[1], secretNumber);
                            }
                        }
                        else {
                            messenger.showWrongInputMessage();
                        }

                        break;
                }
            }
        }

        function restart() {
            secretNumber = randomGenerator.generateRandomSheepsAndRamsNumber();
            attemps = 0;
            messenger.showWelcomeScreenMessage();
        }

        function onInputButtonClick() {
            input = inputHandler.readInput(_inputSelector);
            selectCommand();
        }

        // public
        function run(inputSelector, inputButtonSelector) {
            _inputSelector = inputSelector;
            _inputButtonSelector = inputButtonSelector;

            document.querySelector(_inputButtonSelector).addEventListener('click', onInputButtonClick);

            messenger.showWelcomeScreenMessage();
        }

        return {
            run: run
        }
    }());

    return driver;
});