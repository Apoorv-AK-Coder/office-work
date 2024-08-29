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
            arrow.style.zIndex = "-9999 !important";
        }
    })

    b2.addEventListener("click", function () {
        if ((view.style.display = "block")) {
            view.style.display = "none";
        }
    })
}


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



// submenu
document.addEventListener('DOMContentLoaded', () => {
    const sections = {
        airlines: document.getElementById('airlinesnav'),
        amtrak: document.getElementById('amtraknav'),
        travel: document.getElementById('travelnav')
    };

    const buttons = {
        airlines: document.getElementById('airlines'),
        amtrak: document.getElementById('amtrak'),
        travel: document.getElementById('travel')
    };

    function toggleSection(sectionToToggle) {
        const section = sections[sectionToToggle];
        const isVisible = section.style.display === 'block';
        Object.values(sections).forEach(sec => sec.style.display = 'none');
        
        if (!isVisible) {
            section.style.display = 'block';
        }
    }

    Object.keys(buttons).forEach(key => {
        buttons[key].addEventListener('click', () => toggleSection(key));
    });
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