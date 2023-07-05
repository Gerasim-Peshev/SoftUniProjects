function sumTable() {
    let elements = document.querySelectorAll('td');

    //debugger;
    let sum = 0;
    for(let i = 0; i < elements.length - 1; i++){
        if(i % 2 !== 0){
            sum += Number(elements[i].textContent);
        }
    }

    let area = document.getElementById('sum');
    area.textContent = sum;
}