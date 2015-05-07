define(function () {
    var randomGenerator = (function () {
        // private
        function nextNumber(min, max) {
            return Math.round((Math.random() * (max - min) + min));
        }

        // public
        function generateRandomSheepsAndRamsNumber() {
            var number = [],
                nextDigit,
                i;

            number.push(nextNumber(1, 9));

            for (i = 1; i < 4; i++) {
                nextDigit = nextNumber(0, 9);

                while (number.indexOf(nextDigit) >= 0) {
                    nextDigit = nextNumber(0, 9);
                }

                number.push(nextDigit);
            }

            return parseInt(number.join(''));
        }

        return {
            generateRandomSheepsAndRamsNumber: generateRandomSheepsAndRamsNumber
        }
    }());

    return randomGenerator;
});