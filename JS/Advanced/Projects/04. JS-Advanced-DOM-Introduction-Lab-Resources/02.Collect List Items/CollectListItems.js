function extractText() {
    let elements = document.querySelectorAll('li');
    let area = document.getElementById('result');

    let res = '';
    for(let element of elements){
        res+=`${element.textContent}` + '\n';
    }

    area.textContent = res;
}