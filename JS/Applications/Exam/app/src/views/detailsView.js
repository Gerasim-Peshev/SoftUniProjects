import { html, nothing } from "../lib.js";
import { del, get } from "../api/api.js";
import { updateNav } from "../navigation.js";

export async function detailsView(ctx) {
  const elem = await get("/data/albums/" + ctx.params.id);

  const detailsTemp = html`
    <section id="details">
      <div id="details-wrapper">
        <p id="details-title">Album Details</p>
        <div id="img-wrapper">
          <img src="${elem.imageUrl}" alt="example1" />
        </div>
        <div id="info-wrapper">
          <p><strong>Band:</strong><span id="details-singer">${elem.singer}</span></p>
          <p>
            <strong>Album name:</strong
            ><span id="details-album">${elem.album}</span>
          </p>
          <p>
            <strong>Release date:</strong><span id="details-release">${elem.release}</span>
          </p>
          <p><strong>Label:</strong><span id="details-label">${elem.label}</span></p>
          <p>
            <strong>Sales:</strong
            ><span id="details-sales">${elem.sales}</span>
          </p>
        </div>
        <div id="likes">Likes: <span id="likes-count">0</span></div>

        <!--Edit and Delete are only for creator-->
        <div id="action-buttons">
          ${ctx.user && ctx.user._id != elem._ownerId ? html`<a href="" id="like-btn">Like</a>` : nothing}
          ${ctx.user && ctx.user._id == elem._ownerId ? html`<a href="/edit/${elem._id}" id="edit-btn">Edit</a>` : nothing}
          ${ctx.user && ctx.user._id == elem._ownerId ? html`<a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>` : nothing}
        </div>
      </div>
    </section>
  `;

  async function onDelete(e){
    e.preventDefault();

    const check = confirm('are you sure about that');
    if(check){
        await del('/data/albums/' + ctx.params.id);
        updateNav();
        ctx.page.redirect('/dashboard');
    }
  }

  ctx.render(detailsTemp);
}
