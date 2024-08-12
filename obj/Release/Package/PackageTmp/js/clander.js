
$(function () {

    /*	c1*/

    $("#from").datepicker({
        minDate: 0,
        dateFormat: 'mm/dd/yy',
        orientation: "auto",
        changeMonth: false,
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#to").datepicker("option", "minDate", selectedDate);

        },
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay").html(weekday[dayString.getDay()]);
            $("#sDate").html(datearray[1]);
            $("#sMonth").html(month[dayString.getMonth()])
            $("#sYear").html(datearray[2])

            $('#to').focus(200);

        }

    });


    $("#to").datepicker({
        defaultDate: "+1w",
        dateFormat: 'mm/dd/yy',
        changeMonth: false,
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        //onClose: function (selectedDate) {
        //    $("#from").datepicker("option", "maxDate", selectedDate);

        //}
        //,
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay1").html(weekday[dayString.getDay()]);
            $("#sDate1").html(datearray[1]);
            $("#sMonth1").html(month[dayString.getMonth()])
            $("#sYear1").html(datearray[2])
            $('#adult').focus();

        }

    });

    /*	c2*/
    $("#from1").datepicker({
        minDate: 0,
        dateFormat: 'mm/dd/yy',
        changeMonth: false,
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#to1").datepicker("option", "minDate", selectedDate);
        },
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay11").html(weekday[dayString.getDay()]);
            $("#sDate11").html(datearray[1]);
            $("#sMonth11").html(month[dayString.getMonth()])
            $("#sYear11").html(datearray[2])
            $('#to1').focus(200);


        }

    });

    $("#to1").datepicker({
        defaultDate: "+1w",
        changeMonth: false,
        dateFormat: 'mm/dd/yy',
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#from1").datepicker("option", "maxDate", selectedDate);
        }
        ,
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay2").html(weekday[dayString.getDay()]);
            $("#sDate2").html(datearray[1]);
            $("#sMonth2").html(month[dayString.getMonth()])
            $("#sYear2").html(datearray[2])
            $('#select_room').focus();
        }

    });

    /*	c3*/

    $("#from2").datepicker({
        minDate: 0,
        changeMonth: false,
        dateFormat: 'mm/dd/yy',
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#to2").datepicker("option", "minDate", selectedDate);
        },
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay3").html(weekday[dayString.getDay()]);
            $("#sDate3").html(datearray[1]);
            $("#sMonth3").html(month[dayString.getMonth()])
            $("#sYear3").html(datearray[2])
            $('#to2').focus(200);


        }

    });

    $("#to2").datepicker({
        defaultDate: "+1w",
        dateFormat: 'mm/dd/yy',
        changeMonth: false,
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#from2").datepicker("option", "maxDate", selectedDate);
        }
        ,
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay33").html(weekday[dayString.getDay()]);
            $("#sDate33").html(datearray[1]);
            $("#sMonth33").html(month[dayString.getMonth()])
            $("#sYear33").html(datearray[2])
            $('#select_room2').focus(200);
        }

    });







    /*	c4*/

    $("#from4").datepicker({
        minDate: 0,
        changeMonth: false,
        dateFormat: 'dd/mm/yy',
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#to4").datepicker("option", "minDate", selectedDate);
        },
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay3").html(weekday[dayString.getDay()]);
            $("#sDate3").html(datearray[1]);
            $("#sMonth3").html(month[dayString.getMonth()])
            $("#sYear3").html(datearray[2])
            $('#to4').focus(200);


        }

    });

    $("#to4").datepicker({
        defaultDate: "+1w",
        dateFormat: 'dd/mm/yy',
        changeMonth: false,
        numberOfMonths: 1,
        prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $("#from4").datepicker("option", "maxDate", selectedDate);
        }
        ,
        onSelect: function (selectedDate) {
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";

            var weekday = new Array();
            weekday[0] = "Sun";
            weekday[1] = "Mon";
            weekday[2] = "Tue";
            weekday[3] = "Wed";
            weekday[4] = "Thu";
            weekday[5] = "Fri";
            weekday[6] = "Sat";


            var datearray = selectedDate.split('/');


            var dayString = new Date(selectedDate);

            $("#sDay33").html(weekday[dayString.getDay()]);
            $("#sDate33").html(datearray[1]);
            $("#sMonth33").html(month[dayString.getMonth()])
            $("#sYear33").html(datearray[2])
            $('#adult').focus(200);
        }

    });






});
