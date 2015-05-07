/// <reference path="libs/jquery.js" />
/// <reference path="libs/mustache.js" />
define(['./libs/mustache'], function (Mustache) {
    'use strict';

    var Controller = (function () {
        var refreshRate = 5000;

        function Controller(resourceUrl) {
            this.resourceUrl = resourceUrl;
        }

        Controller.prototype.setEventHandlers = function () {
            var self = this;
            
            $('#main-content').on('click', '#username-btn', function () {
                var username = $('#username-tb').val();
                sessionStorage.setItem('username', username || 'Anonymous');
                window.location = '#/chat';
                self.refreshMessages();
            });

            $('#main-content').on('click', '#msg-send-btn', function () {
                var msg = $('#msg-tb').val();
                $('#msg-tb').val('');

                $.post(self.resourceUrl, {
                    'user': sessionStorage.getItem('username'),
                    'text': msg
                }).then(self.refreshMessages());
            });

            $('#main-content').on('keyup', '#msg-tb', function (ev) {
                if (ev.keyCode === 13) {
                    $('#msg-send-btn').click();
                }
            });

            setInterval(function () {
                self.refreshMessages();
            }, refreshRate);
        };

        Controller.prototype.refreshMessages = function () {
            var messagesLoaded = $('#chat-window').children().length;
            $.getJSON(this.resourceUrl)
                .then(function (data) {
                    var template = $('#msg-template').html();
                    Mustache.parse(template);
                    var docFragment = new DocumentFragment();

                    // loads only the messages that are not displayed
                    for (var i = data.length - Math.abs(messagesLoaded - data.length); i < data.length; i++) {
                        var rendered = Mustache.render(template, {
                            username: data[i].by.trim(),
                            msg: data[i].text.trim()
                        });

                        $(docFragment).append(rendered);
                    }

                    $('#chat-window')
                        .append(docFragment)
                        .scrollTop($('#chat-window')[0].scrollHeight);
                });
        };

        return Controller;
    }());

    return Controller;
});