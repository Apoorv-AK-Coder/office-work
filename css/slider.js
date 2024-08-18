// document.addEventListener('DOMContentLoaded', () => {
//     const slidesContainer = document.querySelector('.slides');
//     const slides5 = document.querySelectorAll('.slide1');
//     const prevButton = document.querySelector('.leftBt i');
//     const nextButton = document.querySelector('.rightBt i');

//     const slidesToShow = 4; // Number of slides to show at once
//     const totalSlides = slides5.length;
//     let currentIndex = 0;

//     function updateSlidePosition() {
//         const slideWidth = slides5[0].getBoundingClientRect().width;
//         const offset = (100 / slidesToShow) * currentIndex;
//         slidesContainer.style.transform = `translateX(-${offset}%)`;
//         prevButton.style.pointerEvents = currentIndex === 0 ? 'none' : 'auto';
//         nextButton.style.pointerEvents = currentIndex >= totalSlides - slidesToShow ? 'none' : 'auto';
//     }

//     function nextSlide() {
//         if (currentIndex < totalSlides - slidesToShow) {
//             currentIndex++;
//         } else {
//             currentIndex = 0; // Loop back to the beginning
//         }
//         updateSlidePosition();
//     }

//     function prevSlide() {
//         if (currentIndex > 0) {
//             currentIndex--;
//         } else {
//             currentIndex = totalSlides - slidesToShow; // Loop to the end
//         }
//         updateSlidePosition();
//     }

//     // Event listeners for navigation buttons
//     nextButton.addEventListener('click', nextSlide);
//     prevButton.addEventListener('click', prevSlide);

//     // Initialize slider position
//     updateSlidePosition();
// });


// /* new slider */

// document.addEventListener('DOMContentLoaded', () => {
//     const slidesContainer = document.querySelector('.slides1');
//     const slides6 = document.querySelectorAll('.slide2');
//     const prevButton = document.querySelector('.leftBtn i');
//     const nextButton = document.querySelector('.rightBtn i');

//     const slidesToShow = 4; // Number of slides to show at once
//     const totalSlides = slides6.length;
//     let currentIndex = 0;

//     function updateSlidePosition() {
//         const slideWidth = slides6[0].getBoundingClientRect().width;
//         const offset = (100 / slidesToShow) * currentIndex;
//         slidesContainer.style.transform = `translateX(-${offset}%)`;
//         prevButton.style.pointerEvents = currentIndex === 0 ? 'none' : 'auto';
//         nextButton.style.pointerEvents = currentIndex >= totalSlides - slidesToShow ? 'none' : 'auto';
//     }

//     function nextSlide() {
//         if (currentIndex < totalSlides - slidesToShow) {
//             currentIndex++;
//         } else {
//             currentIndex = 0; // Loop back to the beginning
//         }
//         updateSlidePosition();
//     }

//     function prevSlide() {
//         if (currentIndex > 0) {
//             currentIndex--;
//         } else {
//             currentIndex = totalSlides - slidesToShow; // Loop to the end
//         }
//         updateSlidePosition();
//     }

//     // Event listeners for navigation buttons
//     nextButton.addEventListener('click', nextSlide);
//     prevButton.addEventListener('click', prevSlide);

//     // Initialize slider position
//     updateSlidePosition();
// });


// document.addEventListener('DOMContentLoaded', () => {
//     const slidesContainer = document.querySelector('.slides2');
//     const slides4 = document.querySelectorAll('.slide3');
//     const prevButton = document.querySelector('.leftBtns i');
//     const nextButton = document.querySelector('.rightBtns i');

//     const slidesToShow = 4; // Number of slides to show at once
//     const totalSlides = slides4.length;
//     let currentIndex = 0;

//     function updateSlidePosition() {
//         const slideWidth = slides4[0].getBoundingClientRect().width;
//         const offset = (100 / slidesToShow) * currentIndex;
//         slidesContainer.style.transform = `translateX(-${offset}%)`;
//         prevButton.style.pointerEvents = currentIndex === 0 ? 'none' : 'auto';
//         nextButton.style.pointerEvents = currentIndex >= totalSlides - slidesToShow ? 'none' : 'auto';
//     }

//     function nextSlide() {
//         if (currentIndex < totalSlides - slidesToShow) {
//             currentIndex++;
//         } else {
//             currentIndex = 0; // Loop back to the beginning
//         }
//         updateSlidePosition();
//     }

//     function prevSlide() {
//         if (currentIndex > 0) {
//             currentIndex--;
//         } else {
//             currentIndex = totalSlides - slidesToShow; // Loop to the end
//         }
//         updateSlidePosition();
//     }

//     // Event listeners for navigation buttons
//     nextButton.addEventListener('click', nextSlide);
//     prevButton.addEventListener('click', prevSlide);

//     // Initialize slider position
//     updateSlidePosition();
// });

// document.addEventListener('DOMContentLoaded', () => {
//     const slidesContainer = document.querySelector('.slides3');
//     const slides7 = document.querySelectorAll('.slide4');
//     const prevButton = document.querySelector('.leftButns i');
//     const nextButton = document.querySelector('.rightButns i');

//     const slidesToShow = 4; // Number of slides to show at once
//     const totalSlides = slides7.length;
//     let currentIndex = 0;

//     function updateSlidePosition() {
//         const slideWidth = slides7[0].getBoundingClientRect().width;
//         const offset = (100 / slidesToShow) * currentIndex;
//         slidesContainer.style.transform = `translateX(-${offset}%)`;
//         prevButton.style.pointerEvents = currentIndex === 0 ? 'none' : 'auto';
//         nextButton.style.pointerEvents = currentIndex >= totalSlides - slidesToShow ? 'none' : 'auto';
//     }

//     function nextSlide() {
//         if (currentIndex < totalSlides - slidesToShow) {
//             currentIndex++;
//         } else {
//             currentIndex = 0; // Loop back to the beginning
//         }
//         updateSlidePosition();
//     }

//     function prevSlide() {
//         if (currentIndex > 0) {
//             currentIndex--;
//         } else {
//             currentIndex = totalSlides - slidesToShow; // Loop to the end
//         }
//         updateSlidePosition();
//     }

//     // Event listeners for navigation buttons
//     nextButton.addEventListener('click', nextSlide);
//     prevButton.addEventListener('click', prevSlide);

//     // Initialize slider position
//     updateSlidePosition();
// });


document.addEventListener('DOMContentLoaded', () => {
    function initializeSlider(slidesContainerSelector, slideSelector, prevButtonSelector, nextButtonSelector, slidesToShow) {
        const slidesContainer = document.querySelector(slidesContainerSelector);
        const slides = document.querySelectorAll(slideSelector);
        const prevButton = document.querySelector(prevButtonSelector);
        const nextButton = document.querySelector(nextButtonSelector);

        const totalSlides = slides.length;
        let currentIndex = 0;

        function updateSlidePosition() {
            const offset = (100 / slidesToShow) * currentIndex;
            slidesContainer.style.transform = `translateX(-${offset}%)`;
            prevButton.style.pointerEvents = currentIndex === 0 ? 'none' : 'auto';
            nextButton.style.pointerEvents = currentIndex >= totalSlides - slidesToShow ? 'none' : 'auto';
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
            event.preventDefault(); // Prevent the default scroll behavior
            if (event.deltaY > 0) {
                nextSlide(); // Scroll down moves to the right
            } else {
                prevSlide(); // Scroll up moves to the left
            }
        }

        // Mouse wheel event listener
        slidesContainer.addEventListener('wheel', handleMouseWheel);

        // Event listeners for navigation buttons
        nextButton.addEventListener('click', nextSlide);
        prevButton.addEventListener('click', prevSlide);

        // Initialize slider position
        updateSlidePosition();
    }

    // Initialize all sliders with different selectors
    initializeSlider('.slides', '.slide1', '.leftBt i', '.rightBt i', 4);
    initializeSlider('.slides1', '.slide2', '.leftBtn i', '.rightBtn i', 4);
    initializeSlider('.slides2', '.slide3', '.leftBtns i', '.rightBtns i', 4);
    initializeSlider('.slides3', '.slide4', '.leftButns i', '.rightButns i', 4);
});
