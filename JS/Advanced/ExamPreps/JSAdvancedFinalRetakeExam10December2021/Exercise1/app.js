window.addEventListener('load', solve);

function solve() {
    document.querySelectorAll('button')[0].addEventListener('click', sendForm);
    document.getElementById('completed-orders').children[2].addEventListener('click', clearOrders);

    let productType = document.getElementById('type-product');
    let description = document.getElementById('description');
    let name = document.getElementById('client-name');
    let phone = document.getElementById('client-phone');

    let recevedOrders = document.getElementById('received-orders');
    let completedOrders = document.getElementById('completed-orders');

    function sendForm(e){
        e.preventDefault();
        if(!productType.value || !description.value || !name.value || !phone.value){
            return
        } else {
            createForm();
        }
    }

    function createForm(e){

        let divToAdd = document.createElement('div');
        divToAdd.classList.add('container');

        let h2ProdType = document.createElement('h2');
        h2ProdType.textContent = `Product type for repair: ${productType.value}`;

        let h3ClientInfo = document.createElement('h3');
        h3ClientInfo.textContent = `Client information: ${name.value}, ${phone.value}`;

        let h4Description = document.createElement('h4');
        h4Description.textContent = `Description of the problem: ${description.value}`;

        let startButt = document.createElement('button');
        startButt.classList.add('start-btn');
        startButt.addEventListener('click', startTask);
        startButt.textContent = 'Start repair';

        let finishButt = document.createElement('button');
        finishButt.classList.add('finish-btn');
        finishButt.addEventListener('click', finishTask);
        finishButt.disabled = true;
        finishButt.textContent = 'Finish repair';

        divToAdd.appendChild(h2ProdType);
        divToAdd.appendChild(h3ClientInfo);
        divToAdd.appendChild(h4Description);
        divToAdd.appendChild(startButt);
        divToAdd.appendChild(finishButt);

        productType.value = '';
        description.value = '';
        name.value = '';
        phone.value = '';

        recevedOrders.appendChild(divToAdd);
    }

    function startTask(e){
        e.preventDefault();

        let buttStart = e.target;
        let parent = buttStart.parentElement;

        let buttFinish = parent.querySelectorAll('button')[1];

        buttStart.disabled = true;
        buttFinish.disabled = false;
    }

    function finishTask(e){
        e.preventDefault();

        let finishButt = e.target;
        let parent = finishButt.parentElement;

        let divToAdd = document.createElement('div');
        divToAdd.classList.add('container');

        let h2ProdType = parent.children[0];
        let h3ClientInfo = parent.children[1];
        let h4Description = parent.children[2];
        divToAdd.appendChild(h2ProdType);
        divToAdd.appendChild(h3ClientInfo);
        divToAdd.appendChild(h4Description);

        completedOrders.appendChild(divToAdd);

        parent.remove();
    }

    function clearOrders(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;

        let count = 0;
        for(let elem of parent.children){
            if(elem.className === 'container'){
                count++;
            }
        }
        
        while(count !== 0){
            for(let elem of parent.children){
                if(elem.className === 'container'){
                    elem.remove();
                }
            }
            count--;
        }
    }
}