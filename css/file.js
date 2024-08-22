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

setInterval(myfunction, 1000);
function myfunction() {
    let d1 = document.getElementById("trip");
    let d2 = document.getElementById("map");
    let d3 = document.getElementById("app");
    let d4 = document.getElementById("access");
    let view1 = document.getElementById("section1");
    let view2 = document.getElementById("section2");
    let view3 = document.getElementById("section3");
    let view4 = document.getElementById("section4");



    d1.addEventListener("click", function () {
        if ((view1.style.display = "none")) {
            view1.style.display = "block";
            view2.style.display = "none";
            view3.style.display = "none";
            view4.style.display = "none";
            d1.style.backgroundColor = "rgba(20, 20, 20, 0.05)";
            d2.style.backgroundColor = "transparent";
            d3.style.backgroundColor = "transparent";
            d4.style.backgroundColor = "transparent";

        }
    })

    d2.addEventListener("click", function(){
        if((view2.style.display = "none")) {
            view1.style.display = "none";
            view2.style.display = "block";
            view3.style.display = "none";
            view4.style.display = "none";
            d1.style.backgroundColor = "transparent";
            d2.style.backgroundColor = "rgba(20, 20, 20, 0.05)";
            d3.style.backgroundColor = "transparent";
            d4.style.backgroundColor = "transparent";
        }
    })

    d3.addEventListener("click", function(){
        if((view3.style.display = "none")) {
            view1.style.display = "none";
            view2.style.display = "none";
            view3.style.display = "block";
            view4.style.display = "none";
            d1.style.backgroundColor = "transparent";
            d2.style.backgroundColor = "transparent";
            d3.style.backgroundColor = "rgba(20, 20, 20, 0.05)";
            d4.style.backgroundColor = "transparent";
        }
    })

    d4.addEventListener("click", function(){
        if((view4.style.display = "none")) {
            view1.style.display = "none";
            view2.style.display = "none";
            view3.style.display = "none";
            view4.style.display = "block";
            d1.style.backgroundColor = "transparent";
            d2.style.backgroundColor = "transparent";
            d3.style.backgroundColor = "transparent";
            d4.style.backgroundColor = "rgba(20, 20, 20, 0.05)";
        }
    })
}