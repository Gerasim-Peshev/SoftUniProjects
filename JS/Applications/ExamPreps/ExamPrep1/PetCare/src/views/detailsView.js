import { html, nothing } from "../../node_modules/lit-html/lit-html.js";

export async function detailsView(ctx) {

  //debugger
  const id = ctx.params.id;
  const response = await fetch(`http://localhost:3030/data/pets/${id}`);

  const pet = await response.json();

  ctx.render(petDetailsTemplate(pet))
}

function petDetailsTemplate(pet) {
  return html`
    <section id="detailsPage">
      <div class="details">
        <div class="animalPic">
          <img src="${pet.image}" />
        </div>
        <div>
          <div class="animalInfo">
            <h1>Name: ${pet.name}</h1>
            <h3>Breed: ${pet.breed}</h3>
            <h4>Age: ${pet.age}</h4>
            <h4>Weight: ${pet.weight}</h4>
            <h4 class="donation">Donation: 0$</h4>
          </div>
          <!-- if there is no registered user, do not display div-->
          ${sessionStorage.getItem('userData') ? html`
            <div class="actionBtn">
            ${sesstionStorage.getItem('userData')._id === pet._ownerId ? html`
            <!-- Only for registered user and creator of the pets-->
            <a href="#" class="edit">Edit</a>
            <a href="#" class="remove">Delete</a>
            ` : html`
            <!--(Bonus Part) Only for no creator and user-->
            <a href="#" class="donate">Donate</a>
            `}  
          </div>` : nothing}
        </div>
      </div>
    </section>
  `;
}
