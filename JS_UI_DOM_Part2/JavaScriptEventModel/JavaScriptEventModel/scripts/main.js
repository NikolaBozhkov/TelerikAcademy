window.onload = function () {
    var list = document.querySelector('#list');
    var inputField = document.querySelector('#input');
    var addButton = document.querySelector('#add');
    var removeButton = document.querySelector('#delete');
    var showButton = document.querySelector('#show');
    var hideButton = document.querySelector('#hide');

    function createTask(text) {
        var task = document.createElement('p');
        task.className = 'task';
        task.innerHTML = text;

        return task;
    }

    list.addEventListener('click', function (ev) {
        var target = ev.target;

        if (target.className.indexOf('task') >= 0)  {
            if (target.className.indexOf('selected') >= 0) {
                target.className = target.className.replace(/\b\sselected\b/, '');
            }
            else {
                target.className += ' selected';
            }
        }
    });

    addButton.addEventListener('click', function () {
        if (inputField.value) {
            var task = createTask(inputField.value);
            list.appendChild(task);
        }
    });

    removeButton.addEventListener('click', function () {
        var selected = document.querySelectorAll('.selected');

        for (var i = 0, length = selected.length; i < length; i++) {
            selected[i].parentNode.removeChild(selected[i]);
        }
    });

    hideButton.addEventListener('click', function () {
        list.style.display = 'none';
    });

    showButton.addEventListener('click', function () {
        list.style.display = '';
    });
};