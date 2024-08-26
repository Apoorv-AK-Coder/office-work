document.addEventListener('DOMContentLoaded', () => {
    const slidesContainer = document.querySelector(".slides");
    const slides = document.querySelectorAll(".slide1");
    const prevButton = document.querySelector(".leftBt i");
    const nextButton = document.querySelector(".rightBt i");

    const slidesToShow = 5;
    const totalSlides = slides.length;
    let currentIndex = 0;

    function updateSlidePosition() {
        const offset = (100 / slidesToShow) * currentIndex;
        slidesContainer.style.transform = `translateX(-${offset}%)`;
        prevButton.style.display = currentIndex === 0 ? 'none' : 'block';
        nextButton.style.display = currentIndex >= totalSlides - slidesToShow ? 'none' : 'block';
    }

    function nextSlide() {
        if (currentIndex < totalSlides - slidesToShow) {
            currentIndex++;
        }
        updateSlidePosition();
    }

    function prevSlide() {
        if (currentIndex > 0) {
            currentIndex--;
        }
        updateSlidePosition();
    }

    function handleMouseWheel(event) {
        event.preventDefault();
        if (event.deltaY > 0) {
            nextSlide();
        } else {
            prevSlide();
        }
    }

    slidesContainer.addEventListener('wheel', handleMouseWheel);
    nextButton.addEventListener('click', nextSlide);
    prevButton.addEventListener('click', prevSlide);
    updateSlidePosition();
});