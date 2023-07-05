import {html, render} from './node_modules/lit-html/lit-html.js';
import {cats} from './catSeeder.js';

const catTemplate = (cat) => html`
<li>
                <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
                <div class="info">
                    <button class="showBtn" @click="${showHideInfo}">Show status code</button>
                    <div class="status" style="display: none" id=${cat.id}>
                        <h4>Status Code: ${cat.statusCode}</h4>
                        <p>${cat.statusMessage}</p>
                    </div>
                </div>
            </li>
`;

render(cats.map(catTemplate), document.getElementById('allCats'));

function showHideInfo(e){
    e.preventDefault();

    let butt = e.target;
    let parent = butt.parentElement;

    let divToFind = parent.querySelector('.status');

    if(divToFind.style.display == 'none'){
        divToFind.style.display = 'block';
        butt.textContent = 'Hide status code';
    } else {
        divToFind.style.display = 'none';
        butt.textContent = 'Show status code';
    }
}