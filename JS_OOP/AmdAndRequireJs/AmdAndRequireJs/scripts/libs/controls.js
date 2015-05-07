define(['jquery', 'handlebars'], function () {
    var controls = (function () {
        function ComboBox(people) {
            function render(template) {
                var $comboBox = $($('<div/>').attr('id', 'comboBox')),
                    selectedClass = 'selected',
                    i;

                template = Handlebars.compile(template);

                for (i = 0; i < people.length; i++) {
                    $comboBox.append($(template(people[i])));
                }

                $comboBox.children().on('click', function () {
                    if ($(this).hasClass(selectedClass)) {
                        $(this).removeClass(selectedClass);
                        $comboBox.children().slideDown(300);
                    }
                    else {
                        $comboBox.children().hide();
                        $(this).addClass(selectedClass).show();
                    }
                });

                $comboBox.children().first().click();

                $comboBox.children().on('mouseover', function () {
                    $(this).css('background-color', 'lightgreen');
                });

                $comboBox.children().on('mouseout', function () {
                    $(this).css('background-color', '#e7eecf');
                });

                return $comboBox;
            }

            return {
                render: render
            };
        }

        return {
            ComboBox: ComboBox
        };
    }());
    
    return controls;
});