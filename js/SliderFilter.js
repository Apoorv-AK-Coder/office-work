
// ============================================================FILTERING STARTS=============================================
//$(document).ready(function () {        TO BE USED ON RESULT PAGE TO LOAD DEFAULT
//    var min = 0;
//    var max = 10000;
//    $(function () {
//        min = $("#hdnMinCost").val();
//        max = $("#hdnMaxCost").val();
//        SetSlider();
//        min = 0;
//        max = 1440;
//        SetSliderDepart();
//        min = 0;
//        max = 1440;
//        SetSliderReturn();
//        min = 0;
//        max = 3000;
//        SetSliderOutDuration();
//        if ($("#hdnIsReturn").val() == 'true')
//            SetSliderInDuration();
//    });

//});
function SetSlider() {
    //debugger;
    $("#demo-slider-container").slider({
        
        range: true,
        min: parseFloat(min),
        max: parseFloat(max),
        step: 5,
        values: [parseFloat(min), max],
        stop: function (event, ui) {
            //debugger;
            var start = parseInt(ui.values[0]);
            var end = parseInt(ui.values[1]);

            $("#divSelectedStart").html(ui.values[0]);
            $("#divSelectedEnd").html(ui.values[1]);
            //MasterFilter();
            CostFilter();
        },
        slide: function (event, ui) {
            if ((ui.values[0] + 5) >= ui.values[1]) {
                return false;
            }
        }
    });
    //Display the minimum and maximum values.

    $("#divSelectedStart").html(min);
    $("#divSelectedEnd").html(max);
}
function CostFilter() {

    var MinCost = parseInt($("#divSelectedStart").text());
    var MaxCost = parseInt($("#divSelectedEnd").text());
    var TotalCount = parseInt($("#hdnTotalCount").val())
    x = TotalCount;
    var DivId = "";
    var FltCost = 0;
    for (var jCost = 0; jCost < TotalCount; jCost++) {
        DivId = $("#hdnId" + jCost).val();
        FltCost = parseInt($("#hdnTotalCost" + jCost).val());
        if (MinCost <= FltCost && FltCost <= MaxCost) {
            $("#" + DivId).show();
            x = x + 1;
        }
        else {
            $("#" + DivId).hide();
            x = x - 1;
        }
    }
    //document.getElementById('count').innerHTML = x / 2;

}
//function SetSlider() {

//    //Intialize the slider
//    $("#demo-slider-container").slider({
//        range: true,
//        min: parseFloat(min),
//        max: parseFloat(max),
//        step: 5,
//        values: [parseFloat(min), max],
//        slide: function (event, ui) {
//            //debugger;
//            var start = parseInt(ui.values[0]);
//            var end = parseInt(ui.values[1]);

//            $("#divSelectedStart").html(ui.values[0]);
//            $("#divSelectedEnd").html(ui.values[1]);
//            //MasterFilter();
//            CostFilter();
//        }
//    });
//    //Display the minimum and maximum values.

//    $("#divSelectedStart").html(min);
//    $("#divSelectedEnd").html(max);
//}
//function CostFilter() {


//    var MinCost = parseInt($("#divSelectedStart").text());
//    var MaxCost = parseInt($("#divSelectedEnd").text());
//    var TotalCount = parseInt($("#hdnTotalCount").val())

//    var DivId = "";
//    var FltCost = 0;
//    var x = TotalCount;
//    for (var jCost = 0; jCost < TotalCount; jCost++) {
//        DivId = $("#hdnId" + jCost).val();
//        FltCost = parseInt($("#hdnTotalCost" + jCost).val());
//        if (MinCost <= FltCost && FltCost <= MaxCost) {
//            $("#" + DivId).show();
//            x = x + 1;
//        }
//        else {

//            $("#" + DivId).hide();
//            x = x - 1;
//        }

//    }

//    document.getElementById('count').innerHTML = x/2;

//}

function SetSliderDepart() {
    //Intialize the slider
    debugger;
    $("#Depart-slider-container").slider({
        range: true,
        min: min,
        max: max,
        step: 5,
        values: [min, max],
        slide: function (event, ui) {
            var start = parseInt(ui.values[0]);
            var end = parseInt(ui.values[1]);
            $("#divSelectedStartDepart").html(SetOutStartTiming(ui.values[0]));
            $("#divSelectedEndDepart").html(SetOutStartTiming(ui.values[1]));
            TimeFilter("divSelectedStartDepart", "divSelectedEndDepart");
        }
    });
    $("#divSelectedStartDepart").html(SetOutStartTiming(min));
    $("#divSelectedEndDepart").html(SetOutStartTiming(max));
} // 
function TimeFilter(MinTimeDiv, MaxTimeDiv) {

    var OutFilterStart = ConvertInMinuts1(document.getElementById(MinTimeDiv).innerHTML);
    var OutFilterEnd = ConvertInMinuts1(document.getElementById(MaxTimeDiv).innerHTML);
    var OutTimingDivId = "";
    var OutTiming = "";
    var ConvertedTiming = 0;
    var TotalCount = parseInt($("#hdnTotalCount").val());
    var x = TotalCount;
    for (var j = 0; j < TotalCount; j++) {
        OutTimingDivId = $("#hdnId" + j).val();
        OutTiming = $("#hdnDepTime" + j).val();
        ConvertedTiming = ConvertInMinuts(OutTiming);
        if (OutFilterStart <= ConvertedTiming && ConvertedTiming <= OutFilterEnd) {
            $("#" + OutTimingDivId).show();
            x = x + 1;
        }
        else {
            $("#" + OutTimingDivId).hide();
            x = x - 1;
        }
    }
    //document.getElementById('count').innerHTML = x / 2;
}

function SetOutStartTiming(time) {

    var HMaster = 60;
    var TotalHoure = parseInt(time / HMaster);
    var TotalMinuts = time % HMaster

    var h = "";
    var m = "";
    if (TotalHoure <= 9) {
        h = "0" + TotalHoure.toString();
    }
    else {
        h = TotalHoure.toString();
    }
    if (TotalMinuts <= 9) {
        m = "0" + TotalMinuts.toString();
    }
    else {
        m = TotalMinuts.toString();
    }
    var fullStartText = h + ":" + m;
    return fullStartText;

}
function ConvertInMinuts(time) {
    time = time.trim();
    var TimeLength = time.length;
    if (TimeLength < 5) {
        //alert(TimeLength);
        // alert(time);
        time = "0" + time;
    }

    var H = time.substring(0, 2);
    var M = time.substring(3);

    var Hint = parseInt(H);
    var Mint = parseInt(M);
    var HMinuhts = Hint * 60;
    var Total = HMinuhts + Mint;
    return Total;
}
function ConvertInMinuts1(time) {
    time = time.trim();
    var H = time.substring(0, 2);
    var M = time.substring(3);

    var Hint = parseInt(H);
    var Mint = parseInt(M);
    var HMinuhts = Hint * 60;
    var Total = HMinuhts + Mint;
    return Total;
}


function SetSliderReturn() {
    //Intialize the slider
    $("#Return-slider-container").slider({
        range: true,
        min: min,
        max: max,
        step: 5,
        values: [min, max],
        slide: function (event, ui) {
            var start = parseInt(ui.values[0]);
            var end = parseInt(ui.values[1]);
            $("#divSelectedStartReturn").html(SetOutStartTiming(ui.values[0]));
            $("#divSelectedEndReturn").html(SetOutStartTiming(ui.values[1]));
            TimeFilterRet("divSelectedStartReturn", "divSelectedEndReturn");
        }
    });
    $("#divSelectedStartReturn").html(SetOutStartTiming(min));
    $("#divSelectedEndReturn").html(SetOutStartTiming(max));
       


}

function TimeFilterRet(MinTimeDiv, MaxTimeDiv) {

    var OutFilterStart = ConvertInMinuts1(document.getElementById(MinTimeDiv).innerHTML);
    var OutFilterEnd = ConvertInMinuts1(document.getElementById(MaxTimeDiv).innerHTML);
    var OutTimingDivId = "";
    var OutTiming = "";
    var ConvertedTiming = 0;
    var TotalCount = parseInt($("#hdnTotalCount").val());
    x = TotalCount;
    for (var j = 0; j < TotalCount; j++) {
        OutTimingDivId = $("#hdnId" + j).val();
        OutTiming = $("#hdnRetTime" + j).val();
        ConvertedTiming = ConvertInMinuts(OutTiming);
        if (OutFilterStart <= ConvertedTiming && ConvertedTiming <= OutFilterEnd) {
            $("#" + OutTimingDivId).show();
            x = x + 1;
        }
        else {
            $("#" + OutTimingDivId).hide();
            x = x - 1;
        }
    }
    //document.getElementById('count').innerHTML = x / 2;
}

function SetSliderOutDuration() {
    //Intialize the slider
    $("#DepartDuration-slider-container").slider({
        range: true,
        min: min,
        max: max,
        step: 5,
        values: [min, max],
        slide: function (event, ui) {
            var start = parseInt(ui.values[0]);
            var end = parseInt(ui.values[1]);
            $("#divSelectedStartDepartDuration").html(SetOutStartTiming(ui.values[0]));
            $("#divSelectedEndDepartDuration").html(SetOutStartTiming(ui.values[1]));
            DurationFilter("divSelectedStartDepartDuration", "divSelectedEndDepartDuration");
        }
    });
    $("#divSelectedStartDepartDuration").html(SetOutStartTiming(min));
    $("#divSelectedEndDepartDuration").html(SetOutStartTiming(max));
}
function DurationFilter(MinTimeDiv, MaxTimeDiv) {

    var OutFilterStart = ConvertInMinuts1(document.getElementById(MinTimeDiv).innerHTML);
    var OutFilterEnd = ConvertInMinuts1(document.getElementById(MaxTimeDiv).innerHTML);
    var OutTimingDivId = "";
    var OutTiming = "";
    var ConvertedTiming = 0;
    var TotalCount = parseInt($("#hdnTotalCount").val());
    x = TotalCount;
    for (var j = 0; j < TotalCount; j++) {
        OutTimingDivId = $("#hdnId" + j).val();
        OutTiming = $("#hdnDepDuration" + j).val();
        ConvertedTiming = ConvertInMinuts(OutTiming);
        if (OutFilterStart <= ConvertedTiming && ConvertedTiming <= OutFilterEnd) {
            $("#" + OutTimingDivId).show();
            x = x + 1;
        }
        else {
            $("#" + OutTimingDivId).hide();
            x = x - 1;
        }
    }
    //document.getElementById('count').innerHTML = x / 2;
}


function SetSliderInDuration() {

    $("#ReturnDuration-slider-container").slider({
        range: true,
        min: min,
        max: max,
        step: 5,
        values: [min, max],
        slide: function (event, ui) {
            var start = parseInt(ui.values[0]);
            var end = parseInt(ui.values[1]);
            $("#divSelectedStartReturnDuration").html(SetOutStartTiming(ui.values[0]));
            $("#divSelectedEndReturnDuration").html(SetOutStartTiming(ui.values[1]));
            DurationFilterRet("divSelectedStartReturnDuration", "divSelectedEndReturnDuration");
        }
    });
    $("#divSelectedStartReturnDuration").html(SetOutStartTiming(min));
    $("#divSelectedEndReturnDuration").html(SetOutStartTiming(max));
}
function DurationFilterRet(MinTimeDiv, MaxTimeDiv) {

    var OutFilterStart = ConvertInMinuts1(document.getElementById(MinTimeDiv).innerHTML);
    var OutFilterEnd = ConvertInMinuts1(document.getElementById(MaxTimeDiv).innerHTML);
    var OutTimingDivId = "";
    var OutTiming = "";
    var ConvertedTiming = 0;
    var TotalCount = parseInt($("#hdnTotalCount").val());

    for (var j = 0; j < TotalCount; j++) {
        OutTimingDivId = $("#hdnId" + j).val();
        OutTiming = $("#hdnRetDuration" + j).val();
        ConvertedTiming = ConvertInMinuts(OutTiming);
        if (OutFilterStart <= ConvertedTiming && ConvertedTiming <= OutFilterEnd) {
            $("#" + OutTimingDivId).show();
        }
        else {
            $("#" + OutTimingDivId).hide();
        }
    }
}

//==============================FILTER END=====================================================



