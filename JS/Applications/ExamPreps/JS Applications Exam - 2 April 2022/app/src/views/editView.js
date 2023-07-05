import { get, put } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function editView(ctx) {

    //debugger
  const elem = await get("/data/pets/" + ctx.params.id);

  const editTemp = html`
    <section id="editPage">
      <form class="editForm" @submit="${onEdit}">
        <img src="./images/editpage-dog.jpg" />
        <div>
          <h2>Edit PetPal</h2>
          <div class="name">
            <label for="name">Name:</label>
            <input name="name" id="name" type="text" value="${elem.name}" />
          </div>
          <div class="breed">
            <label for="breed">Breed:</label>
            <input name="breed" id="breed" type="text" value="${elem.breed}" />
          </div>
          <div class="Age">
            <label for="age">Age:</label>
            <input name="age" id="age" type="text" value="${elem.age}" />
          </div>
          <div class="weight">
            <label for="weight">Weight:</label>
            <input name="weight" id="weight" type="text" value="${elem.weight}" />
          </div>
          <div class="image">
            <label for="image">Image:</label>
            <input
              name="image"
              id="image"
              type="text"
              value="${elem.image}"
            />
          </div>
          <button class="btn" type="submit">Edit Pet</button>
        </div>
      </form>
    </section>
  `;

  async function onEdit(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.name || !data.breed || !data.age || !data.weight || !data.image){
        return alert('all fields are required');
    }

    const body = {
        name: data.name,
        breed: data.breed,
        age: data.age,
        weight: data.weight,
        image: data.image
    }

    await put('/data/pets/' + ctx.params.id, body);

    updateNav();
    ctx.page.redirect('/details/' + ctx.params.id);
  }

  ctx.render(editTemp);
}
