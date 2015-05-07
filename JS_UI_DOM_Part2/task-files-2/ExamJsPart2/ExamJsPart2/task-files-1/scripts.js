function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);

    var selectedImageContainer = document.createElement('div');
    var selectedImageTitle = document.createElement('h1');
    var selectedImage = document.createElement('img');
    var input = document.createElement('input');
    var imagesList = document.createElement('ul');
    var imageBox = document.createElement('li');
    imageBox.className = 'imageBox';
    var imageTitle = document.createElement('strong');
    var image = document.createElement('img');

    // Styles
    selectedImageContainer.style.display = 'inline-block';
    selectedImageContainer.style.textAlign = 'center';
    selectedImageContainer.style.verticalAlign = 'top';
    selectedImageContainer.style.marginTop = 30 + 'px';
    selectedImageContainer.style.width = 400 + 'px';
    selectedImage.style.width = 100 + '%';
    selectedImage.style.borderRadius = 15 + 'px';
    input.style.width = 130 + 'px';
    imagesList.style.listStyleType = 'none';
    imagesList.style.display = 'inline-block';
    imagesList.style.height = 400 + 'px';
    imagesList.style.overflowY = 'scroll';
    imagesList.style.textAlign = 'center';
    imageBox.style.width = 130 + 'px';
    imageBox.style.padding = '0 7px';
    image.style.width = 100 + '%';
    image.style.borderRadius = 5 + 'px';

    var addImagesToList = function () {
        for (var i = 0; i < items.length; i++) {
            var current = items[i];

            imageTitle.innerHTML = current['title'];
            image.src = current['url'];

            var childImageBox = imageBox.cloneNode(true);
            childImageBox.appendChild(imageTitle.cloneNode(true));
            childImageBox.appendChild(image.cloneNode(true));

            imagesList.appendChild(childImageBox);
        }
    };

    var onImageMouseover = function (ev) {
        this.style.backgroundColor = '#B8C5D3';
    };

    var onImageMouseout = function (ev) {
        this.style.backgroundColor = '';
    };

    var onImageClick = function (ev) {
        var img = this.querySelector('img');
        selectedImage.src = img.getAttribute('src');
        selectedImageTitle.innerHTML = this.firstElementChild.innerHTML;
    };

    var onInputKeyup = function (ev) {
        var value = this.value;
        var imageBoxes = imagesList.querySelectorAll('.imageBox');
        if (value === '') {
            for (var i = 0, len = imageBoxes.length; i < len; i++) {
                imageBoxes[i].style.display = ''; // Setting the default or css display
            }
        }
        else {
            for (var i = 0, len = imageBoxes.length; i < len; i++) {
                var title = imageBoxes[i].firstElementChild.innerHTML;

                imageBoxes[i].style.display = 'none'; // Hide every box

                if (title.toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                    imageBoxes[i].style.display = ''; // Show the box if the value is inside the title
                }
            }
        }
    };

    // No need to use doc fragment, cuz there are no elements appended to the DOM three
    // Creating the list
    var filterBox = imageBox.cloneNode(true);
    filterBox.className = ''; // Removing the imageBox class
    filterBox.innerHTML = 'Filter';
    input.addEventListener('keyup', onInputKeyup); // Filter event
    filterBox.appendChild(input);
    imagesList.appendChild(filterBox);

    addImagesToList();

    // Creating the selected image container
    // Setting the default image to be the first
    var firstImageSrc = imagesList.querySelector('img').getAttribute('src');
    selectedImage.src = firstImageSrc;
    selectedImageTitle.innerHTML = imagesList.querySelector('img').previousElementSibling.innerHTML;
    selectedImageContainer.appendChild(selectedImageTitle);
    selectedImageContainer.appendChild(selectedImage);
    
    var imageBoxes = imagesList.querySelectorAll('.imageBox');

    for (var i = 0, len = imageBoxes.length; i < len; i++) {
        imageBoxes[i].addEventListener('mouseover', onImageMouseover);
        imageBoxes[i].addEventListener('mouseout', onImageMouseout);
        imageBoxes[i].addEventListener('click', onImageClick);
    }

    container.appendChild(selectedImageContainer);
    container.appendChild(imagesList);
}