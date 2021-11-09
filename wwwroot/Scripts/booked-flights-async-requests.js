/// <summary>
///     This method is fired by ajax unobtrusive as begin request, when we click on "Réserver" button, we make ajax request to server
///     to get details of selected flight by user as partialView and display it on the modal to leave user editing his flight
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
            window.location.href = '/Error/Index';
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
function onUpdateBookingSuccessRequest(data) {
    //If result is different '-1' then everything is good
    if (data.success != -1) {
        $('#Modal-Booking').modal("hide");

        //Show validation message
        Swal.fire({
            title: 'Modification réussie :)',
            text: 'La réservation à été modifiée, vous pouvez consulter les détails de votre vol.',
            icon: 'success',
            confirmButtonText: 'D\'accord'
        }).then((result) => {
            if (result.isConfirmed) {
                location.reload();
            }
        })
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
function onUpdateBookingFailureRequest(data) {
    //Clear form for new reservations
    $('#form-booking-flight').trigger("reset");

    //Hide modal from the eyes of the user
    $('#Modal-Booking').modal("hide");

    //Show failure message to the user
    Swal.fire(
        'Modification échouée :(',
        'Un problème est survenue lors de du traitement de la réservation, prière de re-essayer s\'il vous plait.',
        'error'
    );
}
