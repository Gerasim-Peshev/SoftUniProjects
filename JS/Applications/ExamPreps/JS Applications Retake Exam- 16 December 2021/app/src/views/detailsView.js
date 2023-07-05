import { del, get } from "../api/api.js";
import { html, nothing } from "../lib.js";
import { updateNav } from "../nav.js";

export async function detailsView(ctx) {

    //debugger
    const elem = await get('/data/theaters/' + ctx.params.id);

  const detailsTemp = html`
    <section id="detailsPage">
      <div id="detailsBox">
        <div class="detailsInfo">
          <h1>Title: ${elem.title}</h1>
          <div>
            <img src="${elem.imageUrl}" />
          </div>
        </div>

        <div class="details">
          <h3>Theater Description</h3>
          <p>
            ${elem.description}
          </p>
          <h4>Date: ${elem.date}</h4>
          <h4>Author: ${elem.author}</h4>
          <div class="buttons">
            ${ctx.user._id === elem._ownerId ? html`<a @click="${onDelete}" class="btn-delete" href="javascript:void(0)">Delete</a>` : nothing}
            ${ctx.user._id === elem._ownerId ? html`<a class="btn-edit" href="/edit/${elem._id}">Edit</a>` : nothing}
            ${ctx.user._id !== elem._ownerId ? html`<a class="btn-like" href="#">Like</a>` : nothing}
          </div>
          <p class="likes">Likes: 0</p>
        </div>
      </div>
    </section>
  `;

  async function onDelete(e){

    const check = confirm('Are you sure you want to delete this?');
    if(check){
        del('/data/theaters/' + elem._id);
        ctx.page.redirect('/profile');
    }
  }

  updateNav();
  ctx.render(detailsTemp);
}
