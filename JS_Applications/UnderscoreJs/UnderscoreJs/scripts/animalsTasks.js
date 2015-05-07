/// <reference path="libs/underscore-min.js" />
(function () {
    // Same species can't have different amount of legs, I guess the task description is wrong
    // sooo yea, just go with it
    var animals = [
        { kind: 'terrestrial', legs: 4 },
        { kind: 'aquatic', legs: 0 },
        { kind: 'terrestrial', legs: 2 },
        { kind: 'amphibian', legs: 2 },
        { kind: 'terrestrial', legs: 2 },
        { kind: 'aquatic', legs: 2 },
        { kind: 'terrestrial', legs: 4 },
        { kind: 'amphibian', legs: 4 },
        { kind: 'terrestrial', legs: 8 },
        { kind: 'terrestrial', legs: 100 },
        { kind: 'amphibian', legs: 6 },
        { kind: 'aquatic', legs: 6 }
    ];

    // Task 4
    console.log('------------------');
    console.log('Task 4:');

    function groupByKindAndSortByNumberOfLegs(animals) {
        return _.chain(animals)
            .sortBy('legs')
            .groupBy('kind').value();
    }

    console.log(groupByKindAndSortByNumberOfLegs(animals));

    // Task 5
    console.log('------------------');
    console.log('Task 5:');

    function getTotalNumberOfLegs(animals) {
        return _.chain(animals)
            .map(function (animal) {
                return animal.legs;
            })
            .reduce(function (memo, legs) {
                return memo + legs;
            }, 0).value();
    }

    console.log('All legs: ' + getTotalNumberOfLegs(animals));
}());