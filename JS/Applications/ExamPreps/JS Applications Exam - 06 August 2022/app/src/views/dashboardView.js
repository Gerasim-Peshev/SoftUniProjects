import { html } from "../lib.js";
import { get } from "../api/api.js";

export async function dashboardView(ctx) {

    //debugger
  const offers = await get("/data/offers?sortBy=_createdOn%20desc");

  const offerTemp = (content) => html`
    <div class="offer">
      <img src="${content.imageUrl}" alt="example2" />
      <p>
        <strong>Title: </strong
        ><span class="title">${content.title}</span>
      </p>
      <p><strong>Salary:</strong><span class="salary">${content.salary}</span></p>
      <a class="details-btn" href="/details/${content._id}">Details</a>
    </div>
  `;

  const dashboardTemp = html`
    <section id="dashboard">
      <h2>Job Offers</h2>

      <!-- Display a div with information about every post (if any)-->
        ${offers.length > 0 ? html`${offers.map(offerTemp)}` : html`<h2>No offers yet.</h2>`}
      <!-- Display an h2 if there are no posts -->
    </section>
  `;

  ctx.render(dashboardTemp);
}
