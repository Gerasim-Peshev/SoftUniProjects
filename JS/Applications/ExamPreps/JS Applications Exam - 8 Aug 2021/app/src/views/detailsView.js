import { del, get } from "../api/api.js";
import { html, nothing } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function detailsView(ctx) {

    //debugger
    const elem = await get('/data/books/' + ctx.params.id);

  const detailsTemp = html`
    <section id="details-page" class="details">
      <div class="book-information">
        <h3>${elem.title}</h3>
        <p class="type">Type: ${elem.type}</p>
        <p class="img"><img src="${elem.imageUrl}" /></p>
        <div class="actions">
          <!-- Edit/Delete buttons ( Only for creator of this book )  -->
          ${ctx.user && elem._ownerId === ctx.user._id ? html`<a class="button" href="/edit/${elem._id}">Edit</a>` : nothing}
          ${ctx.user && elem._ownerId === ctx.user._id ? html`<a @click="${onDelete}" class="button" href="javascript:(0)">Delete</a>` : nothing}

          <!-- Bonus -->
          <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
          ${ctx.user && ctx.user._id == elem._ownerId ? nothing : html`<a class="button" href="#">Like</a>`}

          <!-- ( for Guests and Users )  -->
          <div class="likes">
            <img class="hearts" src="/images/heart.png" />
            <span id="total-likes">Likes: 0</span>
          </div>
          <!-- Bonus -->
        </div>
      </div>
      <div class="book-description">
        <h3>Description:</h3>
        <p>
          ${elem.description}
        </p>
      </div>
    </section>
  `;

  async function onDelete(e){
    e.preventDefault();

    const check = confirm('are you sure you want to delete element');
    if(check){
        await del('/data/books/' + ctx.params.id);

        updateNav();
        ctx.page.redirect('/');
    }
  }

  ctx.render(detailsTemp);
}
