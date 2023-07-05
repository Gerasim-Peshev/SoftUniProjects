window.addEventListener('load', solve);

function solve() {
    document.getElementById('add').addEventListener('click', addFurniture);

    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let description = document.getElementById('description');
    let price = document.getElementById('price');

    let furnitureList = document.getElementById('furniture-list');
    let totalPrice = document.querySelectorAll('td[class="total-price"]')[0];

    function addFurniture(e){
        e.preventDefault();

        if(!model.value || !year.value || !description.value || !price.value){
            return;
        } else {
            let trInfo = document.createElement('tr');
            trInfo.className = 'info';

            let tdModel = document.createElement('td');
            tdModel.textContent = model.value;

            let tdPrice = document.createElement('td');
            tdPrice.textContent = Number(price.value).toFixed(2);

            let tdButts = document.createElement('td');

            let moreButt = document.createElement('button');
            moreButt.className = 'moreBtn';
            moreButt.textContent = 'More Info';
            moreButt.addEventListener('click', showHideInfo);

            let buyButt = document.createElement('button');
            buyButt.className = 'buyBtn';
            buyButt.textContent = 'Buy it';
            buyButt.addEventListener('click', buyFurniture);

            let trHidenInfo = document.createElement('tr');
            trHidenInfo.className = 'hide';
            trHidenInfo.style.display = 'none';

            let tdYear = document.createElement('td');
            tdYear.textContent = `Year: ${year.value}`;

            let tdDescription = document.createElement('td');
            tdDescription.setAttribute('colspan', '3');
            tdDescription.textContent = `Description: ${description.value}`;

            tdButts.appendChild(moreButt);
            tdButts.appendChild(buyButt);

            trInfo.appendChild(tdModel);
            trInfo.appendChild(tdPrice);
            trInfo.appendChild(tdButts);

            trHidenInfo.appendChild(tdYear);
            trHidenInfo.appendChild(tdDescription);

            furnitureList.appendChild(trInfo);
            furnitureList.appendChild(trHidenInfo);
        }
    }

    function showHideInfo(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;
        let endedParent = ultimateParent.parentElement;

        let index = 0;
        for(let elem of endedParent.children){
            if(elem === ultimateParent){
                break;
            }
            index++;
        }
        index += 1;

        if(button.textContent === 'More Info'){
            endedParent.children[index].style.display = 'contents';
            button.textContent = 'Less Info';
        } else if(button.textContent === 'Less Info'){
            endedParent.children[index].style.display = 'none';
            button.textContent = 'More Info';
        }
    }

    function buyFurniture(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;

        
        let endedParent = ultimateParent.parentElement;
        
        let index = 0;
        for(let elem of endedParent.children){
            if(elem === ultimateParent){
                break;
            }
            index++;
        }
        index += 1;
        
        totalPrice.textContent = (Number(totalPrice.textContent) + Number(ultimateParent.children[1].textContent)).toFixed(2);

        ultimateParent.remove();
        endedParent.children[index].remove();
    }
}
