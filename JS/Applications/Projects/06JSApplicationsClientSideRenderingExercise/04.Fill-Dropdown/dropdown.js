import {html, render} from './node_modules/lit-html/lit-html.js';

(async function addItem() {

    //debugger;
    let menu = document.getElementById('menu');

    let data = await getData();
    const optionTemlpate = (data) => html`
    ${Object.entries(data).map(createOption)}
    `;

    const createOption = (optionData) => html`
    <option value=${optionData[1]._id}>${optionData[1].text}</option>
    `;

    render(optionTemlpate(data), menu);

    //debugger;
    let butt = document.querySelectorAll('form input')[1];
    butt.addEventListener('click', addToMenu);

    async function addToMenu(e){
        //debugger;
        e.preventDefault();
        
        let text = document.querySelectorAll('form input')[0];

        if(text.value === ''){
            return;
        }

        postData(text.value);
        data = await getData();
        render(optionTemlpate(data),menu);
        text.value = '';
    }
})()

async function getData(){
    let response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    let data = await response.json();

    return data;
}

async function postData(text){
    let response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'POST',
        headers: {'Content-type': 'applications/json'},
        body: JSON.stringify({text: text})
    })


}

