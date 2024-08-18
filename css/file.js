setInterval(mufun, 1000);
function mufun() {
    let b1 = document.getElementById("on");
    let b2 = document.getElementById("off");
    let view = document.getElementById("view");

    b1.addEventListener("click", function () {
        if ((view.style.display = "none")) {
            view.style.display = "block";

        }
    })

    b2.addEventListener("click", function () {
        if ((view.style.display = "block")) {
            view.style.display = "none";
        }
    })
}

setInterval(mufun, 1000);
function mufun() {
    let d1 = document.getElementById("stays");
    let d2 = document.getElementById("flights");
    let d3 = document.getElementById("car");
    let d4 = document.getElementById("package");
    let view1 = document.getElementById("onstay");
    let view2 = document.getElementById("onflight");
    let view3 = document.getElementById("oncar");
    let view4 = document.getElementById("onpackage");



    d1.addEventListener("click", function () {
        if ((view1.style.display = "none")) {
            view1.style.display = "block";
            view2.style.display = "none";
            view3.style.display = "none";
            view4.style.display = "none";
            d1.style.borderBottom = "2px solid #FDDB32";
            d2.style.border = "none";
            d3.style.border = "none";
            d4.style.border = "none";

        }
    })

    d2.addEventListener("click", function(){
        if((view2.style.display = "none")) {
            view1.style.display = "none";
            view2.style.display = "block";
            view3.style.display = "none";
            view4.style.display = "none";
            d1.style.border = "none";
            d2.style.borderBottom = "2px solid #FDDB32";
            d3.style.border = "none";
            d4.style.border = "none";
        }
    })

    d3.addEventListener("click", function(){
        if((view3.style.display = "none")) {
            view1.style.display = "none";
            view2.style.display = "none";
            view3.style.display = "block";
            view4.style.display = "none";
            d1.style.border = "none";
            d2.style.border = "none";
            d3.style.borderBottom = "2px solid #FDDB32";
            d4.style.border = "none";
        }
    })

    d4.addEventListener("click", function(){
        if((view4.style.display = "none")) {
            view1.style.display = "none";
            view2.style.display = "none";
            view3.style.display = "none";
            view4.style.display = "block";
            d1.style.border = "none";
            d2.style.border = "none";
            d3.style.border = "none";
            d4.style.borderBottom = "2px solid #FDDB32";
        }
    })
}