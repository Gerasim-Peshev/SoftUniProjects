import { del, get } from "../api/api.js";
import { html, nothing } from "../lib.js";

export async function detailsView(ctx) {

    //debugger
  const elem = await get("/data/pets/" + ctx.params.id);

  const detailsTemp = html`
    <section id="detailsPage">
      <div class="details">
        <div class="animalPic">
          <img src="${elem.image}" />
        </div>
        <div>
          <div class="animalInfo">
            <h1>Name: ${elem.name}</h1>
            <h3>Breed: ${elem.breed}</h3>
            <h4>Age: ${elem.age}</h4>
            <h4>Weight: ${elem.weight}</h4>
            <h4 class="donation">Donation: 0$</h4>
          </div>
          <!-- if there is no registered user, do not display div-->
          <div class="actionBtn">
            <!-- Only for registered user and creator of the pets-->
            ${ctx.user && ctx.user._id === elem._ownerId ? html`<a href="/edit/${elem._id}" class="edit">Edit</a>` : nothing}
            ${ctx.user && ctx.user._id === elem._ownerId ? html`<a @click="${onDelete}" href="javascript:void(0)" class="remove">Delete</a>` : nothing}
            <!--(Bonus Part) Only for no creator and user-->
            <a href="#" class="donate">Donate</a>
          </div>
        </div>
      </div>
    </section>
  `;

  async function onDelete(){
    
    const check = confirm('are you sure you want to delete this pet');

    if(check){
        del('/data/pets/' + ctx.params.id);
        ctx.page.redirect('/');
    }
  }

  ctx.render(detailsTemp);
}
