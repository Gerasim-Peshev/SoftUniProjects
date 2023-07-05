import { post } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function addView(ctx) {
  const addTemp = html`
    <section id="create">
      <div class="form" @submit="${onAdd}">
        <h2>Create Offer</h2>
        <form class="create-form">
          <input type="text" name="title" id="job-title" placeholder="Title" />
          <input
            type="text"
            name="imageUrl"
            id="job-logo"
            placeholder="Company logo url"
          />
          <input
            type="text"
            name="category"
            id="job-category"
            placeholder="Category"
          />
          <textarea
            id="job-description"
            name="description"
            placeholder="Description"
            rows="4"
            cols="50"
          ></textarea>
          <textarea
            id="job-requirements"
            name="requirements"
            placeholder="Requirements"
            rows="4"
            cols="50"
          ></textarea>
          <input
            type="text"
            name="salary"
            id="job-salary"
            placeholder="Salary"
          />

          <button type="submit">post</button>
        </form>
      </div>
    </section>
  `;

  async function onAdd(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if (
      !data.title ||
      !data.imageUrl ||
      !data.category ||
      !data.description ||
      !data.requirements ||
      !data.salary
    ) {
      return alert("all fields are required");
    }

    await post("/data/offers", data);

    updateNav();
    ctx.page.redirect("/dashboard");
  }

  ctx.render(addTemp);
}
