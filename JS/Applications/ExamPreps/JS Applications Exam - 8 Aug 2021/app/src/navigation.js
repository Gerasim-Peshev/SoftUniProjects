import { html, render, nothing } from "./lib.js";
import { getUserData } from "./util.js";
import { logout } from "./api/user.js";

export async function updateNav(ctx) {
    const user = getUserData();
    render(navTemp(user), headers);
}

const headers = document.querySelector('header');

const navTemp = (user) => html`
  <nav class="navbar">
    <section class="navbar-dashboard">
      <a href="/">Dashboard</a>
      <!-- Guest users -->
      <div id="guest">
        ${!user ? html`<a class="button" href="/login">Login</a>` : nothing}
        ${!user ? html`<a class="button" href="/register">Register</a>` : nothing}
      </div>
      <!-- Logged-in users -->
      <div id="user">
        ${user ? html`<span>Welcome, ${user.email}</span>` : nothing}
        ${user ? html`<a class="button" href="/books">My Books</a>` : nothing}
        ${user ? html`<a class="button" href="/add">Add Book</a>` : nothing}
        ${user ? html`<a @click="${logout}" class="button" href="javascript:(0)">Logout</a>` : nothing}
      </div>
    </section>
  </nav>
`;
