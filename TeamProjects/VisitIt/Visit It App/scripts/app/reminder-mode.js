var app = app || {};
app.viewmodels = app.viewmodels || {};

(function (scope) {
	var listview;
	
    function initialize() {
		var filter = new Everlive.Query();
		filter.where().eq('Mode.Name', 'Reminder');
		
		everlive.data('Reminders')
			.get(filter)
			.then(function (data) {				
				mobileListViewDataBindInit(data.result);
			}, function (error) {
				navigator.notification.alert('Could not retrieve reminders.');
			});
    }
	
	function mobileListViewDataBindInit(data) {
		if (listview !== undefined) {
			listview.destroy();	
		}
		
		listview = $("#listview-reminder").kendoMobileListView({
			dataSource: data,
			template: $('#reminderViewTemplate').html(),
			fixedHeaders: true
		});
		
		app.reminderControl.addSwipeEventToList();
	}
    	
    scope.reminder = {
        initialize: initialize
    };
}(app.viewmodels));