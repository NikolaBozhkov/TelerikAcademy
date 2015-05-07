function createCalendar(containerId, events) {
    var container = document.querySelector(containerId);
    container.style.width = 1200 + 'px';

    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    var dfrag = document.createDocumentFragment();
    for (var i = 0; i < 30; i++) {
        var day = document.createElement('div');
        var dayContent = document.createElement('div');
        dayContent.className = 'day-content';
        dayContent.innerHTML = '&nbsp;';

        day.style.display = 'inline-block';
        day.style.width = 150 + 'px';
        day.style.height = 150 + 'px';
        day.style.border = '1px solid black';

        var date = document.createElement('div');
        date.className = 'date';
        date.innerHTML = days[i % 7] + ' ' + (i + 1) + ' June 2014';
        date.style.backgroundColor = '#ccc';
        date.style.textAlign = 'center';
        date.style.fontWeight = 'bold';
        date.style.borderBottom = '1px solid black';

        day.appendChild(date);
        day.appendChild(dayContent);
        dfrag.appendChild(day);
    }

    for (var i = 0; i < events.length; i++) {
        var current = events[i];
        var dayIndex = current.date - 1;

        var event = document.createElement('span');
        event.innerHTML = current.hour + ' ' + current.title;
        dfrag.childNodes[dayIndex].querySelector('.day-content').appendChild(event);
    }

    container.appendChild(dfrag);

    document.querySelector('.date').addEventListener('mousein', function () {
        this.firstElementChild.style.backgroundColor = '#999';
    });
}