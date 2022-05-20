const lesson_buttons = document.querySelectorAll('.lesson-list-item');
const content_container = document.getElementById('content');
const lesson_title = document.getElementById('lesson-title')
const return_button = document.getElementById('return-button');

lesson_buttons.forEach((item, index) => {
    item.addEventListener('click', item => {
        console.log(item.target.id);
        getLesson(item.target.id, index + 1);
    })
})

function getLesson(id, index) {
    $.ajax({
        url: '/Lessons/GetLesson?id=' + id,
        type: 'GET',
        contentType: 'application/json',
        success: (res) => {
            content_container.innerText = res.text;
            lesson_title.innerText = `Урок #${index}`
        },
        error: () => {
            console.log('error');
        }
    });
}