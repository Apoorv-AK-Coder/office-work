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

//         prevButton.style.display = currentIndex === 0 ? 'none' : 'block';
//             nextButton.style.display = currentIndex >= totalSlides - slidesToShow ? 'none' : 'block';
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
    
    const slidesContainer = document.querySelector(".slides");
    const slides = document.querySelectorAll(".slide1");
    const prevButton = document.querySelector(".leftBt i");
    const nextButton = document.querySelector(".rightBt i");

    const slidesToShow = 4;
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
});