function toggle() {
    let text = document.getElementById('extra');
    let butt = document.getElementsByClassName('button')[0];

    if(butt.textContent === 'More'){
        text.style.display = 'block';
        butt.textContent = 'Less';
    } else{
        text.style.display = 'none';
        butt.textContent = 'More';
    }
}