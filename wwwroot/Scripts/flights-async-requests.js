/// <summary>
///     This method is fired by ajax unobtrusive as begin request, when we click on the button, before getting data and
///     display it on the page, this function will be fired to make validations before sending request to the server
/// </summary>
/// <returns>Boolean indicates whether we send request to server or not, if not : then we show error got from client side</returns>
function onGetAllFlightsBeginRequest() {
    //Get main search form fields values
    var startAirport = $('#StartAirport').val();
    var endAirport = $('#EndAirport').val();
    var travelDate = $('#TravelDate').val();

    //Create an empty array to hold errors if exist
    var errors = [];

    //If user selects a travel date, then we must verify if that date is superior or equel to current date or not
    if (travelDate != "") {
        //Get current date and format it to (yyyy-MM-dd) to make it match for travel date in the input
        var currentDate = new Date();
        var currentDateFormatted = currentDate.getFullYear() + "-" + (currentDate.getMonth() + 1) + "-" + currentDate.getDate();

        //Convert entered travel date and current date, and check if current is inferior than travel date than throw error
        if (new Date(travelDate) < new Date(currentDateFormatted)) {
            //Push the error to the array created above
            errors.push("La date doit etre supérieure ou égale à la date courante.");
        }
    }

    //If user selects start airport and end airport, then we verify if airports are equal
    if (startAirport != "" && endAirport != "") {
        //If airports are the same than it's not logic, we must throw a new error to notify user the he can't travel to the same airport
        if (endAirport == startAirport) {
            errors.push("Les aeroports de départ et d'arrivée ne peuvent pas être identiques.");
        }
    }

    //Finally we check if "errors" array has some exception thrown, if yes then show them into a div to make them visible for user
    if (errors.length > 0) {
        $("#div-errors").html("");

        for (var i = 0; i < errors.length; i++) {
            $("#div-errors").append("<span class='text-danger'>* " + errors[i] + "</span><br/>");
        }

        //return false to stop request to be sent to the server, because an errors exist, have to be resolved
        return false;
    }
    else { //Otherwise, no errors exist, then we make request to the server, we will have got a data as partialView to show in modal
        //Clean the div which holds the errors, because no errors in this case
        $("#div-errors").html("");

        //Show a loading style to notify user that the data is comming from the server
        $("#flights-container").LoadingOverlay("show", {
            background: "rgba(200, 200, 200, 0.5)"
        });
    }
}

/// <summary>
///     This method is fired by ajax unobtrusive as complete request, that means when Begin function completed, then this method will fire.
///     We used this method, to hide loading style after data get displayed on the page  
/// </summary>
function onGetAllFlightsCompleteRequest() {
    $("#flights-container").LoadingOverlay("hide", true);
}

/// <summary>
///     This method is fired by ajax unobtrusive as begin request, when we click on "Réserver" button, we make ajax request to server
///     to get details of selected flight by user as partialView and display it on the modal to leave user booking his flight
/// </summary>
function onShowReservationFormSuccessRequest(url) {
    //On button click, we get the url in data-url property set on the button itself and we make ajax request to server
    $.get(url).done(function (data) {
        //If result is equal to '0' then user is not authenticated (Look at the code behind to understand)
        if (data.success == 0) {
            Swal.fire(
                'Authentification !',
                'Vous etes sur le point de réserver un vol, vous devez vous connecter pour continuer l\'opération.',
                'warning'
            );
        }
        //If result is '-1' then data is not found on the database, some malicious person has altered the id in the inspect element
        //Then we redirect user to error page 404 (Security level)
        else if (data.success == -1) {
            //return to 404 error page
            window.location.href = '@Url.Action("Index", "Error")';
        }
        //Otherwise, we get the data from server and attach it to modal
        else {
            $('#Modal-Booking').find(".modal-dialog").html(data);
            $('#Modal-Booking').modal();
        }
    });
}

/// <summary>
///     This method is fired by ajax unobtrusive as success request, that means when operation is succeeded, this methid will be fired.
///     Here we show a message of successful booking whene the operation of flight reservation is succeeded
/// </summary>
function onCreateBookingSuccessRequest(data) {
    //If result is different '-1' then everything is good
    if (data.success != -1) {
        //Clear reservation form to give possibility of creating another reservation without getting old data on the form
        $('#form-booking-flight').trigger("reset");

        //Show validation message
        Swal.fire(
            'Réservation réussie :)',
            'La réservation à été créee, vous pouvez la consulter ou la modifier librement.',
            'success'
        );

        //hide modal to return to flight on the main page
        $('#Modal-Booking').modal("hide");
    }
    //Otherwise, Id sent to database was not found so we redirect user to error page 404
    else {
        //return to 404 error page
        window.location.href = '@Url.Action("Index", "Error")';
    }
}

/// <summary>
///     This method is fired by ajax unobtrusive as failure request, that means when operation is failed, this methid will be fired.
///     Here we show a message of failure booking when and probleme occured at server level
/// </summary>
function onCreateBookingFailureRequest(data) {
    //Clear form for new reservations
    $('#form-booking-flight').trigger("reset");

    //Hide modal from the eyes of the user
    $('#Modal-Booking').modal("hide");

    //Show failure message to the user
    Swal.fire(
        'Réservation échouée :(',
        'Un problème est survenue lors de du traitement de la réservation, prière de re-essayer s\'il vous plait.',
        'error'
    );
}

