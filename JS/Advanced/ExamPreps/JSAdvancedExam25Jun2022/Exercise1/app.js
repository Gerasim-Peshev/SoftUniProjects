window.addEventListener("load", solve);

function solve() {
  document.getElementById('publish').addEventListener('click', createCar);

  let make = document.getElementById('make');
  let model = document.getElementById('model');
  let year = document.getElementById('year');
  let fuel = document.getElementById('fuel');
  let originalCost = document.getElementById('original-cost');
  let sellingPrice = document.getElementById('selling-price');

  let tableBody = document.getElementById('table-body');
  let soldCars = document.getElementById('cars-list');
  let iProfit = document.getElementById('profit');

  function createCar(e){
    e.preventDefault();

    if(!make.value || !model.value || !year.value || !fuel.value || !originalCost.value || !sellingPrice.value || originalCost.value > sellingPrice.value){
      return;
    } else {
      let trToAdd = document.createElement('tr');
      trToAdd.classList.add('row');

      let tdMake = document.createElement('td');
      tdMake.textContent = make.value;

      let tdModel = document.createElement('td');
      tdModel.textContent = model.value;

      let tdYear = document.createElement('td');
      tdYear.textContent = year.value;

      let tdFuel = document.createElement('td');
      tdFuel.textContent = fuel.value;

      let tdOriginalCost = document.createElement('td');
      tdOriginalCost.textContent = originalCost.value;

      let tdSellingPrice = document.createElement('td');
      tdSellingPrice.textContent = sellingPrice.value;

      let tdButts = document.createElement('td');

      let editButt = document.createElement('button');
      editButt.className = 'action-btn edit';
      editButt.textContent = 'Edit';
      editButt.addEventListener('click', editCar);

      let sellButt = document.createElement('button');
      sellButt.className = 'action-btn sell';
      sellButt.textContent = 'Sell';
      sellButt.addEventListener('click', sellCar);

      tdButts.appendChild(editButt);
      tdButts.appendChild(sellButt);

      trToAdd.appendChild(tdMake);
      trToAdd.appendChild(tdModel);
      trToAdd.appendChild(tdYear);
      trToAdd.appendChild(tdFuel);
      trToAdd.appendChild(tdOriginalCost);
      trToAdd.appendChild(tdSellingPrice);
      trToAdd.appendChild(tdButts);

      tableBody.appendChild(trToAdd);

      make.value = '';
      model.value = '';
      year.value = '';
      fuel.value = '';
      originalCost.value = '';
      sellingPrice.value = '';
    }

  }

  function editCar(e){
    e.preventDefault();

    let button = e.target;
    let parent = button.parentElement;
    let ultimateParent = parent.parentElement;

    make.value = ultimateParent.children[0].textContent;
    model.value = ultimateParent.children[1].textContent;
    year.value = ultimateParent.children[2].textContent;
    fuel.value = ultimateParent.children[3].textContent;
    originalCost.value = ultimateParent.children[4].textContent;
    sellingPrice.value = ultimateParent.children[5].textContent;
    
    ultimateParent.remove();
  }

  function sellCar(e){
    e.preventDefault();

    let button = e.target;
    let parent = button.parentElement;
    let ultimateParent = parent.parentElement;

    let liToAdd = document.createElement('li');
    liToAdd.className = 'each-list';

    let spanMakeModel = document.createElement('span');
    spanMakeModel.textContent = `${ultimateParent.children[0].textContent} ${ultimateParent.children[1].textContent}`;

    let spanYear = document.createElement('span');
    spanYear.textContent = `${ultimateParent.children[2].textContent}`;

    let spanProfitMade = document.createElement('span');
    spanProfitMade.textContent = `${Number(ultimateParent.children[5].textContent) - Number(ultimateParent.children[4].textContent)}`;

    liToAdd.appendChild(spanMakeModel);
    liToAdd.appendChild(spanYear);
    liToAdd.appendChild(spanProfitMade);

    soldCars.appendChild(liToAdd);

    ultimateParent.remove();

    iProfit.textContent = (Number(iProfit.textContent) + Number(spanProfitMade.textContent)).toFixed(2);
  }
}
