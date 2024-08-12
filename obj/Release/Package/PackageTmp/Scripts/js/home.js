var urlis = window.location.pathname.replace('/', '');
$("#lbl_flight1").hide();

$(document).ready(function () {
    $("#btn_search").removeClass('loading');
    $(".more-btn").click(function () {
        $(".more-content").slideToggle('slow');
        $(".more-btn").toggleClass("chevron-up chevron-down");
    });
});



$('.ssk-email').click(function () {
    $(".enquiry-form").toggle('slow');
});
$('.close-enq').click(function () {
    $(".enquiry-form").toggle('slow');
});



$(function () {
    if (urlis != 'flights') {
        $('#Destination').autocomplete({
            source: function (request, response) {
                var airport = new Array();
                $.ajax({
                    async: false,
                    cache: false,
                    type: "POST",
                    url: "/Home/AutoFillVacation",
                    data: { "term": request.term },
                    success: function (data) {
                        for (var i = 0; i < data.length; i++) {
                            airport[i] = { label: data[i].Destination };
                            $.ui.autocomplete.prototype._renderItem = function (ul, item) {
                                var re = new RegExp("(" + request.term + ")", "gi");
                                var t = item.label.replace(re, "<u>$1</u>");
                                return $("<li></li>")
                                .data("item.autocomplete", item)
                                .append(t)
                                .appendTo(ul);
                            };
                        }
                    },
                    error: function (jq, status, message) {
                        //  alert('Error has occurred while fetching Airport list. Status: ' + status + ' - Message: ' + message);
                    }
                });
                response(airport.slice(0, 10));
                $("ul#ui-id-6").find(".ui-menu-item").addClass("vac");
            },
            minLength: 2
        });
    }
});