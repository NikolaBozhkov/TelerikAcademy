define(['courses/student'], function (Student) {
    var Course;

    Course = (function () {
        function Course(name, formula) {
            this.name = name;
            this.formula = formula;
            this._students = [];
        }

        Course.prototype = {
            addStudent: function (student) {
                if (!(student instanceof Student)) {
                    throw {
                        message: 'Cannot add object different from Student to Course!'
                    };
                }

                this._students.push(student);
            },
            calculateResults: function () {
                var currentSt,
                    i;

                this._results = [];

                for (i = 0, len = this._students.length; i < len; i++) {
                    currentSt = this._students[i];

                    this._results.push({
                        student: currentSt,
                        totalScore: this.formula(currentSt)
                    });
                }
            },
            getTopStudentsByExam: function (count) {
                if (!this._results || this._results.length < this._students.length) {
                    this.calculateResults();
                }

                return this._results
                    .sort(function (stResult1, stResult2) {
                        return stResult2.student.exam - stResult1.student.exam;
                    })
                    .slice(0, count)
                    .map(function (stResult) {
                        var stFinal = Object.create(stResult.student);
                        stFinal.totalScore = stResult.totalScore;
                        return stFinal;
                    });
            },
            getTopStudentsByTotalScore: function (count) {
                if (!this._results || this._results.length < this._students.length) {
                    this.calculateResults();
                }

                return this._results
                    .sort(function (stResult1, stResult2) {
                        return stResult2.totalScore - stResult1.totalScore;
                    })
                    .slice(0, count)
                    .map(function (stResult) {
                        var stFinal = Object.create(stResult.student);
                        stFinal.totalScore = stResult.totalScore;
                        return stFinal;
                    });
            }
        };

        return Course;
    }());

    return Course;
});