import { logout } from "./api/user.js";
import { html, nothing, render } from "./lib.js";
import { getUserData } from "./util.js";

export async function updateNav() {
  const user = getUserData();

  render(navTemp(user), headers);
}

const headers = document.querySelector("header");

const navTemp = (user) => html`
  <nav>
    <section class="logo">
      <img src="./images/logo.png" alt="logo" />
    </section>
    <ul>
      <!--Users and Guest-->
      <li><a href="/">Home</a></li>
      <li><a href="/dashboard">Dashboard</a></li>
      <!--Only Guest-->
      ${!user ? html`<li><a href="/login">Login</a></li>` : nothing}
      ${!user ? html`<li><a href="/register">Register</a></li>` : nothing}
      <!--Only Users-->
      ${user ? html`<li><a href="/create">Create Postcard</a></li>` : nothing}
      ${user ? html`<li><a @click="${logout}" href="javascript:(0)">Logout</a></li>` : nothing}
    </ul>
  </nav>
`;