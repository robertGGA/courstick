const email = document.getElementById('email');
const password = document.getElementById('password');
const repPassword = document.getElementById('repeat_password');
const validRegexEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
const validRegexPassword = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
const errorEmail = document.getElementById('email-error');
const errorPassword = document.getElementById('pass-error')
const errorRepPassword = document.getElementById('reppassword-error')
let errorEmailFlag = false;
let errorPassFlag = false;
let errorRepeatFlag = false;


email.addEventListener('change', (e) => {
    if(e.target.value.match(validRegexEmail)) {
        errorEmailFlag = false;
        email.style.border = '1px solid rgba(0, 11, 38, 0.16)';
        errorEmail.style.display = 'none';
    } else {
        errorEmailFlag = true;
        email.style.border = '1px solid red';
        errorEmail.style.display = 'flex';
    }
})

password.addEventListener('change', (e) => {
    if(e.target.value.match(validRegexPassword)) {
        errorPassFlag = false;
        password.style.border = '1px solid rgba(0, 11, 38, 0.16)'
        errorPassword.style.display = 'none';
    } else {
        errorPassFlag = true;
        password.style.border = '1px solid red'
        errorPassword.style.display = 'flex';
    }

    if(e.target.value === repPassword.value) {
        repPassword.style.border = '1px solid rgba(0, 11, 38, 0.16)'
        errorRepPassword.style.display = 'none';
    }
})

console.log(password.value);

repPassword.addEventListener('change', (e) => {
    if(e.target.value !== password.value) {
        errorRepPassword.style.display = 'flex';
        repPassword.style.border = '1px solid red';
    } else {
        repPassword.style.border = '1px solid rgba(0, 11, 38, 0.16)'
        errorRepPassword.style.display = 'none';
    }
})