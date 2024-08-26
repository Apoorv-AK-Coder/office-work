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
    const buttons = [
        { on: "faqon", off: "faqoff", view: "faq1" },
        { on: "faqon1", off: "faqoff1", view: "faq2" },
        { on: "faqon2", off: "faqoff2", view: "faq3" },
        { on: "faqon3", off: "faqoff3", view: "faq4" },
        { on: "faqon4", off: "faqoff4", view: "faq5" },
        { on: "faqon5", off: "faqoff5", view: "faq6" },
        { on: "faqon6", off: "faqoff6", view: "faq7" },
    ];

    buttons.forEach(({ on, off, view }) => {
        const onButton = document.getElementById(on);
        const offButton = document.getElementById(off);
        const viewElement = document.getElementById(view);

        onButton.addEventListener("click", function () {
            if (viewElement.style.display = "none") {
                viewElement.style.display = "block";
                onButton.style.display = "none";
                offButton.style.display = "block";
            }
        });

        offButton.addEventListener("click", function () {
            if (viewElement.style.display = "block") {
                viewElement.style.display = "none";
                onButton.style.display = "block";
                offButton.style.display = "none";
            }
        });
    });
}

// Get the current page's URL
const currentPage = window.location.pathname.split("/").pop() || 'index.html';

// Select all navigation links
const navLinks = document.querySelectorAll('ul li a');

navLinks.forEach(link => {
    // Check if the href of the link matches the current page or if it's the root page
    if (link.getAttribute('href') === `./${currentPage}` || currentPage === '') {
        // Add the active class to the parent li
        link.parentElement.classList.add('active');
    }
});


setInterval(submenu, 1000);
function submenu() {
    let airlinesnav = document.getElementsByClassName("airlinesnav");
    let amtrak = document.getElementsByClassName("amtraknav");
    let travelnav = document.getElementsByClassName("travelnav");

    let hoverairlines = document.getElementById('majorairlines');

    hoverairlines.addEventListener('mouseenter', () => {
        if (airlinesnav.style.display = 'none') {
            airlinesnav.style.display = 'block';
            console.log("hello");
        }
    });
    // console.log(airlines);


    //     const menuItems = document.querySelectorAll('ul > li');

    // // Add event listeners to each parent item
    // menuItems.forEach(item => {
    //     item.addEventListener('mouseenter', () => {
    //         // Show the submenu on hover
    //         const submenu = item.querySelector('.airlinesnav, .amtracnav');
    //         if (submenu) {
    //             submenu.style.display = 'block';
    //         }
    //     });

    //     item.addEventListener('mouseleave', () => {
    //         // Hide the submenu when not hovering
    //         const submenu = item.querySelector('.airlinesnav, .amtracnav');
    //         if (submenu) {
    //             submenu.style.display = 'none';
    //         }
    //     });
    // });
}