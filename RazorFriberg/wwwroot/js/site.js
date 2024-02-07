// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Alerts
function SubmitChanges() {
    alert("Ändringar sparade!");
}
function SubmitNewCar() {
    alert("Bil inlagd i system!");
}
function SubmitNewCustomer() {
    alert("Kund inlagd i system!");
}
function RemovedCar() {
    alert("Bil borttagen!");
}
function RemovedCustomer() {
    alert("Kund borttagen!");
}
function RemovedRent() {
    alert("Uthyrning borttagen!");
}
// Edit car/customer buttons
$(document).ready(function () {
    $('#submit-btn').hide();
    $('input').change(function (e) {
        if ($('#brand').val() && $('#model').val() && $('#price').val()) {
            $('#submit-btn').show();
        }
    });

    $('#submit-customer').hide();
    $('input').change(function (e) {
        if ($('#fname').val() && $('#lname').val() && $('#email').val() && $('#pword').val()) {
            $('#submit-customer').show();
        }
    });
});

