import { html } from "../../node_modules/lit-html/lit-html.js";

const context = null;

export async function catalogView(ctx) {

    let data = await getPets();
    ctx.render(data.map(patTemplate));
}

async function getPets(){
    const response = await fetch('http://localhost:3030/data/pets?sortBy=_createdOn%20desc&distinct=name')
    const data = await response.json();

    return data;
}

const patTemplate = (content) =>  html`
    <div class="animals-board">
      <article class="service-img">
        <img class="animal-image-cover" src="${content.image}" />
      </article>
      <h2 class="name">${content.name}</h2>
      <h3 class="breed">${content.breed}</h3>
      <div class="action">
        <a class="btn" href="/details/${content._id}">Details</a>
      </div>
    </div>
  `;