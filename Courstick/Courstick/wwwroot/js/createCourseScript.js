const createButton = document.getElementById('add-lesson-button');
const modal = document.getElementById('modal');
const createModal = document.getElementById('createLessonModal');
const testCreateButton = document.getElementById('test_button');
const createInfoButton = document.getElementById('info_button');
const lessonsListHtml = document.querySelector('.lessons');
const lessonInput = document.getElementById('lesson-text-input');
const lessonSubmit = document.getElementById('lessonSubmit');
let nodes = Array.prototype.slice.call(lessonsListHtml.children);

const lessonsList = [];

let removeButtons;


function closeModal() {
    modal.style.display = "none";
    createModal.style.display = 'none';
}

function openModal(modalType) {
    if (modalType == 'create') {
        createModal.style.display = 'block';
    } else {
        modal.style.display = 'block';
    }
}


createInfoButton.addEventListener('click', () => {
    if (lessonsList.length >= 10) {
        alert('Максимальное количество уроков - 10')
    } else {
        lessonsList.push({
            type: 'info',
            content: lessonsList.length
        })
        lessonsListHtml.insertAdjacentHTML('beforeend', `<div id=${lessonsList.length - 1} class="lesson-container">\n` +
            '                        <div class="lesson_info_container">\n' +
            `                           <p id="lesson-info-${lessonsList.length - 1}">${lessonsList[lessonsList.length - 1].content}</p>\n` +
            '                        </div>\n' +
            '\n' +
            '                        <div>\n' +
            `                            <button id="change-button-${lessonsList.length - 1}" class="medium-button orange-button change-button">\n` +
            '                                Изменить курс\n' +
            '                            </button>\n' +
            '\n' +
            `                            <button id="remove-button-${lessonsList.length - 1}" class="medium-button border-button remove-button">\n` +
            '                                Удалить курс\n' +
            '                            </button>\n' +
            '                        </div>\n' +
            '                    </div>')
    }
    removeButtons = document.querySelectorAll('.remove-button');
    closeModal();
})

function removeItem(item) {
    item.remove();
}

document.addEventListener('click', (item) => {
    let number = item.path[0].id.slice(-1);
    if (item.path[0].id.includes('remove-button')) {
        item.path[0].removeEventListener('click', removeItem(item.path[2]));
        lessonsList.splice(number, 1);
    }

    if (item.path[0].id.includes('change-button')) {
        item.path[0].removeEventListener('click', openChangeModal(number));
    }
})

function openChangeModal(number) {
    openModal('create');
    lessonSubmit.addEventListener('click', changeLesson(number), true);
}

function changeLesson(number) {
    const value = lessonInput.value;
    const id = `lesson-info-${number}`;
    const info = document.getElementById(id);
    lessonsList[number].content = value.toString();
    info.innerText = lessonsList[number].content;
    closeModal();
    lessonInput.value = '';
}

createButton.addEventListener('click', () => {
    openModal();
});

window.onclick = function (event) {
    if (event.target == modal) {
        closeModal();
    }
}
