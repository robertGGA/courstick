const createButton = document.getElementById('add-lesson-button');
const modal = document.getElementById('modal');
const nextButton = document.getElementById('next');
const prevButton = document.getElementById('prev');
const modalContent = document.getElementById('modal-content');

const swiper = new Swiper('.swiper', {
    spaceBetween: 300,

    // Navigation arrows
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },

});

createButton.addEventListener('click', () => {
    modal.style.display = 'block';
});

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

nextButton.addEventListener('click', () => {
    console.log('next')
});

prevButton.addEventListener('click', () => {
    console.log('prev');
})

console.log(modalContent.children);