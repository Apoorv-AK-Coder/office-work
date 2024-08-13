fetch('./header.html')
    .then((response) => response.text())
    .then((data) => {
        document.querySelector("header").innerHTML = data;
    });

// for the footer

fetch('./footer.html')
    .then((response) => response.text())
    .then((data) => {
        document.querySelector("footer").innerHTML = data;
    });

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