const createButton = document.getElementById('add-lesson-button');
const modal = document.getElementById('modal');
const createModal = document.getElementById('createLessonModal');
const testCreateButton = document.getElementById('test_button');
const createInfoButton = document.getElementById('info_button');
const lessonsListHtml = document.querySelector('.lessons');
const lessonInput = document.getElementById('lesson-text-input');
const lessonSubmit = document.getElementById('lessonSubmit');
let nodes = Array.prototype.slice.call(lessonsListHtml.children);
const courseName = document.getElementById('courseName');
const smallDesc = document.getElementById('smallDesc');
const bigDesc = document.getElementById('bigDesc');
const image = document.getElementById('img');
const price = document.getElementById('price');

const addCourseButton = document.getElementById('add_course');

const lessonsList = [];

let removeButtons;


function closeModal() {
    modal.style.display = "none";
    createModal.style.display = "none";
}


function openModal(modalType) {
    if (modalType === 'create') {
        console.log('modal opened');
        createModal.style.display = 'block';
        console.log(createModal);
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
            text: lessonsList.length
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
    console.log(item);
    item.remove();
}
let mainNumber;

document.addEventListener('click', (item) => {
    let number = item.path[0].id.slice(-1);
    if (item.path[0].id.includes('remove-button')) {
        item.path[0].removeEventListener('click', removeItem(item.path[2]));
        lessonsList.splice(number, 1);
    }
    if (item.path[0].id.includes('change-button')) {
        openModal('create');
        mainNumber = number;
        lessonSubmit.addEventListener('click', changeLesson);
    }
})

function changeLesson() {
    console.log('click');
    const value = lessonInput.value;
    const id = `lesson-info-${mainNumber}`;
    const info = document.getElementById(id);
    lessonsList[mainNumber].content = value.toString();
    info.innerText = lessonsList[mainNumber].content;
    console.log(lessonsList);
    lessonInput.value = '';
    createModal.style.display = "none";
    
}

createButton.addEventListener('click', () => {
    openModal();
});

window.onclick = function (event) {
    if (event.target == modal) {
        closeModal();
    }
}

function createCourse(item) {
    item.preventDefault();
    
    const data = {
        Name: courseName.value,
        Description: bigDesc.value,
        SmallDescription: smallDesc.value,
        Price: price.value,
        Type: 1
    };
    console.log(data);
    $.ajax({
        url: '/CourseSettings/CreateCourse',
        type: 'POST',
        data: JSON.stringify(data),
        contentType: 'application/json',
        datatype: "json",
        success: (e) => {
            const lessons = {
                CourseId: e.data,
                Lessons: lessonsList
            };
            $.ajax({
                url: '/CourseSettings/CreateLessons',
                contentType: 'application/json',
                datatype: "json",
                type: 'POST',
                data: JSON.stringify(lessons),
                success: (r) => {
                    alert(r.data)
                }
            })
        },
        error: (e) => {
            console.log(e);
        }
    });
}

addCourseButton.addEventListener('click', (item) => createCourse(item));


