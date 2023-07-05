import { html } from "../lib.js";
import { get, put } from "../api/api.js";
import { updateNav } from "../navigation.js";

export async function editView(ctx) {
  const elem = await get("/data/albums/" + ctx.params.id);

  const editTemp = html`
    <section id="edit">
      <div class="form" @submit="${onEdit}">
        <h2>Edit Album</h2>
        <form class="edit-form">
          <input
            type="text"
            name="singer"
            id="album-singer"
            placeholder="${elem.singer}"
            value="${elem.singer}"
          />
          <input
            type="text"
            name="album"
            id="album-album"
            placeholder="${elem.album}"
            value="${elem.album}"
          />
          <input
            type="text"
            name="imageUrl"
            id="album-img"
            placeholder="${elem.imageUrl}"
            value="${elem.imageUrl}"
          />
          <input
            type="text"
            name="release"
            id="album-release"
            placeholder="${elem.release}"
            value="${elem.release}"
          />
          <input
            type="text"
            name="label"
            id="album-label"
            placeholder="${elem.label}"
            value="${elem.label}"
          />
          <input
            type="text"
            name="sales"
            id="album-sales"
            placeholder="${elem.sales}"
            value="${elem.sales}"
          />

          <button type="submit">post</button>
        </form>
      </div>
    </section>
  `;

  async function onEdit(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.singer || !data.album || !data.imageUrl || !data.release || !data.label || !data.sales){
        return alert('all fields are required');
    }

    await put('/data/albums/' + ctx.params.id, data);

    updateNav();
    ctx.page.redirect('/details/' + ctx.params.id);
  }

  ctx.render(editTemp);
}
