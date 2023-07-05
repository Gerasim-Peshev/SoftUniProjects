import { html } from "../lib.js";
import { get, put } from "../api/api.js";
import { updateNav } from "../navigation.js";

export async function editView(ctx) {
  
    const elem = await get('/data/books/' + ctx.params.id);
  
  const editTemp = (elem) => html`
    <section id="edit-page" class="edit">
      <form id="edit-form" action="#" method="" @submit="${onEdit}">
        <fieldset>
          <legend>Edit my Book</legend>
          <p class="field">
            <label for="title">Title</label>
            <span class="input">
              <input
                type="text"
                name="title"
                id="title"
                value="${elem.title}"
              />
            </span>
          </p>
          <p class="field">
            <label for="description">Description</label>
            <span class="input">
              <textarea name="description" id="description">${elem.description}</textarea
              >
            </span>
          </p>
          <p class="field">
            <label for="image">Image</label>
            <span class="input">
              <input
                type="text"
                name="imageUrl"
                id="image"
                value="${elem.imageUrl}"
              />
            </span>
          </p>
          <p class="field">
            <label for="type">Type</label>
            <span class="input">
              <select id="type" name="type" value="${elem.type}">
                <option value="Fiction" selected>Fiction</option>
                <option value="Romance">Romance</option>
                <option value="Mistery">Mistery</option>
                <option value="Classic">Clasic</option>
                <option value="Other">Other</option>
              </select>
            </span>
          </p>
          <input class="button submit" type="submit" value="Save" />
        </fieldset>
      </form>
    </section>
  `;

  async function onEdit(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.title || !data.description || !data.imageUrl || !data.type){
        return alert('all fields are required');
    }

    const body = {
        title: data.title,
        description: data.description,
        imageUrl: data.imageUrl,
        type: data.type
    }

    await put('/data/books/' + elem._id, body);

    updateNav();
    ctx.page.redirect('/details/' + elem._id);
  }

  ctx.render(editTemp(elem));
}
