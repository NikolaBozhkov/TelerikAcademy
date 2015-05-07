/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $self = $(this);
    $self.addClass('tabs-container');

    var tabContentSelector = '.tab-item-content';

    $self.find(tabContentSelector).hide();

    $self.children('.tab-item').first().addClass('current')
        .find(tabContentSelector).show();

    $self.children('.tab-item').on('click', function () {
        $self.find('.current').removeClass('current')
            .find(tabContentSelector).hide();

        $(this).addClass('current').find(tabContentSelector).show();
    });
};