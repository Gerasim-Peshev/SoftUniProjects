function generateReport() {
   
    let cells = Array.from(document.querySelectorAll('tbody tr'));
    let buttons = Array.from(document.querySelectorAll('input')); 

   let result = [];
   
    let checkedButtsIndexes = [];
    
    buttons.forEach((el, index) => {
        if(el.checked){
            checkedButtsIndexes.push(index);
        }
    });

    for(let row of cells){

        let innerObj = {};

        for(let index of checkedButtsIndexes){
            let propName = buttons[index].name;
            let propVal = row.children[index].textContent;

            innerObj[propName] = propVal;
        }

        result.push(innerObj);
    }

    let outputArea = document.getElementById('output');

    outputArea.value = JSON.stringify(result);
}