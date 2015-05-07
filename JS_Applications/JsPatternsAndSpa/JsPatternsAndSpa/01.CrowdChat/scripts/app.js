/// <reference path="libs/sammy.js" />
(function () {
    'use strict';

    require.config({
        paths: {
            jquery: 'libs/jquery',
            mustache: 'libs/mustache',
            sammy: 'libs/sammy',
            controller: 'controller'
        }
    });

    require(['jquery', 'sammy', 'controller'], function ($, sammy, Controller) {
        var controller = new Controller('http://crowd-chat.herokuapp.com/posts');
        controller.setEventHandlers();

        var app = sammy('#main-content', function () {
            this.get('#/home', function () {
                $('#main-content').load('./partials/usernameForm.html');
            });

            this.get('#/chat', function () {
                $('#main-content').load('./partials/chatWindow.html');

            });

            this.get('#/about', function () {
                $('#main-content').load('./partials/about.html');
            });
        });

        app.run('#/home');
    });
}());