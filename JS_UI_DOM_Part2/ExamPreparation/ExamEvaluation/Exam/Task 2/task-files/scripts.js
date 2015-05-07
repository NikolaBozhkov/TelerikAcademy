$.fn.gallery = function () {
	$control = this;
	//$control.children().addClass('.gallery .image-container img');
	$('#gallery-list').children().addClass('gallery image-container');
	$('#gallery-list').children().children().addClass('gallery image-container img');
	$('#gallery-list > #image-container > img').addClass('gallery image-container img');
	console.log(	$('#gallery-list > #image-container > img').style);
};