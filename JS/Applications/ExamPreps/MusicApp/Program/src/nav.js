import { html ,render, nothing } from "./lib.js";
import { logout } from "./api/user.js";
import { getUserData } from "./util.js";

export function updateNav() {
    const user = getUserData();
    render(navTemp(user), headerElem);
}

const headerElem = document.querySelector("header");

const navTemp = (user) => html`
  <nav>
    <img src="./images/headphones.png"/>
    <a href="/">Home</a>
    <ul>
      <!--All user-->
      <li><a href="/catalog">Catalog</a></li>
      <li><a href="/search">Search</a></li>
      <!--Only guest-->
      ${!user ? html`<li><a href="/login">Login</a></li>` : nothing}
      ${!user ? html`<li><a href="/register">Register</a></li>` : nothing}
      <!--Only user-->
      ${user ? html`<li><a href="/create">Create Album</a></li>` : nothing}
      ${user ? html`<li><a @click="${logout}" href="javascript:void(0)">Logout</a></li>` : nothing}
    </ul>
  </nav>
`;
