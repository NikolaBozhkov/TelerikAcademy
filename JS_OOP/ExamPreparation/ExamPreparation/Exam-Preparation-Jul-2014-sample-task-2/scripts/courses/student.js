define([], function () {
    var Student;

    Student = (function () {
        function Student(params) {
            this.name = params.name;
            this.exam = params.exam;
            this.homework = params.homework;
            this.attendance = params.attendance;
            this.teamwork = params.teamwork;
            this.bonus = params.bonus;
        }

        return Student;
    }());

    return Student;
});