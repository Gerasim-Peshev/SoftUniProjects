import { put } from "../api/api.js";
import { getCatalogElementDetails } from "../api/data.js";
import { html } from "../lib.js";

export async function editView(ctx) {
  
    //debugger
    const elem = await getCatalogElementDetails(ctx.params.id);

  const editTemp = (elem) => html`
    <section class="editPage">
      <form @submit="${onEdit}">
        <fieldset>
          <legend>Edit Album</legend>

          <div class="container">
            <label for="name" class="vhide">Album name</label>
            <input
              id="name"
              name="name"
              class="name"
              type="text"
              value="${elem.name}"
            />

            <label for="imgUrl" class="vhide">Image Url</label>
            <input
              id="imgUrl"
              name="imgUrl"
              class="imgUrl"
              type="text"
              value="${elem.imgUrl}"
            />

            <label for="price" class="vhide">Price</label>
            <input
              id="price"
              name="price"
              class="price"
              type="text"
              value="${elem.price}"
            />

            <label for="releaseDate" class="vhide">Release date</label>
            <input
              id="releaseDate"
              name="releaseDate"
              class="releaseDate"
              type="text"
              value="${elem.releaseDate}"
            />

            <label for="artist" class="vhide">Artist</label>
            <input
              id="artist"
              name="artist"
              class="artist"
              type="text"
              value="${elem.artist}"
            />

            <label for="genre" class="vhide">Genre</label>
            <input
              id="genre"
              name="genre"
              class="genre"
              type="text"
              value="${elem.genre}"
            />

            <label for="description" class="vhide">Description</label>
            <textarea
              name="description"
              class="description"
              rows="10"
              cols="10"
            >${elem.description}</textarea
            >

            <button class="edit-album" type="submit">Edit Album</button>
          </div>
        </fieldset>
      </form>
    </section>
  `;

  ctx.render(editTemp(elem));

  async function onEdit(e){
    
    //debugger
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.artist || !data.description || !data.genre || !data.imgUrl || !data.name || !data.price || !data.releaseDate){
        return alert('all fields is required')
    }
    await put('/data/albums/' + ctx.params.id, data);
    ctx.page.redirect('/details/' + ctx.params.id);
  }
}
