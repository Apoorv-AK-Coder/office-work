//mobile hamburger
setInterval(mufun, 1000);
function mufun() {
    let b1 = document.getElementById("on");
    let b2 = document.getElementById("off");
    let view = document.getElementById("view");
    let arrow = document.getElementById("arrowicon");

    b1.addEventListener("click", function () {
        if ((view.style.display = "none")) {
            view.style.display = "block";
            arrow.style.display = "none";
        }
    })

    b2.addEventListener("click", function () {
        if ((view.style.display = "block")) {
            view.style.display = "none";
            arrow.style.display = "block";
        }
    })
}


//tabs
function TabFun() {
    // Get all tab sections
    const tabSections = document.querySelectorAll(".tabs");

    // Loop through each tab section
    tabSections.forEach((section) => {
        const tabs = section.querySelectorAll("[id^='tab']");
        const tabDetails = section.querySelectorAll("[id^='tabdetail']");

        // Initial setup: underline the first tab in each section
        tabs[0].style.borderBottom = "2px solid var(--primary-color)";
        tabs[0].style.color = "var(--primary-color)";
        tabDetails[0].style.display = "block"; // Show the first tab detail

        tabs.forEach((tab, index) => {
            tab.addEventListener("click", () => {
                tabDetails.forEach((detail, detailIndex) => {
                    if (detailIndex === index) {
                        detail.style.display = "block";
                        tabs[detailIndex].style.borderBottom = "2px solid var(--primary-color)";
                        tabs[detailIndex].style.color = "var(--primary-color)";
                    } else {
                        detail.style.display = "none";
                        tabs[detailIndex].style.border = "none";
                        tabs[detailIndex].style.color = "var(--fifth-color)";
                    }
                });
            });
        });
    });
}


// Run TabFun on page load to set initial state
document.addEventListener("DOMContentLoaded", () => {
    TabFun();
});


//faq section
document.addEventListener("DOMContentLoaded", function () {
    const buttons = [
        { click: "click1", on: "faqon", off: "faqoff", view: "faq1" },
        { click: "click2", on: "faqon1", off: "faqoff1", view: "faq2" },
        { click: "click3", on: "faqon2", off: "faqoff2", view: "faq3" },
        { click: "click4", on: "faqon3", off: "faqoff3", view: "faq4" },
        { click: "click5", on: "faqon4", off: "faqoff4", view: "faq5" },
        { click: "click6", on: "faqon5", off: "faqoff5", view: "faq6" },
        { click: "click7", on: "faqon6", off: "faqoff6", view: "faq7" },
        { click: "click8", on: "faqon7", off: "faqoff7", view: "faq8" },
        { click: "click9", on: "faqon8", off: "faqoff8", view: "faq9" },
        { click: "click10", on: "faqon9", off: "faqoff9", view: "faq10" }
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



// navigation active on click
const currentPage = window.location.pathname.split("/").pop() || 'index.html';
const navLinks = document.querySelectorAll('ul li a');
navLinks.forEach(link => {
    if (link.getAttribute('href') === `./${currentPage}` || currentPage === '') {
        link.parentElement.classList.add('active');
    }
});


// form placeholder
const fields = document.querySelectorAll('.calendar, .calendar1, .user, .location, .location1');

fields.forEach(field => {
    field.addEventListener('input', function () {
        if (this.value) {
            this.classList.add('typing');
        } else {
            this.classList.remove('typing');
        }
    });
});