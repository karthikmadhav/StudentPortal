$(document).ready(function () {
    spinFadeOut();
});

function spinFadeOut() {
    $(".overlay").fadeOut(1500);

}

function spinFadeIn() {
    $(".overlay").fadeIn();
}

//Load Partial View in View Company Page 
function loadCompanyDetails(compId) {
    var customerId = compId;
    $.ajax({
        type: "POST",
        url: "/Company/CompanyDetails",
        data: '{Id: "' + customerId + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {

            $(".popmodal-body").html(response);
            $("#modal-default").modal('show')
            $(".overlay").hide();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}