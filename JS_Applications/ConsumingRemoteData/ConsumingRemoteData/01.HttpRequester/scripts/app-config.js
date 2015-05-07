/// <reference path="libs/require.js" />
/// <reference path="libs/jquery.min.js" />
/// <reference path="httpRequester.js" />
(function () {
    require.config({
        paths: {
            'jquery': './libs/jquery.min',
            'httpRequester': './httpRequester',
            'rsvp': './libs/rsvp'
        }
    });

    require(['jquery', 'httpRequester'], function ($, httpRequester) {
        function renderStudents(students) {
            var i, len, $item,
                $list = $('<ul/>').addClass('students-list');

            $list.append($('<li/>').append($('<strong/>').html('Students')));

            for (i = 0, len = students.length; i < len; i++) {
                $item = $('<li/>').addClass('student').html('Student: ' + students[i].id);
                $list.append($item);
            }

            $('#students-list-container').append($list);
        }

        function getStudentsData() {
            httpRequester.getJSON('http://localhost:3000/students')
                .then(function (data) {
                    renderStudents(data.students);
                }, function (err) {
                    console.log(err);
                });
        }

        for (var i = 0; i < 10; i++) {
            var student = {
                fname: 'Pesho',
                lname: 'Georgiev',
                marks: '4, 5, 6'
            };

            httpRequester.postJSON('http://localhost:3000/students', student);
        }

        $('#get-students-data').on('click', function () {
            getStudentsData();
        });
    });
}());