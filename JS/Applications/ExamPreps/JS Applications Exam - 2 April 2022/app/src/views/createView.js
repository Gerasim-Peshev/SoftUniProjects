import { post } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function createView(ctx) {
  const createTemp = html`
    <section id="createPage">
      <form class="createForm" @submit="${onCreate}">
        <img src="./images/cat-create.jpg" />
        <div>
          <h2>Create PetPal</h2>
          <div class="name">
            <label for="name">Name:</label>
            <input name="name" id="name" type="text" placeholder="Max" />
          </div>
          <div class="breed">
            <label for="breed">Breed:</label>
            <input
              name="breed"
              id="breed"
              type="text"
              placeholder="Shiba Inu"
            />
          </div>
          <div class="Age">
            <label for="age">Age:</label>
            <input name="age" id="age" type="text" placeholder="2 years" />
          </div>
          <div class="weight">
            <label for="weight">Weight:</label>
            <input name="weight" id="weight" type="text" placeholder="5kg" />
          </div>
          <div class="image">
            <label for="image">Image:</label>
            <input
              name="image"
              id="image"
              type="text"
              placeholder="./image/dog.jpeg"
            />
          </div>
          <button class="btn" type="submit">Create Pet</button>
        </div>
      </form>
    </section>
  `;

  async function onCreate(e){
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

    await post('/data/pets', body);

    updateNav();
    ctx.page.redirect('/');
  }

  ctx.render(createTemp);
}
