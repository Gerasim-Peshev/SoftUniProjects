function solve() {

  const textAreas = Array.from(document.querySelectorAll('textarea'));
  const areaToGenerate = document.querySelector('tbody');
  const buttons = Array.from(document.querySelectorAll('button'));
  
  const generateButton = buttons[0];
  const buyButton = buttons[1];

  generateButton.addEventListener('click', generate);
  buyButton.addEventListener('click', exportFurs);

  const inputTextArea = textAreas[0];
  const outputTextArea = textAreas[1];

  function generate(e){

    let butt = e.target;

    let text = JSON.parse(inputTextArea.value);

    for(let elem of text){
      let newFurnitureElem = document.createElement("tr");

      newFurnitureElem.innerHTML += `<td><img src="${elem.img}"></td>` + `<td><p>${elem.name}</p></td>` + `<td><p>${elem.price}</p></td>` + `<td><p>${elem.decFactor}</p></td>` + `<td><input type="checkbox"></td>`;

      areaToGenerate.appendChild(newFurnitureElem);
    }
  }

  function exportFurs(e){

    //debugger;
    let butt = e.target;

    outputTextArea.textContent = '';

    let elementsNames = [];
    let totalSum = 0;
    let avgDec = 0;

    let elements = Array.from(document.querySelectorAll('tr'));

    for(let i = 2; i < elements.length; i++){
      if(elements[i].querySelector('input[type=checkbox]').checked){
        let element = Array.from(elements[i].children);
        elementsNames.push(element[1].textContent);
        totalSum += Number(element[2].textContent);
        avgDec += Number(element[3].textContent);
      }
    }

    avgDec /= elementsNames.length;

    outputTextArea.textContent += `Bought furniture: ${elementsNames.join(', ')}\nTotal price: ${totalSum.toFixed(2)}\nAverage decoration factor: ${avgDec}`;
  }
}