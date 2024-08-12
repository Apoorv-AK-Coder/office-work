

function ignoreNumeric(event) {
    var key = [event.keyCode || event.which];

    if ((key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32 || key == 08 || key == 09)) {


        return event.returnValue = true;
        //return true;
    }
    else {
        return event.returnValue = false;
        //return false;
    }
}

function NumericOnly(event) {
    var key = [event.keyCode || event.which];
    var keychar = String.fromCharCode([event.keyCode || event.which]);
    keventychar = keychar.toLowerCase();
    checkString = "0123456789";
    if ((key == null) || (key == 0) || (key == 8) ||
(key == 9) || (key == 13) || (key == 27)) {

        return event.returnValue = true;

    }
    else if (((checkString).indexOf(keychar) > -1)) {

        return event.returnValue = true;
    }
    else {
        return event.returnValue = false;
    }
}

function checkdata() {

    if ($("#flying_from").val() == "" || $("#flying_from").val().length < 3) {
        alert("Please Enter Destination!!");
        $("#flying_from").focus();
        return false;
    }

    if ($("#txtname").val() == "") {
        alert("Please Enter Name!!");
        $("#txtname").focus();
        return false;
    }
    if ($("#txtmail").val() == "") {
        alert("Please Enter Contact No!!");
        $("#txtmail").focus();
        return false;
    }

    if ($("#txtmail").val() == "") {
        alert("Please Enter Email Address!!");
        $("#txtmail").focus();
        return false;
    }

    else {
        passdata();
        return true;

    }
}



      

function toggle() {
    var ele = document.getElementById("toggleText");
    var text = document.getElementById("displayText");
    if (ele.style.display == "block") {
        ele.style.display = "none";

    }
    else {
        ele.style.display = "block";

    }
}


function passdata() {

    var dest = $("#flying_from").val();
    var from = $("#txtname").val();
    var no = $("#txtno").val();
    var mail = $("#txtmail").val();
    var param = {}; 
    param.dest = dest;
    alert(param);
    $.ajax({
        type: "POST",
        url: "tours.aspx/getdata",
        data: { dest: JSON.stringify(param) },
        contentType: "application/json; charset=utf-8",
       
        dataType: "json",
        success: function (response) {
            $("#Content").text(response.d);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}