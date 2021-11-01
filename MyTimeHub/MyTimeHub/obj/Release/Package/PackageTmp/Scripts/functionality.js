var getBookingsByUser = async function (userId) {
	return $.getJSON("Bookings/GetBookingsForUser?userId=" + userId);
}

var getExportForCustomer = function (customerId) {
	window.location = (location.origin + "/Bookings/GetExportForCustomer?customerId=" + customerId);
}

var getEmployees = async function () {
	return $.getJSON("Employees/GetEmployees");
}

var getCustomers = async function () {
	return $.getJSON(location.origin + "/Customers/GetCustomers");
}

var getEventsFactory = function (bookings, userId) {
	var events = [];
	bookings.forEach(item => {
		var start = new Date(item.StartDate);
		var end = new Date(item.EndDate);
		var formatStart = new Date(start.getFullYear(), start.getMonth(), start.getDate(), start.getHours(), start.getMinutes(), 0);
		var formatEnd = new Date(end.getFullYear(), end.getMonth(), end.getDate(), end.getHours(), end.getMinutes(), 0)
		var event = {
			title: item.Description,
			start: formatStart,
			end: formatEnd,
			allDay: false,
			className: 'important',
			custom_eventId: item.ID
		};
		events.push(event);
	});
	return events;
}

var getEventsForUser = async function (userId) {
	var events = [];
	try {
		var bookings = await getBookingsByUser(userId);
		var events = [];
		if (bookings.length > 0) {
			var events = getEventsFactory(bookings, userId);
		}
		return events;
	}
	catch (ex) {		
		return events;
    }
}

var currentEmployee = localStorage['currentEmployee'];

var populateEmployees = async function () {

	try {
		var employees = await getEmployees();
		employees.forEach(item => {
			$(".employee").append('<option value="' + item.ID + '">' + item.Name + ' ' + item.Surname + '</option>')
		});
		$(".employee").val(currentEmployee);
		$(".employee").change((ev) => {
			localStorage['currentEmployee'] = $(".employee option:selected").val();
			currentEmployee = $(".employee option:selected").val();
			$('#calendar').empty();
			populateCalendar();
		});
    } catch (e) {
		$(".dropdown").html("No employee selected");
    }
}

var populateCustomers = async function () {
	try {
		var customers = await getCustomers();
		customers.forEach(item => {
			$(".customer").append('<option value="' + item.ID + '">' + item.Name + '</option>');
		});
	} catch (e) {
		$(".dropdown").html("No customer selected");
	}
}

var populateExport = function () {
	$(".exportButton").click(async () => {
		console.log($(".customer").val());
		getExportForCustomer($(".customer").val());
	});
}

var populateCalendar = async function () {
	var events = await getEventsForUser(currentEmployee);

	$('#external-events div.external-event').each(function () {

		var eventObject = {
			title: $.trim($(this).text())
		};

		$(this).data('eventObject', eventObject);
		$(this).draggable({
			zIndex: 999,
			revert: true,      
			revertDuration: 0 
		});

	});


	/* initialize the calendar
	-----------------------------------------------------------------*/

	var calendar = $('#calendar').fullCalendar({
		header: {
			left: 'title',
			center: 'agendaDay,agendaWeek,month',
			right: 'prev,next today'
		},
		editable: false,
		firstDay: 1, //  1(Monday) this can be changed to 0(Sunday) for the USA system
		selectable: true,
		defaultView: 'agendaWeek',
		axisFormat: 'h:mm',
		columnFormat: {
			month: 'ddd',    // Mon
			week: 'ddd d', // Mon 7
			day: 'dddd M/d',  // Monday 9/7
			agendaDay: 'dddd d'
		},
		titleFormat: {
			month: 'MMMM yyyy', // September 2009
			week: "MMMM yyyy", // September 2009
			day: 'MMMM yyyy'                  // Tuesday, Sep 8, 2009
		},
		allDaySlot: false,
		selectHelper: true,
		select: function (start, end, allDay) {
			var check = $.fullCalendar.formatDate(start, 'yyyy-MM-dd');
			var today = new Date();
			var lastMonthFormated = $.fullCalendar.formatDate(new Date(today.getFullYear(), today.getMonth(), 0), 'yyyy-MM-dd');
			if (check <= lastMonthFormated) {
				alert("Locked for booking!");
				window.location.href = window.location;
			} else {
				var tzoffset = (start).getTimezoneOffset() * 60000;
				var startNew = start;
				var endNew = end;
				/*startNew = new Date(start.getTime() - tzoffset);
				endNew = new Date(end.getTime() - tzoffset);*/
				console.log(startNew);
				console.log(endNew);
				window.location.href = "Bookings/Create?start=" + startNew.toISOString() + "&end=" + endNew.toISOString() + "&employee=" + currentEmployee;
			}			
		},
		droppable: false, 
		drop: function (date, allDay) {
			var originalEventObject = $(this).data('eventObject');

			var copiedEventObject = $.extend({}, originalEventObject);

			copiedEventObject.start = date;
			copiedEventObject.allDay = allDay;

			$('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

			if ($('#drop-remove').is(':checked')) {
				$(this).remove();
			}

		},
		eventClick: function (event) {
			var check = $.fullCalendar.formatDate(event.start, 'yyyy-MM-dd');
			var today = new Date();
			var todayFormated = $.fullCalendar.formatDate(new Date(today.getFullYear(), today.getMonth(), 0), 'yyyy-MM-dd');
			if (check < todayFormated) {
				alert("Locked for booking!");
				window.location.href = window.location;
			} else {
				window.location.href = "/Bookings/Edit/" + event.custom_eventId;
			}
		},
		events: events,
		selectConstraint: {
			start: new Date(),
			end: '2021-11-03'
		}
	});
}

$(document).ready(async function () {


	if (!(location.pathname == "/")) {
		if (location.pathname == "/Export") {
			await populateCustomers();
			populateExport();
        }
		return;
	}

	if (!currentEmployee) {
		currentEmployee = 1;
	}

	await Promise.all([populateEmployees(), populateCalendar()]);

});