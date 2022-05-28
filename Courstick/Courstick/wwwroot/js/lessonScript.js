const lesson_buttons = document.querySelectorAll('.lesson-list-item');
const content_container = document.getElementById('content');
const lesson_title = document.getElementById('lesson-title')
const returnButton = document.getElementById('return-button');
const commentButton = document.getElementById('addComment');
const textInput = document.getElementById('text');


const query = getUrlId(document.location.pathname);

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

window.addEventListener('load', () => getComments());

const getComments = () => {
    $.ajax({
        url: '/Lessons/GetComments?id=' + query,
        type: 'GET',
        contentType: 'application/json',
        success: (res) => {
            $('.comments-container').empty();
            res.forEach(item => {
                setComment(item);
            })
        },
        error: () => {
            console.log('error');
        }
    });
}

commentButton.addEventListener('click', (e) => {
    e.preventDefault();
    
    const data = {
        Text: textInput.value.trim(),
        CourseId: query
    }
    
    createComment(data)
    
})

const createComment = (data) => {
    $.ajax({
        url: '/Lessons/SetComment',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: (res) => {
            getComments();
        },
        error: (err) => {
            console.log(err);
        }
    })
}

function getUrlId(qs) {
    qs = qs.split('/');
    return qs[qs.length - 1];
}

function setComment(item) {
    const img = `data:image/png;base64,${item.user.avatar}`
    $('.comments-container').append('<div class="comment">\n' +
        `                                <img src="${img}"class="comment_avatar">\n` +
        '                                <div class="comment-content">\n' +
        '                                    <p class="name">\n' +
        `                                        ${item.user.normalizedUserName}\n` +
        '                                    </p>\n' +
        '        \n' +
        `                                    <p class="comment-text"> ${item.text}` +
        '                                    </p>\n' +
        '                                </div>\n' +
        '                            </div>')
}
