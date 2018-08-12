$(document).ready(function () {

});

//Validate Company Form
$('#btnSubmit').click(function () {
    var valForm=true;

    var compName = $('#CompanyName').val();
    var primaryMail = $('#PrimaryMailID').val();
    var primaryPhone = $('#PrimaryPhoneNo').val();

    if (compName.trim() == '') {
        $('#ErrMsgCompName').show();
        $('#CompanyName').addClass('form-control is-invalid');
        $("#ErrMsgCompName").html('** Company Name is Required');
        valForm = false;
    }
    if (primaryMail.trim('') == '') {
        $('#ErrMsgPrimaryMail').show();
        $("#ErrMsgPrimaryMail").html('** Primay Mail is Required');
        valForm = false;
    }
    if (primaryPhone.trim('') == '') {
        $('#ErrMsgPrimaryPhone').show();
        $("#ErrMsgPrimaryPhone").html('** Primary Phone Required');
        valForm = false;
    }
    if(valForm) {
        $('#ErrMsgCompName').hide();
        $('#ErrMsgPrimaryMail').hide();
        $('#ErrMsgPrimaryPhone').hide();
    }
    return valForm;
});
$("#CompanyName").keyup(function () {
    var compName = $('#CompanyName').val();
    if (compName.trim() != '') {
        $('#ErrMsgCompName').hide();
    }
});
$("#PrimaryMailID").keyup(function () {
    var compName = $('#PrimaryMailID').val();
    if (compName.trim() != '') {
        $('#ErrMsgPrimaryMail').hide();
    }
});
$("#PrimaryPhoneNo").keyup(function () {
    var compName = $('#PrimaryPhoneNo').val();
    if (compName.trim() != '') {
        $('#ErrMsgPrimaryPhone').hide();
    }
});
function toggleCheckbox(element) {
    if (element.checked) {
        $('#ShippingAddress').val($('#BillingAddress').val());
        $('#ShippingAddress1').val($('#BillingAddress1').val());
        $('#ShippingCity').val($('#BillingCity').val());
        $('#ShippingState').val($('#BillingState').val());
        $('#ShippingCountry').val($('#BillingCountry').val());
        $('#ShippingPincode').val($('#BillingPincode').val());
    }
    if (!element.checked)
    {
        $('#ShippingAddress').val("");
        $('#ShippingAddress1').val("");
        $('#ShippingCity').val("");
        $('#ShippingState').val("");
        $('#ShippingCountry').val("");
        $('#ShippingPincode').val("");
    }
}