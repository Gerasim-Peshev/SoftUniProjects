import { html, nothing } from "../lib.js";
import { getAllCatalogData } from "../api/data.js";

export async function catalogView(ctx) {

  const catalogData = await getAllCatalogData();
    

  const catalogTemp = () => html`
    <section id="catalogPage">
      <h1>All Albums</h1>

      ${catalogData.length > 0 ? html`${catalogData.map((dat) => cardTemp(dat))}` : html`<p>No Albums in Catalog!</p>`}
      <!--No albums in catalog-->
      
    </section>
  `;

  const cardTemp = (elem) => html`
    <div class="card-box">
      <img src="${elem.imgUrl}" />
      <div>
        <div class="text-center">
          <p class="name">Name: ${elem.name}</p>
          <p class="artist">Artist: ${elem.artist}</p>
          <p class="genre">Genre: ${elem.genre}</p>
          <p class="price">Price: $${elem.price}</p>
          <p class="date">Release Date: ${elem.releaseDate}</p>
        </div>
        <div class="btn-group">
          ${ctx.user ? html`<a href="/details/${elem._id}" id="details">Details</a>` : nothing}
        </div>
      </div>
    </div>
  `;

  //debugger
  ctx.render(catalogTemp());
}

