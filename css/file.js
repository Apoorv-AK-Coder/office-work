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
        { on: "faqon7", off: "faqoff7", view: "faq8" },
        { on: "faqon8", off: "faqoff8", view: "faq9" },
        { on: "faqon9", off: "faqoff9", view: "faq10" }
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
