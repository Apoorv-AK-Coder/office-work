function DisplayError(e) {
    var t = document.getElementById(e);
    t.style.display = "block"
}

function HideError(e) {
    var t = document.getElementById(e);
    t.style.display = "none"
}

function toDate(e, t) {
    var n = new Date;
    if (t == "h:m") {
        n.setHours(e.substr(0, e.indexOf(":")));
        n.setMinutes(e.substr(e.indexOf(":") + 1));
        n.setSeconds(0);
        return n
    } else {
        return "Invalid Format"
    }
}

function setVar(e) {
    min = 0;
    sec = 59;
    clearInterval(int1);
    min = e;
    min = min - 1;
    int1 = self.setInterval("MiliSec()", 1e3)
}

function MiliSec() {
    if (min == 0 && sec == 0) {
        clearInterval(int1);
        callSessionTimeOut()
    }
    if (sec > 0) {
        document.getElementById("watch").value = "This page will expire in " + min + ":" + sec + " minutes.";
        sec = sec - 1;
        if (sec < 10) {
            sec = "0" + sec
        }
    } else {
        sec = 60;
        min = min - 1;
        if (min < 10) {
            min = "0" + min
        }
        if (min > 0) {
            document.getElementById("watch").value = "This page will expire in " + min + ":" + sec + " minutes."
        } else {
            document.getElementById("watch").value = "This page is expired"
        }
    }
}

function callSessionTimeOut() {
    $(".sessionpop").show();
    return true
}

function isInteger(e) {
    var t;
    for (t = 0; t < e.length; t++) {
        var n = e.charAt(t);
        if (n < "0" || n > "9") return false
    }
    return true
}

function stripCharsInBag(e, t) {
    var n;
    var r = "";
    for (n = 0; n < e.length; n++) {
        var i = e.charAt(n);
        if (t.indexOf(i) == -1) return String += i
    }
    return r
}

function daysInFebruary(e) {
    return e % 4 == 0 && (!(e % 100 == 0) || e % 400 == 0) ? 29 : 28
}

function DaysArray(e) {
    for (var t = 1; t <= e; t++) {
        this[t] = 31;
        if (t == 4 || t == 6 || t == 9 || t == 11) {
            this[t] = 30
        }
        if (t == 2) {
            this[t] = 29
        }
    }
    return this
}
var int1;
var sec = 59;
var min;
var dtCh = "/";
var minYear = 1900;
var maxYear = 2100