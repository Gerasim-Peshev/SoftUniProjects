import { logout } from "./api/user.js";
import { html, render, nothing } from "./lib.js";
import { getUserData } from "./util.js";

export async function updateNav() {
  const user = getUserData();

  render(navTemp(user), headers);
}

const headers = document.querySelector("header");

const navTemp = (user) => html`
  <a id="logo" href="/"><img id="logo-img" src="./images/logo.jpg" alt="" /></a>

  <nav>
    <div>
      <a href="/dashboard">Dashboard</a>
    </div>

    <!-- Logged-in users -->
    <div class="user">
      ${user ? html`<a href="/create">Create Offer</a>` : nothing}
      ${user ? html`<a @click="${logout}" href="javascript:void(0)">Logout</a>` : nothing}
    </div>

    <!-- Guest users -->
    <div class="guest">
      ${!user ? html`<a href="/login">Login</a>` : nothing}
      ${!user ? html`<a href="/register">Register</a>` : nothing}
    </div>
  </nav>
`;
