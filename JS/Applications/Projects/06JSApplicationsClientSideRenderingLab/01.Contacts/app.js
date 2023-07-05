import {html, render} from './node_modules/lit-html/lit-html.js'
import {contacts} from './contacts.js';


const root = document.getElementById('contacts');

const hello = () => html`<p>Hello</p>`;

const showContact = ({id, name, phoneNumber, email}) => html`
    <div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${name}</h2>
        <button class="detailsBtn" @click=${showHiddenInfo}>Details</button>
        <div class="details" id="${id}" style="display: none">
            <p>Phone number: ${phoneNumber}</p>
            <p>Email: ${email}</p>
        </div>
    </div>
    </div>
    `;
update();

function update(){
    render(contacts.map(i => showContact(i)), root);
}

function showHiddenInfo(e){
    e.preventDefault();

    let butt = e.target;
    let parent = butt.parentElement;

    let detail = parent.querySelector('.details');
    if(detail.style.display === 'none'){
        detail.style.display = 'block';
    } else {
        detail.style.display = 'none';
    }
}