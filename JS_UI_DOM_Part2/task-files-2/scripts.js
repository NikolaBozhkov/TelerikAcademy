/// <reference path="jquery.min.js" />
$.fn.gallery = function (columns) {
    var cols = columns || 4;
    var $self = $(this);
    $self.addClass('gallery');

    var $selected = $self.find('.selected');
    var $galleryList = $self.find('.gallery-list');

    $selected.hide();

    var width = (250 * cols) + cols * 10; // img width + margin
    $self.css('width', width + 'px');

    var changeSelectedImages = function ($target) {
        var selectedPicNumber = parseInt($target.attr('data-info'));
        var previousPicNumber = selectedPicNumber - 1 < 1 ? 12 : selectedPicNumber - 1;
        var nextPicNumber = selectedPicNumber + 1 > 12 ? 1 : selectedPicNumber + 1;

        $self.find('#current-image').attr({
            src: 'imgs/' + selectedPicNumber + '.jpg',
            'data-info': selectedPicNumber
        });
        $self.find('#previous-image').attr({
            src: 'imgs/' + previousPicNumber + '.jpg',
            'data-info': previousPicNumber
        });
        $self.find('#next-image').attr({
            src: 'imgs/' + nextPicNumber + '.jpg',
            'data-info': nextPicNumber
        });
    };
    // Select an image from the list
    $self.find('.image-container img').on('click', function () {
        if (!$galleryList.hasClass('blurred')) {
            changeSelectedImages($(this));

            $galleryList.addClass('blurred')
                .first()
                .each(function () {
                    $(this).addClass('blurred');
                });

            $selected.show();
        }
    });

    // Clicked on the already enlarged
    $selected.find('#current-image').on('click', function () {
        $selected.hide();
        $galleryList.removeClass('blurred')
                .first()
                .each(function () {
                    $(this).removeClass('blurred');
                });
    });

    // Clicked on the previous
    $selected.find('#previous-image').on('click', function () {
        changeSelectedImages($(this));
    });

    // Clicked on the next
    $selected.find('#next-image').on('click', function () {
        changeSelectedImages($(this));
    });
};