import { html, render, nothing, page } from "./lib.js";
import { getUserData } from "./util.js";
import { logout } from "./api/user.js";

export async function updateNav() {
  const user = getUserData();

  render(navTemp(user), headers);
}

const headers = document.querySelector("header");

const navTemp = (user) => html`
  <!-- Navigation -->
  <a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>

  <nav>
    <div>
      <a href="/dashboard">Dashboard</a>
    </div>

    <!-- Logged-in users -->
    <div class="user">
      ${user ? html`<a href="/create">Add Album</a>` : nothing}
      ${user ? html`<a @click="${onLogout}" href="javascript:void(0)">Logout</a>` : nothing}
    </div>

    <!-- Guest users -->
    <div class="guest">
      ${!user ? html`<a href="/login">Login</a>` : nothing}
      ${!user ? html`<a href="/register">Register</a>` : nothing}
    </div>
  </nav>
`;

async function onLogout(e){
    e.preventDefault();

    logout();
    await page.redirect('/dashboard');
}
