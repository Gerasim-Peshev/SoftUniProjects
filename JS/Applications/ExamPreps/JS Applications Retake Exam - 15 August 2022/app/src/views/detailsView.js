import { del, get } from "../api/api.js";
import { html, nothing } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function detailsView(ctx) {
  const elem = await get("/data/shoes/" + ctx.params.id);

  const detailsTemp = html`
    <section id="details">
      <div id="details-wrapper">
        <p id="details-title">${elem.title}</p>
        <div id="img-wrapper">
          <img src="${elem.imageUrl}" alt="example1" />
        </div>
        <div id="info-wrapper">
          <p>Brand: <span id="details-brand">${elem.brand}</span></p>
          <p>
            Model: <span id="details-model">${elem.model}</span>
          </p>
          <p>Release date: <span id="details-release">${elem.release}</span></p>
          <p>Designer: <span id="details-designer">${elem.designer}</span></p>
          <p>Value: <span id="details-value">${elem.value}</span></p>
        </div>

        <!--Edit and Delete are only for creator-->
        <div id="action-buttons">
          ${ctx.user && ctx.user._id == elem._ownerId ? html`<a href="/edit/${elem._id}" id="edit-btn">Edit</a>` : nothing}
          ${ctx.user && ctx.user._id == elem._ownerId ? html`<a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>` : nothing}
        </div>
      </div>
    </section>
  `;

  async function onDelete(e){
    e.preventDefault();

    const check = confirm('are you sure you want to delete this element');

    if(check){
        await del('/data/shoes/' + ctx.params.id);
        updateNav();
        ctx.page.redirect('/dashboard');
    }
  }

  ctx.render(detailsTemp);
}
