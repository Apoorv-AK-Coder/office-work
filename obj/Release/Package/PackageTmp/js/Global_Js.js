var TopSliderData = {
    "Data": [
        { Destiation: "Manila", Fare: "502", Path: "images/1.jpg" },
        { Destiation: "Delhi", Fare: "600", Path: "images/2.jpg" },
        { Destiation: "Dubi", Fare: "580", Path: "images/3.jpg" }
    ]
};

function BodyOnLoadFunction()
{
    var Req = { Company: "3517_CT", Type: "Header", PageType: "Home", };
    $.ajax({
        type: "POST",
        url: "GetGlobalData.asmx/GetImageForTopMenu",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(Req),
        responseType: "json",
        success: function (data) {

            Jdata = JSON.parse(data.d);
            var tot = Jdata.BannerUpload.length > Jdata.TopOfferFare.length ? Jdata.BannerUpload.length : Jdata.TopOfferFare.length;
            for (var i = 0; i < tot; i++) {
                $("#divTopSlider").append("<div><a href=''>" +
                                    "<img runat='server' src='" + Jdata.BannerUpload[i].ImagePath + "' alt=''> <span class='caption'>" +
                                        "<h2 class='offer'>" + Jdata.TopOfferFare[i].DesttoName + "</h2>" +
                                        "<span class='offerstart'>Offer Starting</span> <span class='starfrom'><span class='from1'>From</span> " +
                                        "<span class='fromprice'><i class='fa fa-gbp'></i>" + parseFloat(Jdata.TopOfferFare[i].GrandTotal).toFixed(0) + "</span></span> <span class='flightsale'>Flight Sale</span>" +
                                        "<span class='limited'>Limited Availability</span>" +
                                    "</span>" +
                                "</a></div>");
            }
        },
        error: function (data) { }
    });
}