$(document).ready(function () {
	// Attach change event handler to the select element
	$("#ServiceId").on('change', function () {
		// Get the value of the select element
		let connectionID = $(this).val();

		// Hide all connection sections
		$("#DailUp, #BroadbandConnection, #LandLineConnection").hide();

		// Show the selected connection section based on the value
		if (connectionID === '1') {
			$("#BroadbandConnection").show();
			
		} else if (connectionID === '2') {
			$("#LandLineConnection").show();
			
		} else if (connectionID === '3') {
			$("#DailUp").show();
		}
	});

})

//function getFormData() {
//	return {
//		name: $('#inputEmail4').val(),
//		email: $('#inputPassword4').val(),
//		phone: $('#inputPhone').val(),
//		address: $('#inputAddress').val(),
//		detailAddress: $('#inputAddress2').val(),
//		city: $('#inputCity').val(),
//		serviceId: $('#ServiceId').val(),
//		zip: $('#inputZip').val(),
//		hourlyPlan: $('input[name="hourlyPlan"]:checked').val(),
//		kbpsPlan28: $('input[name="28kbpsPlan"]:checked').val(),
//		kbpsPlan56: $('input[name="56kbpsPlan"]:checked').val(),
//		broadbandHourlyPlan: $('input[name="broadbandHourlyPlan"]:checked').val(),
//		kbpsPlan64: $('input[name="64kbpsPlan"]:checked').val(),
//		kbpsPlan128: $('input[name="128kbpsPlan"]:checked').val(),
//		localPlan: $('input[name="localPlan"]:checked').val(),
//		stdPlan: $('input[name="stdPlan"]:checked').val()
//	}
//}


$("#RegisterServices").click(function (event) {
	event.preventDefault();
	var data = {
		name: $('#inputEmail4').val(),
		email: $('#inputPassword4').val(),
		phone: $('#inputPhone').val(),
		address: $('#inputAddress').val(),
		detailAddress: $('#inputAddress2').val(),
		city: $('#inputCity').val(),
		//serviceId: $('#ServiceId').val(),
		ServiceName: $('#ServiceId option:selected').text(),
		zip: $('#inputZip').val(),
		hourlyPlan: $('input[name="hourlyPlan"]:checked').val(),
		kbpsPlan28: $('input[name="28kbpsPlan"]:checked').val(),
		kbpsPlan56: $('input[name="56kbpsPlan"]:checked').val(),
		broadbandHourlyPlan: $('input[name="broadbandHourlyPlan"]:checked').val(),
		kbpsPlan64: $('input[name="64kbpsPlan"]:checked').val(),
		kbpsPlan128: $('input[name="128kbpsPlan"]:checked').val(),
		localPlan: $('input[name="localPlan"]:checked').val(),
		stdPlan: $('input[name="stdPlan"]:checked').val()
	}

	$.ajax({
		url: '/CustomarPannal/ServicesRegistration', // Replace 'YourController' with the name of your controller
		type: 'POST',
		contentType: 'application/json',
		data: data,
		dataType: 'json',
		contentType: 'application/x-www-form-urlencoded; charset=utf-8',
		success: function (response) {
			$('#fff23').html(
				`<div class="alert alert-warning alert-dismissible fade show" role="alert">
					<strong>Jhon doe!</strong> ${response}
					<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
				</div>`);
		},
		error: function (xhr, status, error) {
			$('#fff23').html(
				`<div class="alert alert-danger alert-dismissible fade show" role="alert">
                <strong>Jhon doe!</strong> You should check in on some of those fields below.
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>`
			);
		}
	});
});

$('#logoutBtn').click(function () {
	$.ajax({
		url: '/YourController/logOut', 
		type: 'GET',
		success: function () {
			location.reload();
		},
		error: function (xhr, status, error) {
			console.error(error); 
		}
	});
});



