var specialConsole = function () {
    function replacePlaceHolders(arguments) {
        var msg = arguments[0];

        for (var i = 1; i < arguments.length; i++) { // Enters only if there are placeholders
            var regEx = new RegExp('\\{' + (i - 1) + '\}', 'g');
            msg = msg.replace(regEx, arguments[i].toString());
        }

        return msg;
    }

    function writeLine(msg) {
        msg = replacePlaceHolders(arguments);
        console.log(msg);
    }

    function writeError(msg) {
        msg = replacePlaceHolders(arguments);
        console.error(msg);
    }

    function writeWarning(msg) {
        msg = replacePlaceHolders(arguments);
        console.warn(msg);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
}();

specialConsole.writeLine('Pesho {0} {0} is {1} years old and lives in {2}', 'Georgiev', 21, 'Sofia');
specialConsole.writeWarning('That was a lie {0} is actually {1} years old', 'Pesho', 23);
specialConsole.writeError('Critical lie, he is 25');