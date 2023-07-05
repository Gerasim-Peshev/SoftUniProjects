import { get } from "../api/api.js";
import { html } from "../lib.js";

export async function dashboardView(ctx) {
  
    const albums = await get('/data/albums?sortBy=_createdOn%20desc');
  
  const cardTemp = (content) => html`
    <li class="card">
      <img src="${content.imageUrl}" alt="travis" />
      <p><strong>Singer/Band: </strong><span class="singer">${content.singer}</span></p>
      <p>
        <strong>Album name: </strong><span class="album">${content.album}</span>
      </p>
      <p>
        <strong>Sales:</strong
        ><span class="sales">${content.sales}</span>
      </p>
      <a class="details-btn" href="/details/${content._id}">Details</a>
    </li>
  `;

  const dashboardTemp = html`
    <section id="dashboard">
      <h2>Albums</h2>
      <ul class="card-wrapper">
        <!-- Display a li with information about every post (if any)-->
        ${albums.length > 0 ? html`${albums.map(cardTemp)}` : html`<h2>There are no albums added yet.</h2>`}
      </ul>
      <!-- Display an h2 if there are no posts -->  
    </section>
  `;

  ctx.render(dashboardTemp);
}
