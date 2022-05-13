const search = document.getElementById('course-searcher');
const filters = document.getElementsByClassName('tab');

let active;
const divyArray = Array.from(filters);

window.addEventListener('load', () => {
    getCourses().then((r) => {
       console.log(r);
    }).catch((e) => {
        console.log(e);
    })
})

async function getCourses() {
    return $.ajax({
        url: '/Search/GetCourses',
        type: 'GET',
        success: (r) => {
            console.log('works');
            return r;
        }
    })
}

divyArray.forEach((item) => {
    item.addEventListener('click', () => {
        console.log(active != null);
        if (active) {
            //active.classList.remove('active_tab');
            active.style.border = 'none';
            active = item;
            item.style.border = '1px solid #F75E05'
            //item.classList.add('active_tab');
            
            getCourses(item.innerHTML.trim());

        } else {
            active = item;
            //item.classList.add('active_tab');
            item.style.border = '1px solid #F75E05'
            getCourses(item.innerHTML.trim());
        }

    })
});

search.addEventListener('change', async (e) => {
    setTimeout(await getCourses(e.target.value), 2000);
});
