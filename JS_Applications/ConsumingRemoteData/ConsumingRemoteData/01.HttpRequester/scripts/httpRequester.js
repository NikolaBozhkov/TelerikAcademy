define(['jquery', 'rsvp'], function ($) {
    var httpRequester = (function () {
        function getJSON(requestUrl) {
            var promise = new RSVP.Promise(function (resolve, reject) {
                $.ajax({
                    url: requestUrl,
                    type: 'GET',
                    dataType: 'json',
                    success: function (data) {
                        resolve(data);
                    },
                    error: function (err) {
                        reject(err);
                    }
                });
            });

            return promise;
        }

        function postJSON(requestUrl, data) {
            var promise = new RSVP.Promise(function (resolve, reject) {
                $.ajax({
                    url: requestUrl,
                    type: 'POST',
                    contentType: 'aplication/json',
                    dataType: 'json',
                    data: JSON.stringify(data),
                    success: function (data) {
                        resolve(data);
                    },
                    error: function (err) {
                        reject(err);
                    }
                })
            });

            return promise;
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    }());

    return httpRequester;
});