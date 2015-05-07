/// <reference path="libs/underscore-min.js" />
(function () {
    var books = [
        { title: 'Book #1', author: 'Jack Sparrow' },
        { title: 'Book #2', author: 'Jack Sparrow' },
        { title: 'Book #3', author: 'Stephen Stinkinson' },
        { title: 'Book #4', author: 'Willian Nutshell' },
        { title: 'Book #5', author: 'Willian Nutshell' },
        { title: 'Book #6', author: 'Stephen Stinkinson' },
        { title: 'Book #7', author: 'Willian Nutshell' }
    ];

    var people = [
        { fname: 'Andrea', lname: 'Stamenova' },
        { fname: 'Georgi', lname: 'Georgiev' },
        { fname: 'Atanas', lname: 'Ledov' },
        { fname: 'Anastasiq', lname: 'Stamenova' },
        { fname: 'Andrea', lname: 'Ledova' },
        { fname: 'Yordan', lname: 'Georgiev' },
        { fname: 'Georgi', lname: 'Ledov' },
        { fname: 'Stamen', lname: 'Ledov' },
        { fname: 'Andrea', lname: 'Georgieva' },
        { fname: 'Andrea', lname: 'Jivkova' }
    ];

    // Task 6
    console.log('------------------');
    console.log('Task 6:');

    function findMostFamousAuthor(books) {
        var biggestGroup = _.chain(books)
            .groupBy('author')
            .sortBy('length')
            .last().value();

        if (biggestGroup !== undefined && biggestGroup.length !== 0) {
            return biggestGroup[0].author;
        }
    }

    console.log(findMostFamousAuthor(books));

    // Task 7
    console.log('------------------');
    console.log('Task 7:');

    // For those 2 tasks we can use only 1 function with different parameters, but this works too
    // cuz we use only 1 and we don't confuse the client with the other 2 params that are not so clear
    function findMostCommonFirstName(people) {
        return _.chain(people)
            .groupBy('fname')
            .sortBy('length')
            .last().value()[0].fname;
    }

    function findMostCommonLastName(people) {
        return _.chain(people)
            .groupBy('lname')
            .sortBy('length')
            .last().value()[0].lname;
    }

    console.log('Most common first name: ' + findMostCommonFirstName(people));
    console.log('Most common last name: ' + findMostCommonLastName(people));
}());