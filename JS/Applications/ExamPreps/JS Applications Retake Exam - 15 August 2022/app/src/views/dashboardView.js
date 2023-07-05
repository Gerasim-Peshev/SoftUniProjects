import { get } from "../api/api.js";
import { html } from "../lib.js";

export async function dashboardView(ctx) {
  const shoes = await get("/data/shoes?sortBy=_createdOn%20desc");

  const shoeCard = (content) => html`
    <li class="card">
      <img src="${content.imageUrl}" alt="eminem" />
      <p><strong>Brand: </strong><span class="brand">${content.brand}</span></p>
      <p>
        <strong>Model: </strong
        ><span class="model">${content.model}</span>
      </p>
      <p><strong>Value:</strong><span class="value">${content.value}</span>$</p>
      <a class="details-btn" href="/details/${content._id}">Details</a>
    </li>
  `;

  const dashboardTemp = html`
    <section id="dashboard">
      <h2>Collectibles</h2>
      <ul class="card-wrapper">
        <!-- Display a li with information about every post (if any)-->
        ${shoes.length > 0 ? html`${shoes.map(shoeCard)}` : html`<h2>There are no items added yet.</h2>`}
      </ul>

      <!-- Display an h2 if there are no posts -->

    </section>
  `;

  ctx.render(dashboardTemp);
}
