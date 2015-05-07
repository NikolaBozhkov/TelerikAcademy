(function () {
    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1.min',
            handlebars: 'libs/handlebars-v1.3.0',
            controls: 'libs/controls',
            data: 'libs/data'
        }
    });
    
    require(['jquery', 'handlebars', 'controls', 'data'], function ($, handlebars, controls, data) {
        var people,
            comboBox,
            template,
            comboBoxHtml;

        people = data.people;
        comboBox = controls.ComboBox(people);
        template = $('#person-template').html();
        comboBoxHtml = comboBox.render(template);
        $('#comboBox-container').html(comboBoxHtml);
    });
}());