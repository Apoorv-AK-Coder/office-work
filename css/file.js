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

document.addEventListener("DOMContentLoaded", function () {
    const buttons = [
        { click:"click1", on: "faqon", off: "faqoff", view: "faq1" },
        { click:"click2", on: "faqon1", off: "faqoff1", view: "faq2" },
        { click:"click3", on: "faqon2", off: "faqoff2", view: "faq3" },
        { click:"click4", on: "faqon3", off: "faqoff3", view: "faq4" },
        { click:"click5", on: "faqon4", off: "faqoff4", view: "faq5" },
        { click:"click6", on: "faqon5", off: "faqoff5", view: "faq6" },
        { click:"click7", on: "faqon6", off: "faqoff6", view: "faq7" },
        { click:"click8", on: "faqon7", off: "faqoff7", view: "faq8" },
        { click:"click9", on: "faqon8", off: "faqoff8", view: "faq9" },
        { click:"click10", on: "faqon9", off: "faqoff9", view: "faq10" }
    ];

    buttons.forEach(({ click, on, off, view }) => {
        const clickButton = document.getElementById(click);
        const onButton = document.getElementById(on);
        const offButton = document.getElementById(off);
        const viewElement = document.getElementById(view);

        clickButton.addEventListener("click", function () {
            if (viewElement.style.display === "none" || viewElement.style.display === "") {
                viewElement.style.display = "block";
                onButton.style.display = "none";
                offButton.style.display = "block";
            } else {
                viewElement.style.display = "none";
                onButton.style.display = "block";
                offButton.style.display = "none";
            }
        });
    });
});


const currentPage = window.location.pathname.split("/").pop() || 'index.html';
const navLinks = document.querySelectorAll('ul li a');
navLinks.forEach(link => {
    if (link.getAttribute('href') === `./${currentPage}` || currentPage === '') {
        link.parentElement.classList.add('active');
    }
});


setInterval(submenu, 1000);
function submenu() {
    let airlinesnav = document.getElementById("airlinesnav");
    let amtrak = document.getElementById("amtraknav");
    let travelnav = document.getElementById("travelnav");

    let airlines = document.getElementById('airlines');
    let amtraka = document.getElementById('amtrak');
    let travel = document.getElementById('travel');

    let close = document.getElementById('close');
    let close1 = document.getElementById('close1');
    let close2 = document.getElementById('close2');

    airlines.addEventListener("click", function () {
        if ((airlinesnav.style.display = "none")) {
            airlinesnav.style.display = "block";
            amtrak.style.display = "none";
            travelnav.style.display = "none";
        }
    })

    amtraka.addEventListener("click", function () {
        if ((amtrak.style.display = "none")) {
            amtrak.style.display = "block";
            travelnav.style.display = "none";
            airlinesnav.style.display = "none";
        }
    })

    travel.addEventListener("click", function () {
        if ((travelnav.style.display = "none")) {
            travelnav.style.display = "block";
            amtrak.style.display = "none";
            airlinesnav.style.display = "none";
        }
    })

    close.addEventListener("click", function() {
        airlinesnav.style.display = "none";
    })

    close1.addEventListener("click", function() {
            amtrak.style.display = "none";
    })

    close2.addEventListener("click", function() {
            travelnav.style.display = "none";
    })
}