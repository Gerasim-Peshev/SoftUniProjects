import { get } from "../api/api.js";
import { html } from "../lib.js";

export async function booksView(ctx) {

    //debugger
    const books = await get(`/data/books?where=_ownerId%3D%22${ctx.user._id}%22&sortBy=_createdOn%20desc`)

    const bookTemp = (book) => html`
      <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}" /></p>
        <a class="button" href="/details/${book._id}">Details</a>
      </li>
    `;
  const myBooksTemp = html`
    <section id="my-books-page" class="my-books">
      <h1>My Books</h1>
      <!-- Display ul: with list-items for every user's books (if any) -->
      <ul class="my-books-list">
        ${books.length > 0 ? html`${books.map(bookTemp)}` : html`<p class="no-books">No books in database!</p>`}
      </ul>
      <!-- Display paragraph: If the user doesn't have his own books  -->
    </section>
  `;


  ctx.render(myBooksTemp);
}
