/// <reference path="jquery-2.1.1.min.js" />
var domModule = function () {
    var buffer = [];
    var selectors = [];

    function appendChild(element, selector) {
        var parent = $(selector);
        parent.append(element);
    }

    function removeChild(parentSelector, elementSelector) {
        $(parentSelector).find(elementSelector).remove();
    }

    function addHandler(selector, eventType, eventHandler) {
        $(selector).on(eventType, eventHandler);
    }

    function appendToBuffer(selector, element) {
        buffer.push(element);
        selectors.push(selector);

        if (buffer.length >= 100) {
            for (var i = 0; i < buffer.length; i++) {
                $(selectors[i]).append(buffer[i]);
            }

            buffer = [];
            selectors = [];
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    }
}();

var div = document.createElement("div");

//appends div to #wrapper
domModule.appendChild(div, "#wrapper");

//removes li:first-child from ul
domModule.removeChild("ul", "li:first-child");

//add handler to each a element with class button
domModule.addHandler("a.button", 'click',
                     function () { alert("Clicked") });

domModule.appendToBuffer("#wrapper", div.cloneNode(true));
domModule.appendToBuffer("#wrapper ul", $('<li/>').html('new li'));

var link = $('<a/>').html('new button').addClass('button').attr('href', '#');
domModule.appendToBuffer('#wrapper ul li:first-child', link);

// The above was to check the different selector appending
// The following checks if appending happens at 100 elements
for (var i = 0; i < 150; i++) {
    domModule.appendToBuffer("#wrapper ul", $('<li/>').html(i + 6));
}