import { get, put } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function editView(ctx) {
  const elem = await get("/data/shoes/" + ctx.params.id);

  const editTemp = html`
    <section id="edit">
      <div class="form" @submit="${onEdit}">
        <h2>Edit item</h2>
        <form class="edit-form">
          <input type="text" name="brand" id="shoe-brand" placeholder="${elem.brand}" value="${elem.brand}" />
          <input type="text" name="model" id="shoe-model" placeholder="${elem.model}" value="${elem.model}" />
          <input
            type="text"
            name="imageUrl"
            id="shoe-img"
            placeholder="${elem.imageUrl}"
            value="${elem.imageUrl}"
          />
          <input
            type="text"
            name="release"
            id="shoe-release"
            placeholder="${elem.release}"
            value="${elem.release}"
          />
          <input
            type="text"
            name="designer"
            id="shoe-designer"
            placeholder="${elem.designer}"
            value="${elem.designer}"
          />
          <input type="text" name="value" id="shoe-value" placeholder="${elem.value}" value="${elem.value}" />

          <button type="submit">post</button>
        </form>
      </div>
    </section>
  `;

  async function onEdit(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.brand || !data.model || !data.imageUrl || !data.release || !data.designer || !data.value){
        return alert('all fields are required');
    }

    const body = {
        brand: data.brand,
        model: data.model,
        imageUrl: data.imageUrl,
        release: data.release,
        designer: data.designer,
        value: data.value
    }

    await put('/data/shoes/' + ctx.params.id, body);

    //updateNav();
    ctx.page.redirect('/details/' + ctx.params.id);
  }

  ctx.render(editTemp);
}
