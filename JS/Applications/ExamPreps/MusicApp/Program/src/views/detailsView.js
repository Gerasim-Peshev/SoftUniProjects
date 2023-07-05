import { html, nothing } from "../lib.js";
import { getCatalogElementDetails } from "../api/data.js";
import { del } from "../api/api.js";

export async function detailView(ctx) {
  
  //debugger
  const elem = await getCatalogElementDetails(ctx.params.id);

  const detailsTemp = (elem) => html`
    <section id="detailsPage">
      <div class="wrapper">
        <div class="albumCover">
          <img src="${elem.imgUrl}" />
        </div>
        <div class="albumInfo">
          <div class="albumText">
            <h1>Name: ${elem.name}</h1>
            <h3>Artist: ${elem.artist}</h3>
            <h4>Genre: ${elem.genre}</h4>
            <h4>Price: $${elem.price}</h4>
            <h4>Date: ${elem.releaseDate}</h4>
            <p>
              ${elem.description}
            </p>
          </div>

          <!-- Only for registered user and creator of the album-->
          ${elem._ownerId === ctx.user._id ? html`<div class="actionBtn">
            <a href="/edit/${elem._id}" class="edit">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" class="remove">Delete</a>
          </div>` : nothing}
        </div>
      </div>
    </section>
  `;

ctx.render(detailsTemp(elem));

async function onDelete(){
  const conf = confirm('Are you sure you want to delete this album?');
  
  if(conf){
    await del('/data/albums/' + elem._id);
    ctx.page.redirect('/catalog');    
  }
}
}

