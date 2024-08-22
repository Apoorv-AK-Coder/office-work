document.addEventListener('DOMContentLoaded', () => {
    const slidesContainer = document.querySelector('.slides');
    const slides5 = document.querySelectorAll('.slide1');
    const prevButton = document.querySelector('.leftBt i');
    const nextButton = document.querySelector('.rightBt i');

    const slidesToShow = 1; // Number of slides to show at once
    const totalSlides = slides5.length;
    let currentIndex = 0;

    function updateSlidePosition() {
        const slideWidth = slides5[0].getBoundingClientRect().width;
        const offset = (100 / slidesToShow) * currentIndex;
        slidesContainer.style.transform = `translateX(-${offset}%)`;

        prevButton.style.display = currentIndex === 0 ? 'none' : 'block';
        nextButton.style.display = currentIndex >= totalSlides - slidesToShow ? 'none' : 'block';
    }

    function nextSlide() {
        if (currentIndex < totalSlides - slidesToShow) {
            currentIndex++;
        } else {
            currentIndex = 0; // Loop back to the beginning
        }
        updateSlidePosition();
    }

    function prevSlide() {
        if (currentIndex > 0) {
            currentIndex--;
        } else {
            currentIndex = totalSlides - slidesToShow; // Loop to the end
        }
        updateSlidePosition();
    }

    // Event listeners for navigation buttons
    nextButton.addEventListener('click', nextSlide);
    prevButton.addEventListener('click', prevSlide);

    // Initialize slider position
    updateSlidePosition();
});