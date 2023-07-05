import { post } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function createView(ctx) {
  const createTemp = html`
    <section id="create">
      <div class="form" @submit="${onCreate}">
        <h2>Add Album</h2>
        <form class="create-form">
          <input
            type="text"
            name="singer"
            id="album-singer"
            placeholder="Singer/Band"
          />
          <input
            type="text"
            name="album"
            id="album-album"
            placeholder="Album"
          />
          <input
            type="text"
            name="imageUrl"
            id="album-img"
            placeholder="Image url"
          />
          <input
            type="text"
            name="release"
            id="album-release"
            placeholder="Release date"
          />
          <input
            type="text"
            name="label"
            id="album-label"
            placeholder="Label"
          />
          <input
            type="text"
            name="sales"
            id="album-sales"
            placeholder="Sales"
          />

          <button type="submit">post</button>
        </form>
      </div>
    </section>
  `;

  async function onCreate(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.singer || !data.album || !data.imageUrl || !data.release || !data.label || !data.sales){
        return alert('all fields are required');
    }

    await post('/data/albums', data);

    updateNav();
    ctx.page.redirect('/dashboard');
  }

  ctx.render(createTemp);
}
