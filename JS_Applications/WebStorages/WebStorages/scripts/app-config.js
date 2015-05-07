(function (){
    require.config({
        paths: {
            driver: 'driver/driver'
        }
    });

    require(['driver'], function (driver) {
        driver.run('#sheeps-and-rams-input-field', '#sheeps-and-rams-input-button');
    });
}());