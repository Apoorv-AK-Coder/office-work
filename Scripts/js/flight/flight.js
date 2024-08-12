var intRegex = /^\d/;
var cntAddDiv = 2;
var IsMultiCity = false;
var totalMultiCity = 0;
var tabindexx = 7;
var urlis = window.location.pathname.replace('/', '');


function __highlight(s, t) {
    var matcher = new RegExp("(" + $.ui.autocomplete.escapeRegex(t) + ")", "ig");
    var strHTML = "<u>$1</u>";
    return s.replace(matcher, strHTML);
}


$(document).ready(function () {
    var totMonthToShow = 0;
    if ($(window).width() > 767) {
        totMonthToShow = 1;
        $(".flight-heading-text").hide();
    }
    else {
        totMonthToShow = 1;
        $(".flight-heading-text").show();
        $("#lbl_fromcity").hide();
        $("#lbl_tocity").hide();
        $("#lbl_date").hide();
        $("#lbl_returndate").hide();
        $("#txtFlyFrom").attr("placeholder", "Flying from City / Airport");
        $("#txtFlyTo").attr("placeholder", "Flying to City / Airport");
        if ($(window).width() < 767) {
            $("#txtFlyFrom_1").attr("placeholder", "Flying from City / Airport");
            $("#txtFlyTo_1").attr("placeholder", "Flying to City / Airport");
        }
    }

    /* TravelWebUI and BootStrap*/
    $("#myModal").addClass({ 'padding-right': '17px' });
    $('.modal-backdrop fade in').addClass({ 'height': '657px' });

    $(".flights-advanced-options").click(function () {
        $(".flights-advanced-options-content").toggle('slow');
        $(".flights-advanced-options").toggleClass("chevron-up chevron-down");
    });

        
    /* TravelWebUI end*/


    /* Index start*/
    //$('.carousel').each(function () {
    //    $(this).carousel({
    //        interval: 2000,
    //        cycle: true
    //    });
    //});
    /* Index end*/
    /* Start --Review Feedback/ Product Review/ Group Travel*/

       
    /*End --Review Feedback/ Product Review/ Group Travel*/


    /* _IndexSearch start*/
    $('#from').datepicker({
        numberOfMonths: totMonthToShow,
        dateFormat: 'dd/mm/yy',
        minDate: 0,
        maxDate: "+11M +26D",
        beforeShow: function (input, inst) {
            if ($(window).width() < 767) {
                var cal = inst.dpDiv;
                var top = $(this).offset().top + $(this).outerHeight();
                var left = $(this).offset().left;
                setTimeout(function () {
                    cal.css({
                        'top': top,
                        'left': left
                    });
                }, 10);
                $("html, body").animate({ scrollTop: $('#from').offset().top - 10 }, 1000);
            }
        },
        onSelect: function (selectedDate) {
            //$(this).valid();
            var dtret = $('#from').datepicker('getDate');
            dtret.setDate(dtret.getDate() + 1);
            var dtret_min = $('#from').datepicker('getDate');
            dtret_min.setDate(dtret_min.getDate());
            $("#to").datepicker("option", "minDate", dtret_min);
            $("#to").datepicker().datepicker("setDate", dtret);
            $("#to").val("");
            $("#from_1").datepicker("option", "minDate", dtret_min);
            $("#from_1").datepicker().datepicker("setDate", dtret);
            $("#txtFlyFrom_1").focus(0);

            var icnt_dt = 2;
            for (icnt_dt = 2; icnt_dt < parseInt(cntAddDiv) ; icnt_dt++) {
                var date_before = $('#from_' + (parseInt(icnt_dt) - 1) + '').datepicker('getDate');
                date_before.setDate(date_before.getDate() + 1);
                $('#from_' + icnt_dt + '').datepicker("option", "minDate", $('#from_' + (parseInt(icnt_dt) - 1) + '').val());
                $('#from_' + icnt_dt + '').datepicker().datepicker("setDate", date_before);
            }
            $("#to").focus(0);
        }
    });
    $('#from').datepicker("option", "monthNames", ["Depart (Jan)", "Depart (Feb)", "Depart (Mar)", "Depart (Apr)", "Depart (May)", "Depart (Jun)", "Depart (Jul)", "Depart (Aug)", "Depart (Sep)", "Depart (Oct)", "Depart (Nov)", "Depart (Dec)"]);
    $("#from").datepicker().datepicker("setDate", new Date());
    $('#from').datepicker('widget').wrap('<div class="datepicker-custom"/>');


    $("#to").datepicker({
        numberOfMonths: totMonthToShow,
        minDate: 0,
        maxDate: "+11M +26D",
        dateFormat: 'dd/mm/yy',
        beforeShow: function (input, inst) {
            if ($(window).width() < 767) {
                var cal = inst.dpDiv;
                var top = $(this).offset().top + $(this).outerHeight();
                var right = $(this).offset().right;
                setTimeout(function () {
                    cal.css({
                        'top': top,
                        'right': right
                    });
                }, 10);
                $("html, body").animate({ scrollTop: $('#to').offset().top - 10 }, 1000);
            }
        },
        onSelect: function (selectedDate) {
            //$(this).valid();
        }
    });

    $('#to').datepicker("option", "monthNames", ["Return (Jan)", "Return (Feb)", "Return (Mar)", "Return (Apr)", "Return (May)", "Return (Jun)", "Return (Jul)", "Return (Aug)", "Return (Sep)", "Return (Oct)", "Return (Nov)", "Return (Dec)"]);


    //right: 10px !important;

});

$(window).load(function () {
    if ($(window).width() < 767) {

        if ($("#return").prop('checked')) {           
            $("#to").prop('disabled', false);
            $("#to").prev("input[type='text']").removeAttr("readonly");                 
            $("#return").attr('checked', true);
            $("#oneway").attr('checked', false);
            $('#to').datepicker("option", "minDate", $('#from').val());            
        }
        if ($("#oneway").prop('checked')) {            
            $("#to").val("");           
            $("#oneway").attr('checked', true);
            $("#return").attr('checked', false);
        }        
    }
    else {        

        if ($("#return").prop('checked')) {            
            $("#to").prop('disabled', false);
            $("#to").prev("input[type='text']").removeAttr("readonly");            
            $("#return").attr('checked', true);
            $("#oneway").attr('checked', false);            
            $('#to').datepicker("option", "minDate", $('#from').val());            
        }
        if ($("#oneway").prop('checked')) {            
            $("#to").val("");            
            $("#oneway").attr('checked', true);
            $("#return").attr('checked', false);            
        } 
    }
});

function Throttle(f, delay) {
    var timer = null;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timer);
        timer = window.setTimeout(function () {
            f.apply(context, args);
        },
        delay || 500);
    };
}


