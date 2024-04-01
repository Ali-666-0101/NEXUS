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
        //hourlyPlan: $('input[name="hourlyPlan"]:checked').val(),
        //kbpsPlan28: $('input[name="28kbpsPlan"]:checked').val(),
        //kbpsPlan56: $('input[name="56kbpsPlan"]:checked').val(),
        //broadbandHourlyPlan: $('input[name="broadbandHourlyPlan"]:checked').val(),
        //kbpsPlan64: $('input[name="64kbpsPlan"]:checked').val(),
        //kbpsPlan128: $('input[name="128kbpsPlan"]:checked').val(),
        //localPlan: $('input[name="localPlan"]:checked').val(),
        //stdPlan: $('input[name="stdPlan"]:checked').val()
        hourlyPlan: $('input[name="dialUpHourlyPlan"]:checked').val(),
        kbpsPlan28: $('input[name="dialUp28kbpsPlan"]:checked').val(),
        kbpsPlan56: $('input[name="dialUp56kbpsPlan"]:checked').val(),
        broadbandHourlyPlan: $('input[name="broadbandHourlyPlan"]:checked').val(),
        kbpsPlan64: $('input[name="broadband64kbpsPlan"]:checked').val(),
        kbpsPlan128: $('input[name="broadband128kbpsPlan"]:checked').val(),
        localPlan: $('input[name="landlineLocalPlan"]:checked').val(),
        stdPlan: $('input[name="landlineStdPlan"]:checked').val()
    }

    $.ajax({
        url: '/CustomarPannal/ServicesRegistration',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data), // Serialize the data to JSON format
        dataType: 'json',
        success: function (response) {
            $('#fff23').html(
                `<div class="alert alert-warning alert-dismissible fade show" role="alert">
                    <strong>Jhon doe!</strong> ${response}
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>`
            );
            $('#flush-collapseOne').collapse('hide');
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
		url: '/CustomarPannal/logOut', 
		type: 'GET',
		success: function () {
			window.location.reload();
		},
		error: function (xhr, status, error) {
			console.error(error); 
		}
	});
});


//for monthly payment

	// Attach change event handler to the select element
	$("#ServiceId2").on('change', function () {
		// Get the value of the select element
		let connectionID = $(this).val();

		// Hide all connection sections
		$("#DailUp2, #BroadbandConnection2, #LandLineConnection2").hide();
		console.log(connectionID)
		// Show the selected connection section based on the value
		if (connectionID === '1') {
			$("#Pay").val("50");
			
			
		} else if (connectionID === '2') {
			$("#Pay").val("100");


		} else if (connectionID === '3') {
			$("#Pay").val("150");

		}
	});




 
        // Add a click event listener to the submit button
$('#submitButton').click(function (event) {
    event.preventDefault();

    var formData = {
        UserName: $('#UN').val(),
        Email: $('#Email').val(),
        ServiceName: $('#ServiceId2 option:selected').text(),
        PaymentAmmount: $('#Pay').val()
    };

    $.ajax({
        type: 'POST',
        url: '/CustomarPannal/savePayment',
        data: formData, // Sending form data directly
        success: function (response) {
            $('#flush-collapseFive').collapse('hide');
            // Show Bootstrap alert upon successful insertion
            $('#fff23').html(
                `<div class="alert alert-warning alert-dismissible fade show" role="alert">
                    <strong>Jhon doe!</strong> ${response}
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>`
            );
        },
        error: function (xhr, status, error) {
            // Show Bootstrap alert upon error
            $('#alertContainer').html('<div class="alert alert-danger alert-dismissible fade show" role="alert">Error occurred. Please try again.<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>');
        }
    });
});



$(document).ready(function () {
    // Make AJAX request to fetch payment data
    $.ajax({
        type: 'GET',
        url: '/CustomarPannal/getPaymentByid',
        success: function (data) {
            // Iterate over each payment entry and append to table
            $.each(data, function (index, payment) {
                $('#paymentTable tbody').append(`
                        <tr>
                            <th scope="row">${index + 1}</th>
                            <td>${payment.userName}</td>
                            <td>${payment.email}</td>
                            <td>${payment.serviceName}</td>
                            <td>${payment.paymentAmmount}</td>
                        </tr>
                    `);
            });
        },
        error: function (xhr, status, error) {
            console.error('Error fetching payment data:', error);
        }
    });
});


$(document).ready(function () {
    $.ajax({
        url: '/CustomarPannal/GetHaveServices', // Replace 'ControllerName' with your actual controller name
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            // Iterate through the response data and populate table rows
            $.each(response, function (index, service) {
                var row = '<tr>' +
                    '<th scope="row">' + (index + 1) + '</th>' +
                    '<td>' + service.ServiceName + '</td>' +
                    '<td>' + service.PackageName + '</td>' +
                    '<td>' + service.Rate + '</td>' +
                    '</tr>';
                $('#servicesTable tbody').append(row);
            });
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
});

