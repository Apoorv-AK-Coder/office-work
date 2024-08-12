
function createFlexiList(Data, IsReturn, DeptDate, RetDate, SourceMedia,Symbol) {
    debugger;
    var _itineraryLenght = 0;
    var _IsReturnDisplay = 'none';
    if (IsReturn == true) {
        _IsReturnDisplay = 'block';
    }
    $("#divFlexiList").empty();
    //if (Data.Items == undefined) {
    //    _itineraryLenght = 0;
    //    $("#divFlexiList").append("No Record Found");
    //}
    if (Data.Items == undefined) {
        _itineraryLenght = 0;
        $("#divFlexiList").append("No Record Found");
    }
    else {
        _itineraryLenght = Data.Items.length;
    }
    if (_itineraryLenght > 0) {

        $rootTag = $("<div class='flexi-date-new'>");
        // if isReturn true
        if (IsReturn == "true") {

            // return sector(Inbound) head date start
            $flexiHead = $("<div class='t-heading'>");
            var $flexiHeadDiv1 = "<div class='head-days-first vnan'>" +
                                   " <div class='first-img'></div>" +
                                    " <div class='second-img'></div>" +
                                    //"<img src='/content/images/outbound-bottom.png' style='position: relative; top: -5px; right: -5px; ' alt='' />" +
                                    "<div class='in-txt'>Inbound</div>" +
                                    "<div class='out-txt'>Outbound</div>" +
                                 "</div>";
            ($flexiHead).append($flexiHeadDiv1);
            // bind back days header  "Mon Apr 11 2016"
            for (var i = -3; i <= -1; i++) {
                var _backDate = getFlexiDates(RetDate, i).split(" ");
                ($flexiHead).append("<div class='head-days vnan'>" + _backDate[2] + " " + _backDate[1] + " (" + _backDate[0] + ")</div>");
            }
            var _depDate = getFlexiDates(RetDate, 0).split(" ");
            ($flexiHead).append("<div class='head-days vnan'>" + _depDate[2] + " " + _depDate[1] + " (" + _depDate[0] + ")</div>");
            // bind after days header  "Mon Apr 11 2016"
            for (var i = 1; i <= 3; i++) {
                var _backDate = getFlexiDates(RetDate, i).split(" ");
                ($flexiHead).append("<div class='head-days vnan'>" + _backDate[2] + " " + _backDate[1] + " (" + _backDate[0] + ")</div>");
            }
            ($flexiHead).append("<div>");
            $($rootTag).append($flexiHead);
            // return sector head date end
            // depart sector(Outbound) head date start         
            for (var i = -3; i <= -1; i++) {
                $flexiRow = $("<div class='R1'>");
                var _backDepDate = getFlexiDates(DeptDate, i).split(" ");
                var _depDate = _backDepDate[2] + "-" + _backDepDate[1] + "-" + _backDepDate[3];
                ($flexiRow).append("<div class='r-days vnan'><span class='in-bound'>Outbound</span>" + _backDepDate[2] + " " + _backDepDate[1] + " (" + _backDepDate[0] + ")</div>");
                for (var j = 1; j <= 3; j++) {
                    if (j == 1) {
                        for (var k = -3; k <= -1; k++) {
                            var _backRetDate = getFlexiDates(RetDate, k).split(" ");
                            var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                            var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));

                            if (_Itinerary != undefined) {
                                var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                                var _airName = _Itinerary.Sectors[0].AirlineName;
                                var _airIndex = _Itinerary.IndexNumber;
                                var _airProvider = _Itinerary.Provider;
                                var _airGrandTotal = _Itinerary.GrandTotal;
                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\">" +
                                                  "<span class='fl-row'><span class='fl-col-l'>" +
                                                      "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                      "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                  "</span>" +
                                            "</div><div>";
                                ($flexiRow).append(_text);
                            }
                            else {
                                var _airLogo = "";
                                var _airName = "";
                                var _airIndex = "";
                                var _airProvider = "";
                                var _airGrandTotal = "";

                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                                  "<span class='fl-row' style='display:none;'><span class='fl-col-l'>" +
                                                      "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                      "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                  "</span>" +
                                            "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            // ($flexiRow).append("<div class='ch-fl tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                        }
                    }
                    if (j == 2) {
                        var _backRetDate = getFlexiDates(RetDate, 0).split(" ");
                        var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                        var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                        if (_Itinerary != undefined) {
                            var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                            var _airName = _Itinerary.Sectors[0].AirlineName;
                            var _airIndex = _Itinerary.IndexNumber;
                            var _airProvider = _Itinerary.Provider;
                            var _airGrandTotal = _Itinerary.GrandTotal;
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" style='background-color:#fffaea;'>" +
                                              "<span class='fl-row'>" +
                                                  "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                  "</span>" +
                                                  "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                              "</span>" +
                                          "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        else {
                            var _airLogo = "";
                            var _airName = "";
                            var _airIndex = "";
                            var _airProvider = "";
                            var _airGrandTotal = "";
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                              "<span class='fl-row' style='display:none;'>" +
                                                  "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                  "</span>" +
                                                  "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                              "</span>" +
                                          "</div></div>";
                            ($flexiRow).append(_text);
                        }
                    }

                    if (j == 3) {

                        for (var k = 1; k <= 3; k++) {
                            var _backRetDate = getFlexiDates(RetDate, k).split(" ");
                            var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                            var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                            if (_Itinerary != undefined) {
                                var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                                var _airName = _Itinerary.Sectors[0].AirlineName;
                                var _airIndex = _Itinerary.IndexNumber;
                                var _airProvider = _Itinerary.Provider;
                                var _airGrandTotal = _Itinerary.GrandTotal;
                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\">" +
                                                "<span class='fl-row'><span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                    "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                "</span>" +
                                          "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            else {
                                var _airLogo = "";
                                var _airName = "";
                                var _airIndex = "";
                                var _airProvider = "";
                                var _airGrandTotal = "";
                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                                "<span class='fl-row' style='display:none;'><span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                    "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                "</span>" +
                                          "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            // ($flexiRow).append("<div class='ch-fl tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                        }
                    }
                }
                ($flexiRow).append("</div>");
                ($rootTag).append($flexiRow);
            }
            //--------bind depart date row
            $flexiRow = $("<div class='R1'>");

            var _backDepDate = getFlexiDates(DeptDate, 0).split(" ");
            var _depDate = _backDepDate[2] + "-" + _backDepDate[1] + "-" + _backDepDate[3];
            ($flexiRow).append("<div class='r-days vnan'><span class='in-bound'>Outbound</span>" + _backDepDate[2] + " " + _backDepDate[1] + " (" + _backDepDate[0] + ")</div>");
            for (var j = 1; j <= 3; j++) {
                if (j == 1) {
                    for (var k = -3; k <= -1; k++) {
                        var _backRetDate = getFlexiDates(RetDate, k).split(" ");
                        var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                        var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                        if (_Itinerary != undefined) {
                            var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                            var _airName = _Itinerary.Sectors[0].AirlineName;
                            var _airIndex = _Itinerary.IndexNumber;
                            var _airProvider = _Itinerary.Provider;
                            var _airGrandTotal = _Itinerary.GrandTotal;
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" style='background-color:#fffaea;'>" +
                                            "<span class='fl-row'>" +
                                                "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "'  class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                "</span>" +
                                                "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                            "</span>" +
                                        "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        else {
                            var _airLogo = "";
                            var _airName = "";
                            var _airIndex = "";
                            var _airProvider = "";
                            var _airGrandTotal = "";
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                            "<span class='fl-row' style='display:none;'>" +
                                                "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "'  class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                "</span>" +
                                                "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                            "</span>" +
                                        "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        // ($flexiRow).append("<div class='ch-fl ch-yellow tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                    }
                }
                if (j == 2) {
                    var _backRetDate = getFlexiDates(RetDate, 0).split(" ");
                    var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                    var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                    if (_Itinerary != undefined) {

                        var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                        var _airName = _Itinerary.Sectors[0].AirlineName;
                        var _airIndex = _Itinerary.IndexNumber;
                        var _airProvider = _Itinerary.Provider;
                        var _airGrandTotal = _Itinerary.GrandTotal;

                        //bindFlight('" + _airIndex + "', '" + _airProvider + "');
                        bindFlight(_airIndex, _airProvider, 'R-' + (i + 3), 'C-' + (k + 3), 'R' + _airIndex + 'C' + _airProvider);

                        var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" style='background-color:#fffaea;'>" +
                                        "<span class='fl-row flexi-blue-main'>" +
                                            "<span class='fl-col-l'>" +
                                              "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                            "</span>" +
                                              "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                        "</span>" +
                                    "</div></div>";
                        ($flexiRow).append(_text);
                    }
                    else {
                        var _airLogo = "";
                        var _airName = "";
                        var _airIndex = "";
                        var _airProvider = "";
                        var _airGrandTotal = "";
                        var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                        "<span class='fl-row flexi-blue-main' style='display:none;'>" +
                                            "<span class='fl-col-l'>" +
                                              "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                            "</span>" +
                                              "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                        "</span>" +
                                    "</div></div>";
                        ($flexiRow).append(_text);
                    }
                    
                }
                if (j == 3) {
                    for (var k = 1; k <= 3; k++) {
                        var _backRetDate = getFlexiDates(RetDate, k).split(" ");
                        var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                        var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                        if (_Itinerary != undefined) {
                            var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                            var _airName = _Itinerary.Sectors[0].AirlineName;
                            var _airIndex = _Itinerary.IndexNumber;
                            var _airProvider = _Itinerary.Provider;
                            var _airGrandTotal = _Itinerary.GrandTotal;
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl ch-yellow tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" >" +
                                            "<span class='fl-row'>" +
                                                "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "'  class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                "</span>" +
                                                "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                            "</span>" +
                                        "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        else {
                            var _airLogo = "";
                            var _airName = "";
                            var _airIndex = "";
                            var _airProvider = "";
                            var _airGrandTotal = "";
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                            "<span class='fl-row' style='display:none;'>" +
                                                "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "'  class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                "</span>" +
                                                "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                            "</span>" +
                                        "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        
                    }
                }
            }
            ($flexiRow).append("</div>");
            ($rootTag).append($flexiRow);
            //------- date after deprt date
            for (var i = 1; i <= 3; i++) {
                $flexiRow = $("<div class='R1'>");

                var _backDepDate = getFlexiDates(DeptDate, i).split(" ");
                var _depDate = _backDepDate[2] + "-" + _backDepDate[1] + "-" + _backDepDate[3];
                ($flexiRow).append("<div class='r-days vnan'><span class='in-bound'>Outbound</span>" + _backDepDate[2] + " " + _backDepDate[1] + " (" + _backDepDate[0] + ")</div>");
                for (var j = 1; j <= 3; j++) {
                    if (j == 1) {
                        for (var k = -3; k <= -1; k++) {
                            var _backRetDate = getFlexiDates(RetDate, k).split(" ");
                            var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                            var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                            if (_Itinerary != undefined) {
                                var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                                var _airName = _Itinerary.Sectors[0].AirlineName;
                                var _airIndex = _Itinerary.IndexNumber;
                                var _airProvider = _Itinerary.Provider;
                                var _airGrandTotal = _Itinerary.GrandTotal;

                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" >" +
                                                  "<span class='fl-row'><span class='fl-col-l'>" +
                                                      "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                      "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                  "</span>" +
                                            "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            else {
                                var _airLogo = "";
                                var _airName = "";
                                var _airIndex = "";
                                var _airProvider = "";
                                var _airGrandTotal = "";
                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                                  "<span class='fl-row' style='display:none;'><span class='fl-col-l'>" +
                                                      "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                      "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                  "</span>" +
                                            "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            //   ($flexiRow).append("<div class='ch-fl tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                        }
                    }
                    if (j == 2) {
                        var _backRetDate = getFlexiDates(RetDate, 0).split(" ");
                        var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                        var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                        if (_Itinerary != undefined) {
                            var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                            var _airName = _Itinerary.Sectors[0].AirlineName;
                            var _airIndex = _Itinerary.IndexNumber;
                            var _airProvider = _Itinerary.Provider;
                            var _airGrandTotal = _Itinerary.GrandTotal;
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" style='background-color:#fffaea;'>" +
                                              "<span class='fl-row'>" +
                                                  "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                  "</span>" +
                                                  "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                              "</span>" +
                                          "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        else {
                            var _airLogo = "";
                            var _airName = "";
                            var _airIndex = "";
                            var _airProvider = "";
                            var _airGrandTotal = "";
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                              "<span class='fl-row' style='display:none;'>" +
                                                  "<span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                  "</span>" +
                                                  "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                              "</span>" +
                                          "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        // ($flexiRow).append("<div class='ch-fl ch-yellow tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                    }

                    if (j == 3) {
                        for (var k = 1; k <= 3; k++) {
                            var _backRetDate = getFlexiDates(RetDate, k).split(" ");
                            var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                            var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), GetDateFormatMonth(_retDate));
                            if (_Itinerary != undefined) {
                                var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                                var _airName = _Itinerary.Sectors[0].AirlineName;
                                var _airIndex = _Itinerary.IndexNumber;
                                var _airProvider = _Itinerary.Provider;
                                var _airGrandTotal = _Itinerary.GrandTotal;
                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\">" +
                                                "<span class='fl-row'><span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                    "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                "</span>" +
                                          "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            else {
                                var _airLogo = "";
                                var _airName = "";
                                var _airIndex = "";
                                var _airProvider = "";
                                var _airGrandTotal = "";
                                var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                                "<span class='fl-row' style='display:none;'><span class='fl-col-l'>" +
                                                    "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                    "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                                "</span>" +
                                          "</div></div>";
                                ($flexiRow).append(_text);
                            }
                            //  ($flexiRow).append("<div class='ch-fl tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                        }
                    }
                }
                ($flexiRow).append("</div>");
                ($rootTag).append($flexiRow);
            }
            // depart sector(Outbound) head date start
        }
        else {

            // if flexi search only for one way
            $flexiHead = $("<div class='t-heading'>");
            var $flexiHeadDiv1 = "<div class='head-days-first vnan'>" +
                                   "<img src='/content/images/in-outbound.png' style='position: relative; top: -1px; right: -90px; ' alt='' />" +


                                    "<div class='out-txt' style='top:35px;'>Outbound</div>" +
                                 "</div>";
            ($flexiHead).append($flexiHeadDiv1);
            // bind back days header  "Mon Apr 11 2016"
            for (var i = -3; i <= -1; i++) {
                var _backDate = getFlexiDates(DeptDate, i).split(" ");
                ($flexiHead).append("<div class='head-days vnan'>" + _backDate[2] + " " + _backDate[1] + " (" + _backDate[0] + ")</div>");
            }
            var _depDate = getFlexiDates(DeptDate, 0).split(" ");
            ($flexiHead).append("<div class='head-days vnan'>" + _depDate[2] + " " + _depDate[1] + " (" + _depDate[0] + ")</div>");
            // bind after days header  "Mon Apr 11 2016"
            for (var i = 1; i <= 3; i++) {
                var _backDate = getFlexiDates(DeptDate, i).split(" ");
                ($flexiHead).append("<div class='head-days vnan'>" + _backDate[2] + " " + _backDate[1] + " (" + _backDate[0] + ")</div>");
            }
            ($flexiHead).append("<div>");
            $($rootTag).append($flexiHead);
            // return sector head date end

            // depart sector(Outbound) head date start    

            //for (var i = -3; i <= -3; i++) {
            $flexiRow = $("<div class='R1'>");

            ($flexiRow).append("<div class='r-days vnan'><span class='in-bound'></span></div>");
            for (var j = 1; j <= 3; j++) {
                if (j == 1) {
                    for (var k = -3; k <= -1; k++) {
                        //var _backRetDate = getFlexiDates(DeptDate, k).split(" ");
                        //var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                        var _backDepDate = getFlexiDates(DeptDate, k).split(" ");
                        var _depDate = _backDepDate[2] + "-" + _backDepDate[1] + "-" + _backDepDate[3];
                        var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), "");

                        if (_Itinerary != undefined) {
                            var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                            var _airName = _Itinerary.Sectors[0].AirlineName;
                            var _airIndex = _Itinerary.IndexNumber;
                            var _airProvider = _Itinerary.Provider;
                            var _airGrandTotal = _Itinerary.GrandTotal;
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\">" +
                                              "<span class='fl-row'><span class='fl-col-l'>" +
                                                  "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                  "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                              "</span>" +
                                        "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        else {
                            var _airLogo = "";
                            var _airName = "";
                            var _airIndex = "";
                            var _airProvider = "";
                            var _airGrandTotal = "";

                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                              "<span class='fl-row' style='display:none;'><span class='fl-col-l'>" +
                                                  "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                  "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                              "</span>" +
                                        "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        // ($flexiRow).append("<div class='ch-fl tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                    }
                }
                if (j == 2) {
                    var _backRetDate = getFlexiDates(DeptDate, 0).split(" ");
                    //var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];
                    var _backDepDate = getFlexiDates(DeptDate, 0).split(" ");
                    var _depDate = _backDepDate[2] + "-" + _backDepDate[1] + "-" + _backDepDate[3];
                    var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), "");
                    if (_Itinerary != undefined) {
                        var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                        var _airName = _Itinerary.Sectors[0].AirlineName;
                        var _airIndex = _Itinerary.IndexNumber;
                        var _airProvider = _Itinerary.Provider;
                        var _airGrandTotal = _Itinerary.GrandTotal;
                        bindFlight(_airIndex, _airProvider);
                        //var _text = "<div id='R" + _airIndex + "C" + _airProvider + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "')\" class='ch-fl ch-yellow tTip'>" +
                        //                  "<span class='fl-row'>" +
                        //                      "<span class='fl-col-l'>" +
                        //                        "<span class='fl-logo'><img src='" + _airLogo + "' class='airlinelg img-responsive' height='15' width='25' alt='" + _airName + "'></span>" +
                        //                      "</span>" +
                        //                      "<span class='fl-col-r'><span class='bl-txt'>From</span>" + _airGrandTotal + "</span>" +
                        //                  "</span>" +
                        //              "</div>";
                        //($flexiRow).append(_text);
                        var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'  onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\">" +
                                  "<span class='fl-row flexi-blue-main'>" +
                                      "<span class='fl-col-l'>" +
                                        "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                      "</span>" +
                                       "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                  "</span>" +
                              "</div></div>";
                        ($flexiRow).append(_text);
                    }
                    else {
                        var _airLogo = "";
                        var _airName = "";
                        var _airIndex = "";
                        var _airProvider = "";
                        var _airGrandTotal = "";
                        var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                          "<span class='fl-row' style='display:none;'>" +
                                              "<span class='fl-col-l'>" +
                                                "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                              "</span>" +
                                              "<span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                          "</span>" +
                                      "</div></div>";
                        ($flexiRow).append(_text);
                    }
                }

                if (j == 3) {
                    for (var k = 1; k <= 3; k++) {
                        var _backRetDate = getFlexiDates(DeptDate, k).split(" ");
                        //  var _retDate = _backRetDate[2] + "-" + _backRetDate[1] + "-" + _backRetDate[3];

                        var _backDepDate = getFlexiDates(DeptDate, k).split(" ");
                        var _depDate = _backDepDate[2] + "-" + _backDepDate[1] + "-" + _backDepDate[3];
                        var _Itinerary = getItineraryByDate(Data, GetDateFormatMonth(_depDate), "");
                        if (_Itinerary != undefined) {
                            var _airLogo = _Itinerary.Sectors[0].AirlineLogoPath;
                            var _airName = _Itinerary.Sectors[0].AirlineName;
                            var _airIndex = _Itinerary.IndexNumber;
                            var _airProvider = _Itinerary.Provider;
                            var _airGrandTotal = _Itinerary.GrandTotal;
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "' onclick=\"bindFlight('" + _airIndex + "','" + _airProvider + "','R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\" onmouseout=\"changeBackR('R-" + (i + 3) + "','C-" + (k + 3) + "','R" + _airIndex + "C" + _airProvider + "')\">" +
                                            "<span class='fl-row'><span class='fl-col-l'>" +
                                                "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                            "</span>" +
                                      "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        else {
                            var _airLogo = "";
                            var _airName = "";
                            var _airIndex = "";
                            var _airProvider = "";
                            var _airGrandTotal = "";
                            var _text = "<div class='BB'><div id='R" + _airIndex + "C" + _airProvider + "' class='ch-fl tTip R-" + (i + 3) + " C-" + (k + 3) + "'>" +
                                            "<span class='fl-row' style='display:none;'><span class='fl-col-l'>" +
                                                "<span class='fl-logo'><img src='" + _airLogo.replace("http:", "") + "' class='airlinelg img-responsive' alt='" + _airName + "'></span>" +
                                                "</span><span class='fl-col-r'><span class='bl-txt'>From</span>" + Symbol + _airGrandTotal + "</span>" +
                                            "</span>" +
                                      "</div></div>";
                            ($flexiRow).append(_text);
                        }
                        // ($flexiRow).append("<div class='ch-fl tTip'><span class='fl-row'><span class='fl-col-l'><span class='fl-logo'><img src='../conte/content/images/air-logo.png' class='airlinelg img-responsive' alt=''></span></span><span class='fl-col-r'><span class='bl-txt'>From</span>€-" + _backDepDate[2] + "-" + _backRetDate[2] + "</span></span></div>");
                    }
                }
            }
            ($flexiRow).append("</div>");
            ($rootTag).append($flexiRow);
            //}


        }
        //----
        ($rootTag).append("<div>");
        $('#divFlexiList').append($rootTag);
    }

}
function getItineraryByDate(Data, depDate, retDate) {
    if (retDate != "") {
        for (var i = 0; i < Data.Items.length; i++) {
            var sectorLenght = Data.Items[i].Sectors.length;
            if (sectorLenght == undefined)
                sectorLenght = 0;

            var firstRetsectIndex = undefined;                                                            //First Return sector Index no
            for (var p = 0; p < sectorLenght; p++) {
                if (Data.Items[i].Sectors[p].IsReturn == "true") {
                    firstRetsectIndex = p;
                    break;
                }
            }

            if (firstRetsectIndex == undefined)
                firstRetsectIndex = sectorLenght;

            var _depDateS = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[0].Departure.Date;
            var _retDateS = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[firstRetsectIndex].Departure.Date;
            if ((depDate == _depDateS) && (retDate == _retDateS)) {
                return Data.Items[i];
                break;
            }
        }
    }
    else {

        for (var i = 0; i < Data.Items.length; i++) {
            var sectorLenght = Data.Items[i].Sectors.length;
            if (sectorLenght == undefined)
                sectorLenght = 0;


            var _depDateS = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[0].Departure.Date;

            if (depDate == _depDateS) {
                return Data.Items[i];
                break;
            }
        }
    }
}

function getFlexiDates(_date, _day) {
    var _array = _date.split("-");
    var d = _array[0];
    var m = _array[1];
    var y = _array[2];
    var _depDate = new Date(y, m - 1, d);
    var _newDate = new Date(y, m - 1, parseInt(d) + _day);
    return _newDate.toDateString();
}
function GetDateFormatMonth(_date) {

    var arr = _date.split("-");
    var d = arr[0];
    var m = arr[1];
    var y = arr[2];
    var day = "";
    switch (m) {
        case "Jan":
            day = "01";
            break;
        case "Feb":
            day = "02";
            break;
        case "Mar":
            day = "03";
            break;
        case "Apr":
            day = "04";
            break;
        case "May":
            day = "05";
            break;
        case "Jun":
            day = "06";
            break;
        case "Jul":
            day = "07";
            break;
        case "Aug":
            day = "08";
            break;
        case "Sep":
            day = "09";
            break;
        case "Oct":
            day = "10";
            break;
        case "Nov":
            day = "11";
            break;
        case "Dec":
            day = "12";
            break;
    }
    return d + "-" + day + "-" + y;
}
function GetDateFormat(_date) {

    var arr = _date.split("-");
    var d = arr[0];
    var m = arr[1];
    var y = arr[2];
    var day = "";
    switch (m) {
        case "01":
            day = "Jan";
            break;
        case "02":
            day = "Feb";
            break;
        case "03":
            day = "Mar";
            break;
        case "04":
            day = "Apr";
            break;
        case "05":
            day = "May";
            break;
        case "06":
            day = "Jun";
            break;
        case "07":
            day = "Jul";
            break;
        case "08":
            day = "Aug";
            break;
        case "09":
            day = "Sep";
            break;
        case "10":
            day = "Oct";
            break;
        case "11":
            day = "Nov";
            break;
        case "12":
            day = "Dec";
            break;
    }
    return d + " " + day + " " + y;
}

function create_SelectedFlightList(Data, _index, _provider, SourceMedia, unique,Symbol) {

    var _itineraryLenght = 0;
    $("#firstlListView").empty();
    if (Data.Items == undefined) {
        _itineraryLenght = 0;
        $("#firstlListView").append("No Record Found");
    }
    else {
        _itineraryLenght = Data.Items.length;
    }

    var i;
    for (var t = 0; t < _itineraryLenght; t++) {
        if (Data.Items[t].IndexNumber == _index && Data.Items[t].Provider == _provider) {
            i = t;
            break;
        }
    }

    if (_itineraryLenght > 1) {
        var q = "";
        var _conditionHoldFare;
        var _displayHoldFree = 'none';
        var _displayForBaggageInfo = 'none';
        var NoOfPax = GetPaxCount(Data.Items[0]);
        var isR = false;
        //---
        var chkDate_Hold;
        var dep_date;
        if (Data.Items[0].Sectors.length != undefined) {
            dep_date = Data.Items[0].Sectors[0].Departure.Date;
        }
        else {
            dep_date = Data.Items[0].Sectors.Departure.Date;
        }
        chkDate_Hold = CheckDateForHold(dep_date);

        if ((chkDate_Hold == true) && (SourceMedia == '3517_MNL_GPPC')) {
            _displayHoldFree = 'block';
        }


        for (var i1 = 0; i1 < 1; i1++) {

            var sectorLenght = Data.Items[i].Sectors.length;           //sector Length          
            if (sectorLenght == undefined)
                sectorLenght = 0;

            var firstRetsectIndex = undefined;                                                            //First Return sector Index no
            for (var p = 0; p < sectorLenght; p++) {
                if (Data.Items[i].Sectors[p].IsReturn == "true") {
                    firstRetsectIndex = p;
                    isR = true;
                    break;
                }
            }

            if (firstRetsectIndex == undefined)
                firstRetsectIndex = sectorLenght;

            var noOfDepSec = 0;
            var noOfRetSec = 0;
            for (var p = 0; p < sectorLenght; p++) {
                if (Data.Items[i].Sectors[p].IsReturn == "false") {
                    noOfDepSec++;
                }
                if (Data.Items[i].Sectors[p].IsReturn == "true") {
                    noOfRetSec++;
                }
            }
            //--root div
            var flightGrandTotal = parseFloat(Data.Items[i].GrandTotal).toFixed(2);
            var flightFarePP = parseFloat(flightGrandTotal / NoOfPax).toFixed(2);

            var flightSafi = Data.Items[i].Safi;
            var flightmarkUp = Data.Items[i].MarkUp;
            var flightTotalPrice = Data.Items[i].TotalPrice;
            var flightIndexNumber = Data.Items[i].IndexNumber;
            var flightProvider = Data.Items[i].Provider;
            var htmlDiv = "<div class='searchbox1' id='div" + flightIndexNumber + "_" + flightProvider + "'>";
            var airlineCode = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineCode : Data.Items[i].Sectors[0].AirlineCode;
            var airlineClass = (sectorLenght == 0) ? Data.Items[i].Sectors.CabinClass.Name : Data.Items[i].Sectors[0].CabinClass.Name;
            var airlineName = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineName : Data.Items[i].Sectors[0].AirlineName;
            var Depstop = (sectorLenght == 0) ? 0 : parseInt(parseInt(noOfDepSec) - 1);

            var depFltTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Time : Data.Items[i].Sectors[0].Departure.Time;
            var depAirportCd = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirportCode : Data.Items[i].Sectors[0].Departure.AirportCode;
            var depBaggageInfo = (sectorLenght == 0) ? Data.Items[i].Sectors.BaggageInfo : Data.Items[i].Sectors[0].BaggageInfo;



            var DepTime = "<div class='tip1'>", RetTime = "<div class='tip1'>", DepDest, RetDest;
            var actualdeptime; var actualrettime;
            for (j = 0; j < Data.Items[i].Sectors.length; j++) {
                if (Data.Items[i].Sectors[j].IsReturn == "false") {

                    DepTime += Data.Items[i].Sectors[j].ElapsedTime.replace(":", "h ") + "m &nbsp;&nbsp;";
                    actualdeptime = Data.Items[i].Sectors[j].ActualTime.replace(":", "h ") + "m";
                    DepDest += "<span class='lh'>" + Data.Items[i].Sectors[j].Departure.AirportCode + "</span>";
                }
                else {

                    RetTime += Data.Items[i].Sectors[j].ElapsedTime.replace(":", "h ") + "m &nbsp;&nbsp;";
                    actualrettime = Data.Items[i].Sectors[j].ActualTime.replace(":", "h ") + "m";
                    RetDest += "<span class='lh'>" + Data.Items[i].Sectors[j].Departure.AirportCode + "</span>";
                }
            }

            htmlDiv += "<div class='searchrow1'>" +
            "<span class=''> <span class='t_t_text'>including<br />all taxes</span> <span class='priceleft'>" + Symbol + flightGrandTotal + "</span></span>"; // <i class='fa fa-euro'></i>"
            //if (isR == true) {
            //    htmlDiv += "<span class='rtrip'>ROUND TRIP</span>";
            //}
            //else { htmlDiv += "<span class='rtrip' >ONE WAY</span>"; }
            htmlDiv += "<span class='pricebreak' onclick=\"PricePopUp()\" style='display:none;'>Price Breakdown</span>" +
            "<div class='popup breakdown'>" +
                "<img src='/content/images/cbreal.png' class='closeb' onclick=\"PricePopUpHide()\"><h2>Tickets</h2>" +
                "<table width='100%' border='1'>" +
                    "<tr>" +
                        "<th width='29%'>Passengers</th>" +
                        "<th width='28%'>Price/Passenger</th>" +
                        "<th width='24%'>Quantity</th>" +
                        "<th width='19%'>Price breakdown</th>" +
                    "</tr>" +
                    "<tr>" +
                        "<td>Adults</td>" +
                        "<td>" + Symbol +" " + parseFloat(Data.Items[i].AdultInfo.AdTax + Data.Items[i].AdultInfo.AdtBFare + Data.Items[i].AdultInfo.MarkUp + Data.Items[i].AdultInfo.Commission).toFixed(2) + "</td>" +
            "<td align=''>1</td>" +
            "<td>" + Symbol + " " + parseFloat((Data.Items[i].AdultInfo.AdTax + Data.Items[i].AdultInfo.AdtBFare + Data.Items[i].AdultInfo.MarkUp + Data.Items[i].AdultInfo.Commission) * Data.Items[i].AdultInfo.NoAdult).toFixed(2) + "</td>" +
        "</tr>";
            if (Data.Items[i].ChildInfo.NoChild > 0) {
                htmlDiv += "<tr>" +
                          "<td>Child</td>" +
                          "<td>" + Symbol + " " + parseFloat(Data.Items[i].ChildInfo.CHTax + Data.Items[i].ChildInfo.ChdBFare + Data.Items[i].ChildInfo.MarkUp + Data.Items[i].ChildInfo.Commission).toFixed(2) + "</td>" +
                          "<td align=''>1</td>" +
                          "<td>" + Symbol + " " + parseFloat((Data.Items[i].ChildInfo.CHTax + Data.Items[i].ChildInfo.ChdBFare + Data.Items[i].ChildInfo.MarkUp + Data.Items[i].ChildInfo.Commission) * Data.Items[i].ChildInfo.NoChild).toFixed(2) + "</td>" +
                      "</tr>";
            }
            if (Data.Items[i].InfantInfo.NoInfant > 0) {
                htmlDiv += "<tr>" +
                          "<td>Infant</td>" +
                          "<td>" + Symbol + " " + parseFloat(Data.Items[i].InfantInfo.InTax + Data.Items[i].InfantInfo.InfBFare + Data.Items[i].InfantInfo.MarkUp + Data.Items[i].InfantInfo.Commission).toFixed(2) + "</td>" +
                          "<td align=''>1</td>" +
                          "<td>" + Symbol + " " + parseFloat((Data.Items[i].InfantInfo.InTax + Data.Items[i].InfantInfo.InfBFare + Data.Items[i].InfantInfo.MarkUp + Data.Items[i].InfantInfo.Commission) * Data.Items[i].InfantInfo.NoInfant).toFixed(2) + "</td>" +
                      "</tr>";
            }


            htmlDiv += "<tr>" +
                        "<td><strong>Total</strong></td>" +
                        "<td>&nbsp;</td>" +
                        "<td>&nbsp;</td>" +
                        "<td><strong>" + Symbol + " " + flightGrandTotal + "</strong></td>" +
                    "</tr>" +
                "</table>" +
                "<p>There will be a 0% of surcharge on all credit/debit cards.</p>" +
            "</div>" +
            //"<span class='ticket'>Book now: Only  9 Seats left at this price!</span>" +
        "</div>";


            
            //---- desp sect begin

            var depAirLogo = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineLogoPath : Data.Items[i].Sectors[0].AirlineLogoPath;
            var depFromCity = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirportCityName : Data.Items[i].Sectors[0].Departure.AirportCityName;
            var depAirpCode = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirportCode : Data.Items[i].Sectors[0].Departure.AirportCode;
            var depAirpName = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirportName : Data.Items[i].Sectors[0].Departure.AirportName;
            var depFromDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[0].Departure.Date;
            var depFromTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Time : Data.Items[i].Sectors[0].Departure.Time;

            depFromDate = GetDateFormat(depFromDate);
            var NoSeats = (sectorLenght == 0) ? Data.Items[i].Sectors.NoSeats : Data.Items[i].Sectors[0].NoSeats;
            // var NoSeatsDisplay = "block";
            var NoSeatsDisplay = "none";
            if (parseInt(NoSeats) <= 7)
                NoSeatsDisplay = "block";


            var depToCity = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirportCityName : Data.Items[i].Sectors[firstRetsectIndex - 1].Arrival.AirportCityName;
            var arrAirpCode = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirportCode : Data.Items[i].Sectors[firstRetsectIndex - 1].Arrival.AirportCode;
            var arrAirpName = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirportName : Data.Items[i].Sectors[firstRetsectIndex - 1].Arrival.AirportName;
            var depToDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Date : Data.Items[i].Sectors[firstRetsectIndex - 1].Arrival.Date;
            var depToTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Time : Data.Items[i].Sectors[firstRetsectIndex - 1].Arrival.Time;
            var actTime = (sectorLenght == 0) ? Data.Items[i].Sectors.ActualTime.replace(":", "H ") : Data.Items[i].Sectors[firstRetsectIndex - 1].ActualTime.replace(":", "H ");
            depToDate = GetDateFormat(depToDate);


            var _depSect = (sectorLenght == 0) ? 0 : parseInt(noOfDepSec) - 1;
            if (_depSect == 0)
                _depSect = 'Non';



            htmlDiv += "<div class='searchrow1 res_pad_10'>" +
               " <div class='dvAnameF' ><span class='anamef'><img src=" + depAirLogo.replace("http:", "") + "></span></div>"+
            "<div class='flight1'>" +
              "<span class='scol1 lhr'> " + depAirpCode + "</span> " +
                "<div class='scol1 time1'><strong>" + depFromTime + "</strong> " + depFromDate + "</div>" +
            "</div>" +

            "<span class='scol1 aro'> <span> " + (Depstop == 0 ? "Non Stop" : (Depstop == 1 ? (Depstop) + " Stop" : (Depstop) + " Stops")) + " </span> <img src='../Content/images/small_plane.png'></span>" +
            "<div class='flight2'>" +
                "<span class='scol1 lhr'>" + arrAirpCode + "</span> " +
                    "<span class='scol1 time1'><strong>" + depToTime + "</strong>  " + depToDate + "</span> " +
                "</div>" +
                "<div class='flight3'>";
                        
            if (noOfRetSec > 0) {
                htmlDiv += "<span ><i class='fa fa-clock-o'></i> " + actualdeptime + "</span>" +
                    //"<span class='scol1 datelist stpop1' onmouseover='checkstop()' onmouseleave='noncheck()'>" +
                    //        (Depstop == 0 ? "Non Stop" : (Depstop == 1 ? (Depstop) + " Stop" : (Depstop) + " Stops")) + "  </span>" +
                
                "";
            }
            else {

                htmlDiv += "<span ><i class='fa fa-clock-o'></i> " + actualdeptime + "</span>" +
                    //"<span class='scol1 datelist stpop1' onmouseover='checkstop2()' onmouseleave='noncheck2()'>" +
                    //(Depstop == 0 ? "Non Stop" : (Depstop == 1 ? (Depstop) + " Stop" : (Depstop) + " Stops")) + "  </span>" +           
                "";
            }

            "</div>" +
            //flight details end
            "</div>";

            
            //----desp sect end
            // ret sec begin
            if (noOfRetSec > 0) {
                var retAirLogo = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineLogoPath : Data.Items[i].Sectors[firstRetsectIndex].AirlineLogoPath;
                var retAirName = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineName : Data.Items[i].Sectors[firstRetsectIndex].AirlineName;
                var retFromCity = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirportCityName : Data.Items[i].Sectors[firstRetsectIndex].Departure.AirportCityName;
                var retFromDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[firstRetsectIndex].Departure.Date;
                var retFromTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Time : Data.Items[i].Sectors[firstRetsectIndex].Departure.Time;
                retFromDate = GetDateFormat(retFromDate);

                var retToCity = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirportCityName : Data.Items[i].Sectors[sectorLenght - 1].Arrival.AirportCityName;
                var retToDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Date : Data.Items[i].Sectors[sectorLenght - 1].Arrival.Date;
                var retToTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Time : Data.Items[i].Sectors[sectorLenght - 1].Arrival.Time;
                retToDate = GetDateFormat(retToDate);
                var _retSect = (sectorLenght == 0) ? 0 : parseInt(noOfRetSec) - 1;
                if (_retSect == 0)
                    _retSect = 0;
                if (i == 0) {
                    $("#spnHeadRetDateText").text(" Return: " + retFromDate + ", ");
                    $("#spnHeadRetDateText").css('display', 'block');
                }


                htmlDiv += " </div>  </div> <div class='clearfix '></div> <div class=' searchrow1 res_pad_10 br_tp_re'>" +
                    "<div class='dvAnameF' ><span class='anamef'><img src=" + retAirLogo.replace("http:", "") + "></span> </div>" +
           "<div class='flight1'>" +

            "<span class='scol1 lhr'> " + arrAirpCode + "</span> " +
            "<div class='scol1 time1 '><strong>" + retFromTime + "</strong> " + retFromDate + "</div>" +
          
           "</div>" +
          "<span class='scol1 aro'> <span> " + (_retSect == 0 ? "Non Stop" : (_retSect == 1 ? (_retSect) + " Stop" : (_retSect) + " Stops")) + " </span> <img src='../Content/images/small_plane.png'></span>" +
           "<div class='flight2'>" +
           "<span class='scol1 lhr'>" + depAirpCode + "</span>" +
           "<span class='scol1 time1'><strong>" + retToTime + "</strong> " + retToDate + " </span>" +
           "</div>" +
           "<div class='flight3'>";

                htmlDiv += "<span><i class='fa fa-clock-o'></i>  " + actualrettime + "</span>" +
                    //"<span class='scol1 datelist stpop1' onmouseover='checkstop1()' onmouseleave='noncheck1()'>" +
                    //        (_retSect == 0 ? "Non Stop" : (_retSect == 1 ? (_retSect) + " Stop" : (_retSect) + " Stops")) + "  </span>" +
                             "<div class='stoptooltip-data1' style='display: none;'>" +


                                "<img src='/content/images/stoparo.png' style='margin-top: -22px; float: left; margin-left: 120px;'>" +
                                  RetTime +
                (_retSect == 0 ? "<img src='/content/images/tooltipdotn.png'>" : (_retSect == 1 ? "<img src='/content/images/tooltipdot-new-1.png'>" : "<img src='/content/images/tooltipdot.png'>")) +
               (_retSect == 0 ? "<div class='tip21'><span class='lh'>" + Data.Items[i].Sectors[1].Departure.AirportCode + "</span><span class='lh' style='margin-left: 194px;'>" + Data.Items[i].Sectors[1].Arrival.AirportCode + "</span></div>" : (_retSect == 1 ? "<div class='tip2'><span class='lh'>" + Data.Items[i].Sectors[2].Departure.AirportCode + "</span><span class='lh' style='margin-left: 82px;'>" + Data.Items[i].Sectors[3].Departure.AirportCode + "</span><span class='lh' style='margin-left: 82px;'>" + Data.Items[i].Sectors[3].Arrival.AirportCode + "</span></div>" : "<div class='tip2'><span class='lh'>" + Data.Items[i].Sectors[2].Arrival.AirportCode + "</span><span class='lh' style='margin-left: 40px;'>" + Data.Items[i].Sectors[3].Arrival.AirportCode + "</span><span class='lh' style='margin-left: 40px;'>" + Data.Items[i].Sectors[4].Arrival.AirportCode + "</span><span class='lh' style='margin-left: 40px;'>" + Data.Items[i].Sectors[0].Departure.AirportCode + "</span></div>")) +

                        "</div>" +
                "</div>";

                 
                "</div>" + "</div>" +
           "</div>" +
           "</div>";

            }
            //---

            htmlDiv += "</div></div><div class='clearix'></div> <div class='searchrow1 bordernone'>" +
            "<span class='flightdetail flightdetail'><a onclick=\"FlightDetails()\">Flight Details</a></span>";
            if (depBaggageInfo != "") {
                htmlDiv += "<div class='dvBagage'><span class='scol1 bagage'><span class='bag'>" +
                "<img src='/content/images/bag.png'>Baggage Included </span></span><span class='scol1 laticon' style='display: none;'>" +
                "<img src='/content/images/iconright.png'></span><div class='bagagetoltip' style='display: none;'>" +
                "2 pcs per adult<br>" +
                "<img src='/content/images/stoparo1.png' style='float: left; margin-bottom: -85px; margin-left: 41px; margin-top: 4px;'>" +
                "</div>" +
                "</div>";
            }
            //htmlDiv += "<div class='alternet'><a href='AlternateFlights.aspx?q=" + unique + "&a=" + airlineCode + "'>Alternate Flights</a></div>";
            //htmlDiv +="<span class='selecthold'><a href='PassengerDetails.aspx?q=" + unique + "&i=" + flightIndexNumber + "&p=" + flightProvider + "&h=1'>Hold for Free <i class='fa fa-chevron-right'></i></a></span><span class='selOr'>OR </span>";
            var ss = unique + "~" + flightIndexNumber + "~" + flightProvider;
            htmlDiv += " <a onclick=\"redirectPage('" + ss + "')\"  class=' btn btn__dark-blue'>Select <i class='fa fa-chevron-right'></i></a> " +
            "</div>";



            htmlDiv += "<div class='searchdetail searchdetail' style='display: none'>";

            if (isR == true) {
                htmlDiv += "<div class='main_wid_40 left_br_fli_det'>";
            }
            else {
                htmlDiv += "<div class='main_wid_40 left_br_fli_det main_wid_full'>";
            }




            var ctr = 0;

            for (var p = 0; p < sectorLenght; p++) {

                if (Data.Items[i].Sectors[p].IsReturn == "false") {

                    bagg = Data.Items[i].Sectors[p].BaggageInfo;
                    acttime = Data.Items[i].Sectors[p].ActualTime.replace(":", "H ") + "m";

                    if (Data.Items[i].Sectors[p].TransitTime!=null && Data.Items[i].Sectors[p].TransitTime.TimeDes != null && Data.Items[i].Sectors[p].TransitTime.TimeDes != "") {

                        htmlDiv += "<div class='br_left_1'></div>";
                        htmlDiv += "<div class='stop_box'><p><strong>Stopover </strong> <i class='fa fa-dot-circle-o'></i>  " + Data.Items[i].Sectors[p].TransitTime.TimeDes + "</p><div class='clearfix'></div></div>";

                    }
                    else {
                        htmlDiv += "<div class='dep_box'>" +
                     (ctr++ == 0 ? ("<p class='left_side'><strong>Departure:</strong> " + Data.Items[i].Sectors[p].Departure.Date + "</p>" +
                             " <p class='right_side'><strong>Duration:</strong>   <i class='fa fa-clock-o'></i> " + actualdeptime + " </p>") : "");
                        htmlDiv += "</div>";
                        htmlDiv += " <div class='clearfix'></div>";

                    }

                    htmlDiv += "<div class='br_left_1'></div>" +
                   "<div class='clearfix'></div>" +
                    "<p class='text-center center-block text_gray'><img src='../Content/images/AirlineLogo/medium/" + Data.Items[i].Sectors[p].AirlineCode + "_M.png' alt='' class='icon_flight_details'> <span class='left_spc'> " + Data.Items[i].Sectors[p].AirlineName + " " + Data.Items[i].Sectors[p].FltNum + " <strong>|</strong>    " + Data.Items[i].Sectors[p].CabinClass.Name + "</span>  </p>" +
                   "<div class='clearfix'></div>" +
                     "<div class='row'>  " +
                     " <div class='wid_40'>" +
                        " <span class='loc_fli_det right_side'>" + Data.Items[i].Sectors[p].Departure.AirportCode + "</span><span class='time_fli_det right_side'>" + Data.Items[i].Sectors[p].Departure.Time + "</span>" +
                        " <div class='clearfix'></div>" +
                        " <span class='loc_fli_date  text-right'>" + Data.Items[i].Sectors[p].Departure.Date + "</span>" +
                         " <span class='loc_fli_adres  text-right'> " + Data.Items[i].Sectors[p].Departure.AirportCityName + "";
                    if (Data.Items[i].Sectors[p].Departure.Terminal != "") {
                        htmlDiv += ",Terminal " + Data.Items[i].Sectors[p].Departure.Terminal + "";
                    }
                    htmlDiv += "</span>";
                    htmlDiv += " <div class='clearfix'></div>" +

                         " </div>" +
                     "  <div class='wid_20 pd_0'>" +
                "    <img src='/content/images/icon_flight_details.png' alt='' class='center-block'>" +

                 " </div>" +
                  "  <div class='wid_40'>  " +
                "  <span class='loc_fli_det left_side m_l_0'>" + Data.Items[i].Sectors[p].Arrival.AirportCode + "</span><span class='time_fli_det left_side'>" + Data.Items[i].Sectors[p].Arrival.Time + "</span>" +
                "  <div class='clearfix'></div>" +
                " <span class='loc_fli_date  text-left'>" + Data.Items[i].Sectors[p].Arrival.Date + "</span>" +
                "   <span class='loc_fli_adres  text-left'>" + Data.Items[i].Sectors[p].Arrival.AirportCityName + "";
                    if (Data.Items[i].Sectors[p].Arrival.Terminal != "") {
                        htmlDiv += ",Terminal " + Data.Items[i].Sectors[p].Arrival.Terminal + "";
                    }
                    htmlDiv += "</span>";
                    htmlDiv += "<div class='clearfix'></div>" +
                      "   </div>" +
                  "  <div class='clearfix'></div>" +

                  " </div>";
                }
            }
            if (bagg != "") {
                htmlDiv += "<div class='br_left_1'></div><div class='bag_box'>" +
                 "  <span class='pull-left text-left'><i class='fa fa-suitcase'></i> " + bagg + " Baggage</span>   <span class='pull-right text-right'> <i class='fa fa-clock-o'></i>    " + acttime + "</span></div>";
            }
            htmlDiv += "  <div class='clearfix'></div>";
            htmlDiv += "</div>";

            if (isR == true) {
                htmlDiv += "<div class='main_wid_20'>" +
                         " <img src='/content/images/round_btwn_cricle.png' alt=''>" +
                           "<div class='cen_br_top'></div>" +
                   "  </div>";
            }
            ctr = 0;
            htmlDiv += "<div class='main_wid_40'>";

            if (isR == true) {

                for (var p = 0; p < sectorLenght; p++) {
                    if (Data.Items[i].Sectors[p].IsReturn == "true") {
                        if (Data.Items[i].Sectors[p].TransitTime!=null && Data.Items[i].Sectors[p].TransitTime.TimeDes != null && Data.Items[i].Sectors[p].TransitTime.TimeDes != "") {
                            htmlDiv += "<div class='br_left_1'></div>";
                            htmlDiv += "<div class='stop_box'><p><strong>Stopover </strong> <i class='fa fa-dot-circle-o'></i>  " + Data.Items[i].Sectors[p].TransitTime.TimeDes + "</p><div class='clearfix'></div></div>";

                        }
                        else {
                            htmlDiv += "<div class='dep_box'>" +
                (ctr++ == 0 ? ("<p class='left_side'><strong>Return:</strong> " + Data.Items[i].Sectors[p].Departure.Date + "</p>" +
                                 " <p class='right_side'><strong>Duration:</strong>   <i class='fa fa-clock-o'></i> " + actualrettime + " </p>") : "");
                            htmlDiv += "</div>";
                            htmlDiv += " <div class='clearfix'></div>";

                        }

                        htmlDiv += "<div class='br_left_1'></div>" +
                       "<div class='clearfix'></div>" +
                        "<p class='text-center center-block text_gray'><img src='../Content/images/AirlineLogo/medium/" + Data.Items[i].Sectors[p].AirlineCode + "_M.png' alt='' class='icon_flight_details'> <span class='left_spc'> " + Data.Items[i].Sectors[p].AirlineName + " " + Data.Items[i].Sectors[p].FltNum + " <strong>|</strong>    " + Data.Items[i].Sectors[p].CabinClass.Name + "</span>  </p>" +
                       "<div class='clearfix'></div>" +
                         "<div class='row'>  " +
                         " <div class='wid_40'>" +
                            " <span class='loc_fli_det right_side'>" + Data.Items[i].Sectors[p].Departure.AirportCode + "</span><span class='time_fli_det right_side'>" + Data.Items[i].Sectors[p].Departure.Time + "</span>" +
                            " <div class='clearfix'></div>" +
                            " <span class='loc_fli_date  text-right'>" + Data.Items[i].Sectors[p].Departure.Date + "</span>" +
                             " <span class='loc_fli_adres  text-right'> " + Data.Items[i].Sectors[p].Departure.AirportCityName + "";
                        if (Data.Items[i].Sectors[p].Departure.Terminal != "") {
                            htmlDiv += ",Terminal " + Data.Items[i].Sectors[p].Departure.Terminal + "";
                        }
                        htmlDiv += "</span>";
                        htmlDiv += " <div class='clearfix'></div>" +

                             " </div>" +
                         "  <div class='wid_20 pd_0'>" +
                    "    <img src='/content/images/icon_flight_details.png' alt='' class='center-block'>" +

                     " </div>" +
                      "  <div class='wid_40'>  " +
                "  <span class='loc_fli_det left_side m_l_0'>" + Data.Items[i].Sectors[p].Arrival.AirportCode + "</span><span class='time_fli_det left_side'>" + Data.Items[i].Sectors[p].Arrival.Time + "</span>" +
                "  <div class='clearfix'></div>" +
                " <span class='loc_fli_date  text-left'>" + Data.Items[i].Sectors[p].Arrival.Date + "</span>" +
                "   <span class='loc_fli_adres  text-left'>" + Data.Items[i].Sectors[p].Arrival.AirportCityName + "";
                        if (Data.Items[i].Sectors[p].Arrival.Terminal != "") {
                            htmlDiv += ",Terminal " + Data.Items[i].Sectors[p].Arrival.Terminal + "";
                        }
                        htmlDiv += "</span>";
                        htmlDiv += "<div class='clearfix'></div>" +
                          "   </div>" +
                      "  <div class='clearfix'></div>" +

                      " </div>";
                    }
                }

            }




            if (isR == true) {

                if (sectorLenght > 0) {
                    if (bagg != "") {
                        htmlDiv += "<div class='br_left_1'></div><div class='bag_box'>" +
                       "  <span class='pull-left text-left'><i class='fa fa-suitcase'></i> " + bagg + " Baggage</span>   <span class='pull-right text-right'> <i class='fa fa-clock-o'></i>    " + acttime + "</span></div>";
                    }
                    htmlDiv += "  <div class='clearfix'></div>";

                }
            }
            htmlDiv += "</div>";

            htmlDiv += "</div>";


















            $('#firstlListView').html(htmlDiv);
        }






    }
}
function GetPaxCount(TempItinerary) {

    var Adult;
    if (TempItinerary != null && TempItinerary != undefined) {

        Adult = TempItinerary.AdultInfo.NoAdult;
        var Child = 0;
        if (TempItinerary.Child != undefined)
            Child = TempItinerary.ChildInfo.NoChild;
        var Infant = 0;
        if (TempItinerary.Infant != undefined)
            Infant = TempItinerary.InfantInfo.NoInfant;
        PaxHeading = " " + Adult + "Adults, " + (Number(Child) + Number(Infant)) + " Child(ren)";
    }
    return (Number(Adult) + Number(Child) + Number(Infant));
}

function CheckDateForHold(temp) {
    var today = new Date();
    var td = today.getDate();
    var tm = today.getMonth();
    var ty = today.getFullYear();
    // var tomorrow = new Date(ty, tm, td + 1) // date after 1
    // var retDat = new Date(ty, tm, td + 7)  // date after 7
    var checkDate = new Date(ty, tm, td + 2); // date after 2

    var arr = temp.split("-");
    var d = arr[0];
    var m = arr[1];
    var y = arr[2];
    var deptDate = new Date(y, m - 1, d);
    if (deptDate > checkDate) {
        return true;
    }
    else {
        return false;
    }

}
function Show_FlightDetail(Data, i, firstRetsectIndex, sectorLenght) {

    var noOfDepSec = 0;
    var noOfRetSec = 0;
    for (var p = 0; p < sectorLenght; p++) {
        if (Data.Items[i].Sectors[p].IsReturn == "false") {
            noOfDepSec++;
        }
        if (Data.Items[i].Sectors[p].IsReturn == "true") {
            noOfRetSec++;
        }
    }
    if (sectorLenght == 0)
        noOfDepSec = 1;

    var depFromDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[0].Departure.Date;

    depFromDate = GetDateFormat(depFromDate);
    var _depSect = parseInt(noOfDepSec) - 1;

    $depDivHead = "<div class='col-md-12 col-xs-12 col-sm-12 leave-blue'>" +
                       " Leave: " + depFromDate + "" +
                  "</div>";

    $("#DivFlightDetail" + i).append($depDivHead);

    for (var p = 0; p < noOfDepSec; p++) {
        var DepFromTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Time : Data.Items[i].Sectors[p].Departure.Time;
        var DepFromDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[p].Departure.Date;
        DepFromDate = GetDateFormat(DepFromDate);
        var DepFromAirportName = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirpName : Data.Items[i].Sectors[p].Departure.AirpName;
        var DepFromAirportCode = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirpCode : Data.Items[i].Sectors[p].Departure.AirpCode;

        var DepToTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Time : Data.Items[i].Sectors[p].Arrival.Time;
        var DepToDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Date : Data.Items[i].Sectors[p].Arrival.Date;
        DepToDate = GetDateFormat(DepToDate);
        var DepToAirportName = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirpName : Data.Items[i].Sectors[p].Arrival.AirpName;
        var DepToAirportCode = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirpCode : Data.Items[i].Sectors[p].Arrival.AirpCode;

        var AirlineName = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineName : Data.Items[i].Sectors[p].AirlineName;
        var AirlineAirV = (sectorLenght == 0) ? Data.Items[i].Sectors.AirV : Data.Items[i].Sectors[p].AirV;
        var AirlineDes = (sectorLenght == 0) ? Data.Items[i].Sectors.CabinClass.Des : Data.Items[i].Sectors[p].CabinClass.Des;
        var AirlineCode = (sectorLenght == 0) ? Data.Items[i].Sectors.CabinClass.Code : Data.Items[i].Sectors[p].CabinClass.Code;
        var AirlineEquipType = (sectorLenght == 0) ? Data.Items[i].Sectors.EquipType : Data.Items[i].Sectors[p].EquipType;
        var AirlineActualTime = (sectorLenght == 0) ? Data.Items[i].Sectors.ActualTime : Data.Items[i].Sectors[p].ActualTime;
        var AirlineElapsedTime = (sectorLenght == 0) ? Data.Items[i].Sectors.ElapsedTime : Data.Items[i].Sectors[p].ElapsedTime;

        var AirlineTransitTime = (sectorLenght == 0) ? Data.Items[i].Sectors.TransitTime : Data.Items[i].Sectors[p].TransitTime;
        var stopNumber = p;
        if (AirlineTransitTime["@time"] != "00:00") {
            $secStop = "<div class='col-md-12 col-xs-12 stop-1'>" +
                            "<ul>" +
                                "<li>" +
                                "Stop " + stopNumber + "" +
                                "</li>" +
                                "<li>" +
                                "" + AirlineTransitTime["#text"] + "" +
                                "</li>" +
                               // "<li>" +
                               //    " <i class='fa fa-dot-circle-o' style='color: #a3a3a3 !important;'></i> Change Plane" +
                               //" </li>" +
                            "</ul>" +
                        "</div>";
            $("#DivFlightDetail" + i).append($secStop);
        }
        $secDiv1 = "<div class='col-md-2 col-xs-5'>" +
                        "<span class='date-month'>" + DepFromTime + "</span><br />" +
                        "<span class='date-small'> " + DepFromDate + " </span>" +
                   "</div>";
        $("#DivFlightDetail" + i).append($secDiv1);
        $secDiv2 = "<div class='col-md-1 col-xs-2'>" +
                        "<i class='fa fa-long-arrow-right fa-lg'></i>" +
                   "</div>";
        $("#DivFlightDetail" + i).append($secDiv2);
        $secDiv3 = "<div class='col-md-2 col-xs-5'>" +
                        "<span class='date-month'>" + DepToTime + "</span><br />" +
                        "<span class='date-small'> " + DepToDate + " </span>" +
                   "</div>";
        $("#DivFlightDetail" + i).append($secDiv3);
        $secDiv4 = "<div class='col-md-2 col-xs-12'>" +
                        "<span class='date-month'>" + AirlineElapsedTime + "</span><br />" +
                    "</div>";
        $("#DivFlightDetail" + i).append($secDiv4);
        $secDiv5 = "<div class='col-md-5 col-xs-12'></div>";
        $("#DivFlightDetail" + i).append($secDiv5);

        $secDiv6 = "<div class='col-md-12 col-xs-12 airlinedetail'>" +
                        "<ul>" +
                            "<li>" +
                            "" + DepFromAirportName + " (" + DepFromAirportCode + ") to " + DepToAirportName + " (" + DepToAirportCode + ")" +
                            "</li>" +
                            "<li>" +
                            "" + AirlineName + "" + AirlineAirV + "" +
                            "</li>" +
                            "<li>" +
                               " |" +
                            "</li>" +
                            "<li>" +
                            ////"" + AirlineDes + " / Coach (" + AirlineCode + ")" +
                               "" + AirlineDes + "" +
                           " </li>" +
                            "<li>" +
                               " |" +
                            "</li>" +
                            "<li>" +
                           "" + AirlineEquipType + "" +
                            "</li>" +
                        "</ul>" +
                    "</div>";
        $("#DivFlightDetail" + i).append($secDiv6);

    }

    var chkRetIndx = 0;
    for (var p = 0; p < noOfRetSec; p++) {
        var RetFromTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Time : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Departure.Time;
        var RetFromDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.Date : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Departure.Date;
        RetFromDate = GetDateFormat(RetFromDate);
        var RetFromAirportName = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirpName : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Departure.AirpName;
        var RetFromAirportCode = (sectorLenght == 0) ? Data.Items[i].Sectors.Departure.AirpCode : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Departure.AirpCode;

        var RetToTime = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Time : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Arrival.Time;
        var RetToDate = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.Date : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Arrival.Date;
        RetToDate = GetDateFormat(RetToDate);
        var RetToAirportName = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirpName : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Arrival.AirpName;
        var RetToAirportCode = (sectorLenght == 0) ? Data.Items[i].Sectors.Arrival.AirpCode : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].Arrival.AirpCode;

        var AirlineName = (sectorLenght == 0) ? Data.Items[i].Sectors.AirlineName : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].AirlineName;
        var AirlineAirV = (sectorLenght == 0) ? Data.Items[i].Sectors.AirV : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].AirV;
        var AirlineDes = (sectorLenght == 0) ? Data.Items[i].Sectors.CabinClass.Des : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].CabinClass.Des;
        var AirlineCode = (sectorLenght == 0) ? Data.Items[i].Sectors.CabinClass.Code : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].CabinClass.Code;
        var AirlineEquipType = (sectorLenght == 0) ? Data.Items[i].Sectors.EquipType : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].EquipType;
        var AirlineActualTime = (sectorLenght == 0) ? Data.Items[i].Sectors.ActualTime : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].ActualTime;
        var AirlineElapsedTime = (sectorLenght == 0) ? Data.Items[i].Sectors.ElapsedTime : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].ElapsedTime;

        var AirlineTransitTime = (sectorLenght == 0) ? Data.Items[i].Sectors.TransitTime : Data.Items[i].Sectors[firstRetsectIndex + chkRetIndx].TransitTime;
        var stopNumber = p;
        if (stopNumber == 0) {
            $secRetDiv1 = "<div class='clearfix'></div><hr />";
            $("#DivFlightDetail" + i).append($secRetDiv1);

            $secRetDiv2 = "<div class='col-md-12 leave-green'>Leave:" + RetFromDate + "</div>";
            $("#DivFlightDetail" + i).append($secRetDiv2);
        }
        if (AirlineTransitTime["@time"] != "00:00") {
            $secStop = "<div class='col-md-12 col-xs-12 stop-1'>" +
                            "<ul>" +
                                "<li>" +
                                "Stop " + stopNumber + "" +
                                "</li>" +
                                "<li>" +
                                "" + AirlineTransitTime["#text"] + "" +
                                "</li>" +
                               // "<li>" +
                               //    " <i class='fa fa-dot-circle-o' style='color: #a3a3a3 !important;'></i> Change Plane" +
                               //" </li>" +
                            "</ul>" +
                        "</div>";
            $("#DivFlightDetail" + i).append($secStop);
        }
        $secDiv1 = "<div class='col-md-2 col-xs-5'>" +
                        "<span class='date-month'>" + RetFromTime + "</span><br />" +
                        "<span class='date-small'> " + RetFromDate + " </span>" +
                   "</div>";
        $("#DivFlightDetail" + i).append($secDiv1);
        $secDiv2 = "<div class='col-md-1 col-xs-2'>" +
                        "<i class='fa fa-long-arrow-right fa-lg'></i>" +
                   "</div>";
        $("#DivFlightDetail" + i).append($secDiv2);
        $secDiv3 = "<div class='col-md-2 col-xs-5'>" +
                        "<span class='date-month'>" + RetToTime + "</span><br />" +
                        "<span class='date-small'> " + RetToDate + " </span>" +
                   "</div>";
        $("#DivFlightDetail" + i).append($secDiv3);
        $secDiv4 = "<div class='col-md-2 col-xs-12'>" +
                        "<span class='date-month'>" + AirlineElapsedTime + "</span><br />" +
                    "</div>";
        $("#DivFlightDetail" + i).append($secDiv4);
        $secDiv5 = "<div class='col-md-5 col-xs-12'></div>";
        $("#DivFlightDetail" + i).append($secDiv5);

        $secDiv6 = "<div class='col-md-12 col-xs-12 airlinedetail'>" +
                        "<ul>" +
                            "<li>" +
                            "" + RetFromAirportName + " (" + RetFromAirportCode + ") to " + RetToAirportName + " (" + RetToAirportCode + ")" +
                            "</li>" +
                            "<li>" +
                            "" + AirlineName + "" + AirlineAirV + "" +
                            "</li>" +
                            "<li>" +
                               " |" +
                            "</li>" +
                            "<li>" +
                            //"" + AirlineDes + " / Coach (" + AirlineCode + ")" +
                              "" + AirlineDes + "" +
                           " </li>" +
                            "<li>" +
                               " |" +
                            "</li>" +
                            "<li>" +
                           "" + AirlineEquipType + "" +
                            "</li>" +
                        "</ul>" +
                    "</div>";
        $("#DivFlightDetail" + i).append($secDiv6);
        chkRetIndx++;
    }
}