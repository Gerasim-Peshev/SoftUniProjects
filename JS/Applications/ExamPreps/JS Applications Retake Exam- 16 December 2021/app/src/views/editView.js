import { get, put } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../nav.js";

export async function editView(ctx) {

    const elem = await get('/data/theaters/' + ctx.params.id);

  const editTemp = html`
    <section id="editPage">
      <form class="theater-form" @submit="${onEdit}">
        <h1>Edit Theater</h1>
        <div>
          <label for="title">Title:</label>
          <input
            id="title"
            name="title"
            type="text"
            placeholder="Theater name"
            value="${elem.title}"
          />
        </div>
        <div>
          <label for="date">Date:</label>
          <input
            id="date"
            name="date"
            type="text"
            placeholder="Month Day, Year"
            value="${elem.date}"
          />
        </div>
        <div>
          <label for="author">Author:</label>
          <input
            id="author"
            name="author"
            type="text"
            placeholder="Author"
            value="${elem.author}"
          />
        </div>
        <div>
          <label for="description">Theater Description:</label>
          <textarea
            id="description"
            name="description"
            placeholder="Description"
          >${elem.description}</textarea
          >
        </div>
        <div>
          <label for="imageUrl">Image url:</label>
          <input
            id="imageUrl"
            name="imageUrl"
            type="text"
            placeholder="Image Url"
            value="${elem.imageUrl}"
          />
        </div>
        <button class="btn" type="submit">Submit</button>
      </form>
    </section>
  `;

   async function onEdit(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.title || !data.imageUrl || !data.description || !data.date || !data.author){
        return alert('all fields are required');
    }

    const body = {
        title: data.title,
        imageUrl: data.imageUrl,
        description: data.description,
        date: data.date,
        author: data.author
    }

    //debugger
    await put('/data/theaters/' + ctx.params.id, body);

    updateNav();
    ctx.page.redirect('/details/' + ctx.params.id);
   }

   updateNav();
   ctx.render(editTemp);
}
