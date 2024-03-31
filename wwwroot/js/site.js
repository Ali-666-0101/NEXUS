
/// <reference path="../lib/jquery/dist/jquery.js" />

$(document).ready(function () {
	function getFormData() {
		var formData = {
			name: $('#inputEmail4').val(),
			email: $('#inputPassword4').val(),
			phone: $('#inputPhone').val(),
			address: $('#inputAddress').val(),
			detailAddress: $('#inputAddress2').val(),
			city: $('#inputCity').val(),
			serviceId: $('#ServiceId').val(),
			zip: $('#inputZip').val(),
			hourlyPlan: $('input[name="hourlyPlan"]:checked').val(),
			kbpsPlan28: $('input[name="28kbpsPlan"]:checked').val(),
			kbpsPlan56: $('input[name="56kbpsPlan"]:checked').val(),
			broadbandHourlyPlan: $('input[name="broadbandHourlyPlan"]:checked').val(),
			kbpsPlan64: $('input[name="64kbpsPlan"]:checked').val(),
			kbpsPlan128: $('input[name="128kbpsPlan"]:checked').val(),
			localPlan: $('input[name="localPlan"]:checked').val(),
			stdPlan: $('input[name="stdPlan"]:checked').val()
		};

		return formData;
	}


	console.log("javascript is runing");



})
$(document).ready(function () {
	$("#serviceBtn").click(function () {
		var formData = getFormData();

		$.ajax({
			url: '/CustomarPannal/ServicesRegistration', // Replace 'YourController' with the name of your controller
			type: 'POST',
			contentType: 'application/json',
			data: JSON.stringify(formData),
			success: function (response) {
				console.log(response); // Handle success response
			},
			error: function (xhr, status, error) {
				console.error(error); // Handle error
			}
		});
	});
});
