import { get } from "../api/api.js";
import { html } from "../lib.js";

export async function dashboardView(ctx) {

    //debugger
  const pets = await get("/data/pets?sortBy=_createdOn%20desc&distinct=name");

  const animal = (anim) => html`
    <div class="animals-board">
      <article class="service-img">
        <img class="animal-image-cover" src="${anim.image}" />
      </article>
      <h2 class="name">${anim.name}</h2>
      <h3 class="breed">${anim.breed}</h3>
      <div class="action">
        <a class="btn" href="/details/${anim._id}">Details</a>
      </div>
    </div>
  `;

  const animalListTemp = html`
    <section id="dashboard">
      <h2 class="dashboard-title">Services for every animal</h2>
      <div class="animals-dashboard">
        ${pets.length > 0 ? html`${pets.map(animal)}` : html`<div><p class="no-pets">No pets in dashboard</p></div>`}
        <!--If there is no pets in dashboard--> 
      </div>
    </section>
  `;

  ctx.render(animalListTemp);
}
