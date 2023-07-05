import { post } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function createView(ctx) {
  const createTemp = html`
    <section id="create">
      <div class="form" @submit="${onCreate}">
        <h2>Add item</h2>
        <form class="create-form">
          <input type="text" name="brand" id="shoe-brand" placeholder="Brand" />
          <input type="text" name="model" id="shoe-model" placeholder="Model" />
          <input
            type="text"
            name="imageUrl"
            id="shoe-img"
            placeholder="Image url"
          />
          <input
            type="text"
            name="release"
            id="shoe-release"
            placeholder="Release date"
          />
          <input
            type="text"
            name="designer"
            id="shoe-designer"
            placeholder="Designer"
          />
          <input type="text" name="value" id="shoe-value" placeholder="Value" />

          <button type="submit">post</button>
        </form>
      </div>
    </section>
  `;

  async function onCreate(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.brand || !data.model || !data.imageUrl || !data.release || !data.designer || !data.value){
        return alert('all fields are required');
    }

    await post('/data/shoes', data);

    updateNav();
    ctx.page.redirect('/dashboard');
  }

  ctx.render(createTemp);
}
