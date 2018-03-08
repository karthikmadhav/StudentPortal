//Load Image on Page Load
document.onreadystatechange = function () {
    var state = document.readyState
    if (state == 'interactive') {
        document.getElementById('contents').style.visibility = "hidden";
    } else if (state == 'complete') {
        setTimeout(function () {
            document.getElementById('interactive');
            document.getElementById('load').style.visibility = "hidden";
            document.getElementById('contents').style.visibility = "visible";
        }, 500);
    }
}

$(document).ready(function () {
    spinFadeOut();
    $("#viewRole").hide();
    $("#NewRole").hide();
});

function spinFadeOut() {
   // $(".overlay").fadeOut(1500);

}

function spinFadeIn() {
    //$(".overlay").fadeIn();
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
//Load Partial View in Role for Edit Page 
function editRoleDetails(roleID) {
    $("#viewRole").show();
    $("#NewRole").hide();
    var RoleID = roleID;
    $.ajax({
        type: "POST",
        url: "/MasterSettings/EditRoleDetails",
        data: '{id: "' + RoleID + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $("#viewRole").html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
function addNewRole() {
    $("#NewRole").show();
    $("#viewRole").hide();
    $.ajax({
        type: "GET",
        url: "/MasterSettings/NewRole",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $("#NewRole").html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
 
}