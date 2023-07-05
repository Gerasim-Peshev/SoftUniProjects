import { post } from "../api/api.js";
import { html } from "../lib.js";

export function createView(ctx) {
  const createTemp = html`
    <section id="createPage">
      <form class="create-form" @submit="${onCreate}">
        <h1>Create Theater</h1>
        <div>
          <label for="title">Title:</label>
          <input
            id="title"
            name="title"
            type="text"
            placeholder="Theater name"
            value=""
          />
        </div>
        <div>
          <label for="date">Date:</label>
          <input
            id="date"
            name="date"
            type="text"
            placeholder="Month Day, Year"
          />
        </div>
        <div>
          <label for="author">Author:</label>
          <input id="author" name="author" type="text" placeholder="Author" />
        </div>
        <div>
          <label for="description">Description:</label>
          <textarea
            id="description"
            name="description"
            placeholder="Description"
          ></textarea>
        </div>
        <div>
          <label for="imageUrl">Image url:</label>
          <input
            id="imageUrl"
            name="imageUrl"
            type="text"
            placeholder="Image Url"
            value=""
          />
        </div>
        <button class="btn" type="submit">Submit</button>
      </form>
    </section>
  `;

  async function onCreate(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.title || !data.date || !data.author || !data.imageUrl || !data.description){
        return alert('all fields are required');
    }

    const {
        title,
        date,
        author,
        imageUrl,
        description
    } = data;      

    await post('/data/theaters', {title, date, author, imageUrl, description});

    ctx.page.redirect('/');
  }

  ctx.render(createTemp);
}
