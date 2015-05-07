define(['todo-list/section'], function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype = {
            getData: function () {
                var resultData, section, _i, _len;
                resultData = [];

                for (_i = 0, _len = this._sections.length; _i < _len; _i++) {
                    section = this._sections[_i];
                    resultData.push(section.getData());
                }

                return resultData;
            },
            add: function (section) {
                if (!(section instanceof Section)) {
                    throw {
                        message: 'Trying to add a non-section object to a container'
                    };
                }

                this._sections.push(section);
            }
        };

        return Container;
    }());

    return Container;
});