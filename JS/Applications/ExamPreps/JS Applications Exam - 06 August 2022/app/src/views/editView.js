import { html } from "../lib.js";
import { get } from "../api/api.js";

export async function editView(ctx) {
  const elem = await get("/data/offers/" + ctx.params.id);

  const editTemp = html`
    <section id="edit">
      <div class="form" @submit="${onEdit}">
        <h2>Edit Offer</h2>
        <form class="edit-form">
          <input type="text" name="title" id="job-title" placeholder="Title" />
          <input
            type="text"
            name="imageUrl"
            id="job-logo"
            placeholder="${elem.imageUrl}"
          />
          <input
            type="text"
            name="category"
            id="job-category"
            placeholder="${elem.category}"
          />
          <textarea
            id="job-description"
            name="description"
            placeholder="${elem.description}"
            rows="4"
            cols="50"
          ></textarea>
          <textarea
            id="job-requirements"
            name="requirements"
            placeholder="${elem.requirements}"
            rows="4"
            cols="50"
          ></textarea>
          <input
            type="text"
            name="salary"
            id="job-salary"
            placeholder="${elem.salary}"
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

    if(!data.title || !data.imageUrl || !data.category || !data.description || !data.requirements || !data.salary){
        return alert('all fields are required');
    }

    const body = {
        title: data.title,
        imageUrl: data.imageUrl,
        category: data.category,
        description: data.description,
        requirements: data.requirements,
        salary: data.salary
    }

    await put('/data/offers/' + ctx.params.id, body);

    updateNav();
    ctx.page.redirect('/data/offers/' + ctx.params.id);
  }

  ctx.render(editTemp);
}
