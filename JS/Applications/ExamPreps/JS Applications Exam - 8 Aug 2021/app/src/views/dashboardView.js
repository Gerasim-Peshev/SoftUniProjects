import { html, nothing } from "../lib.js";
import { get } from "../api/api.js";

export async function dashboardView(ctx) {
  const books = await get("/data/books?sortBy=_createdOn%20desc");

  //debugger
  const bookTemp = (book) => html`
    <li class="otherBooks">
      <h3>${book.title}</h3>
      <p>Type: ${book.type}</p>
      <p class="img"><img src="${book.imageUrl}" /></p>
      <a class="button" href="/details/${book._id}">Details</a>
    </li>
  `;
  const dashboardTemp = (books) => html`
    <section id="dashboard-page" class="dashboard">
      <h1>Dashboard</h1>
      <!-- Display ul: with list-items for All books (If any) -->
      <ul class="other-books-list">
        ${books.length > 0 ? html`${books.map(bookTemp)}` : html`<p class="no-books">No books in database!</p>`}
      </ul>
      <!-- Display paragraph: If there are no books in the database -->
    </section>
  `;


  ctx.render(dashboardTemp(books));
}
