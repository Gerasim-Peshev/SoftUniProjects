import { get } from "../api/api.js";
import { html, nothing } from "../lib.js";

export async function detailsView(ctx) {

    //debugger
    const elem = await get("/data/offers/" + ctx.params.id);

  const detailsTemp = html`
    <section id="details">
      <div id="details-wrapper">
        <img id="details-img" src="${elem.imageUrl}" alt="example1" />
        <p id="details-title">${elem.title}</p>
        <p id="details-category">
          Category: <span id="categories">${elem.category}</span>
        </p>
        <p id="details-salary">
          Salary: <span id="salary-number">${elem.salary}</span>
        </p>
        <div id="info-wrapper">
          <div id="details-description">
            <h4>Description</h4>
            <span>${elem.imageUrl}</span>
          </div>
          <div id="details-requirements">
            <h4>Requirements</h4>
            <span>${elem.requirements}</span>
          </div>
        </div>
        <p>Applications: <strong id="applications">1</strong></p>

        <!--Edit and Delete are only for creator-->
        <div id="action-buttons">
          ${ctx.user && ctx.user._id == elem._ownerId ? html`<a href="/edit/${elem._id}" id="edit-btn">Edit</a>`: nothing}
          ${ctx.user && ctx.user._id == elem._ownerId ? html`<a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>`: nothing}

          <!--Bonus - Only for logged-in users ( not authors )-->
          <a href="" id="apply-btn">Apply</a>
        </div>
      </div>
    </section>
  `;

  async function onDelete() {
    const check = confirm("are you sure you want to delete this pet");

    if (check) {
      del("/data/pets/" + ctx.params.id);
      ctx.page.redirect("/dashboard");
    }
  }

  ctx.render(detailsTemp);
}
