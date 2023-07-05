import { html, render, nothing } from "./lib.js";
import { logout } from "./api/user.js";
import { getUserData } from "./util.js";

export function updateNav() {
  //debugger
  const user = getUserData();
  render(navTemp(user), headerElem);
}

const headerElem = document.querySelector('header');

const navTemp = (user) => html`
  <nav>
    <a href="/">Theater</a>
    <ul>
      <!--Only users-->
      ${user ? html`<li><a href="/profile">Profile</a></li>` : nothing}
      ${user ? html`<li><a href="/create">Create Event</a></li>` : nothing}
      ${user ? html`<li><a @click="${logout}" href="javascript:void(0)">Logout</a></li>` : nothing}
      <!--Only guest-->
      ${!user ? html`<li><a href="/login">Login</a></li>` : nothing}
      ${!user ? html`<li><a href="/register">Register</a></li>` : nothing}
    </ul>
  </nav>
`;
