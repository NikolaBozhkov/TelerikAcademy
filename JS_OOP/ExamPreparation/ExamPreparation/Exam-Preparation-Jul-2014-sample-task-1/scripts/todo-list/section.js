define(['todo-list/item'], function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this.title = title;
            this._items = [];
        }

        Section.prototype = {
            getData: function () {
                return {
                    title: this.title,
                    items: this._items.slice(0)
                };
            },
            add: function (item) {
                if (!(item instanceof Item)) {
                    throw {
                        message: 'Trying to add a non-item object to a section'
                    };
                }

                this._items.push(item);
            }
        };

        return Section;
    }());

    return Section;
});