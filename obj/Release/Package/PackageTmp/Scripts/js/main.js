$(document).ready(function () {
    // back to top //
    var offset = 250;
    var duration = 1000;
    jQuery(window).scroll(function () {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.back-to-top').fadeIn(duration);
        } else {
            jQuery('.back-to-top').fadeOut(duration);
        }
    });

    jQuery('.back-to-top').click(function (event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    })
    // back to top  end//
    $('ul.nav li.dropdown').hover(function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeIn(100);
    }, function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeOut(100);
    });




    var urlis = window.location.pathname.replace('/', '');

    if (urlis == 'flights') {
        $("#li-home").removeClass('active');
        $("#li-flights").addClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    } else if (urlis == 'vacations') {
        $("#li-home").removeClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").addClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    } else if (urlis == 'contact-us') {
        $("#li-home").removeClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").addClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    } else if (urlis == 'about-us') {
        $("#li-home").removeClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").addClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    } else if (urlis == '') {
        $("#li-home").addClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    } else {
        $("#li-home").removeClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").addClass('active');
    }

    if (urlis.toLowerCase().indexOf("flights/") == 0) {
        $("#li-home").removeClass('active');
        $("#li-flights").addClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    }
    if (urlis.toLowerCase().indexOf("offers/") == 0) {
        $("#li-home").removeClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").removeClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").addClass('active');
        $("#li-supports").removeClass('active');
    }
    if (urlis.toLowerCase().indexOf("vacations/") == 0) {
        $("#li-home").removeClass('active');
        $("#li-flights").removeClass('active');
        $("#li-vacations").addClass('active');
        $("#li-contact-us").removeClass('active');
        $("#li-about-us").removeClass('active');
        $("#li-more").removeClass('active');
        $("#li-supports").removeClass('active');
    }

    $(".deals-block, .deals-row, .btm-deals-row, .static-deal").click(function (e) {

        var Airline = null; var flyClass = null;
        $("#spn_flyfrom_popup").html(this.dataset.fromName);
        $("#spn_flyfrom_popup_1").html(this.dataset.fromName);
        $("#spn_flyto_popup").html(this.dataset.toName);
        $("#spn_flyto_popup_1").html(this.dataset.toName);
        $("#spn_depart_date_popup").html(this.dataset.fromDate);
        $("#spn_depart_date_popup_1").html(this.dataset.fromDate);
        $("#spn_return_date_popup").html(this.dataset.toDate);
        $("#spn_trvaller").html(1 + ' Passenger');
        if (typeof this.dataset.airline !== "undefined") {
            Airline = this.dataset.airline;
        }
        if (typeof this.dataset.flyclass !== "undefined") {
            flyClass = this.dataset.flyclass;
        } else { flyClass = 'Y';}

        if (this.dataset.toDate != '') {
            $('#datebet').show();

            // $('.mid-oneway').show();
            //$("#spn_depart_date_popup").html('');
        }
        else {
            $('#datebet').hide();
        }
        $("#openPopup_multicity").hide();
        $("#searchModal").show();
        var url = "/flights/flight-search-deals?trip=" + this.dataset.triptype + "&src=" + this.dataset.fromCode + "&dst=" + this.dataset.toCode + "&fromdt=" + this.dataset.fromDate + "&todt=" + this.dataset.toDate + "&flyclass=" + flyClass + "&PrefAirline=" + Airline;
        // alert('url- ' + url);
        window.location.href = url;
    });


});

//function isValidEmailAddress(emailAddress) {
//    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
//    return pattern.test(emailAddress);
//};

function checklan() {
    var pass1 = $('#txtMobile').val();
    if (pass1.length > 15) {
        $('#txtMobile').val(pass1.substring(0, (15)));
        return;
    }
}

function signupMobile() {
    window.scrollTo(0, 0);
    var Mobile = $('#txtMobile').val();
    if (Mobile == "") { JAlert('Enter Mobile No', 'Error Message'); }
    var filterm = /[0-9 -()+]+$/;
    if (!filterm.test(Mobile)) {
        jAlert('Please Enter Valid Mobile No!', 'Error Message');
        $('#txtMobile').focus();
        return false;
    }

    $.ajax({
        url: "../handlers/instant-call-back-handler.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { 'ContactNo': Mobile, 'from': 'default', 'coupon': '', 'discount': '' },
        responseType: "json",
        success: SuccessSubmit,
        error: SuccessSubmit
    });
    return false;
}

function SuccessSubmit(result) {
    jAlert('Thanks for your Submission with US', 'Success');
    $('.instant-call').hide();
    localStorage.setItem('isClosedMobile', 'true');
    var date = new Date();
    var minutes = 120;//cookies will expire in next 10 Minut
    date.setTime(date.getTime() + (minutes * 60 * 1000));
    $.cookie("isClosedMobile", "true", { expires: date });
}

function signupnow() {
    var Email = $('#txtMail').val();
    if (Email == "") {
        jAlert('Please Enter Email ID', 'Error Message');
        return false;
    }
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!filter.test(Email)) {
        jAlert('Please Enter Valid Email ID !', 'Error Message');

        $('#txtMail').focus();
        return false;
    }
    $.ajax({
        url: "../handlers/subscribehandler.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { 'EmaiId': Email, 'from': 'default' },
        responseType: "json",
        success: OnCompleteSub,
        error: OnFailSub
    });
    $('.call-popup').hide();
    return false;
}

function signupcustomer() {
    var Email = $('#txtCustomerEmail').val();
    if (Email == "") {
        jAlert('Please Enter Email ID', 'Error Message');
        return false;
    }
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!filter.test(Email)) {
        jAlert('Please Enter Valid Email ID !', 'Error Message');

        $('#txtCustomerEmail').focus();
        return false;
    }
    $.ajax({
        url: "../handlers/subscribehandler.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { 'EmaiId': Email, 'from': 'default' },
        responseType: "json",
        success: OnCompleteSub,
        error: OnFailSub
    });
    return false;
}
function OnCompleteSub(result) {    
    if (result == 1) {
        jAlert('Thanks for your subscription with LuxFares.com', 'Subscribed');
    }
    else {
        jAlert('You have already subscribed with LuxFares.com', 'Subscribed'); 
    }
    $('#txtCustomerEmail').val('');
}
function OnFailSub(result) {
    jAlert('Thanks for your subscription with LuxFares.com', 'Subscribed');
    $('#txtCustomerEmail').val('');
}
/* --End Home Page Script*/





