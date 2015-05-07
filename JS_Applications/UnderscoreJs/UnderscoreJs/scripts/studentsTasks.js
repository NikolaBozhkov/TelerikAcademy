/// <reference path="libs/underscore-min.js" />
(function () {
    var students = [
        { fname: 'Ana', lname: 'Borisova', age: 17, marks: [2, 4, 3, 5, 6, 6] },
        { fname: 'Pesho', lname: 'Georgiev', age: 21, marks: [5, 5, 3, 5, 6, 6] },
        { fname: 'Yordan', lname: 'Ivanov', age: 19, marks: [2, 6, 5, 5, 4, 6] },
        { fname: 'Doncho', lname: 'Stanev', age: 27, marks: [5, 5, 5, 6, 6, 6] }
    ];

    // Task 1
    console.log('Task 1:');

    _.chain(students)
        .filter(function (student) {
            return student.fname.toLowerCase() < student.lname.toLowerCase();
        })
        .sortBy(function (student) {
            return -1 * (student.fname.toLowerCase() + student.lname.toLowerCase()).charCodeAt();
        })
        .each(function (student) {
            console.log(student);
        });

    // Task 2
    console.log('------------------');
    console.log('Task 2:');

    function findAllBetween18And24(students) {
        var result = _.chain(students)
            .filter(function (student) {
                return student.age >= 18 && student.age <= 24;
            })
            .map(function (student) {
                return student.fname + ' ' + student.lname + ' is ' + student.age;
            }).value();

        return result;
    }

    _.each(findAllBetween18And24(students), function (student) {
        console.log(student);
    });

    // Task 3
    console.log('------------------');
    console.log('Task 3:');

    function findStudentWithHighestMarks(students) {
        return _.chain(students)
            .sortBy(function (student) {
                var sum = _.reduce(student.marks, function (memo, mark) {
                    return memo + mark;
                }, 0);

                return sum / student.marks.length;
            })
            .last().value();
    }

    console.log(findStudentWithHighestMarks(students));
}());