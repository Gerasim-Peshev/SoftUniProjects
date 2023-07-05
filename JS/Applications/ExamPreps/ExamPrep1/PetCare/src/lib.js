import {html, render, nothing} from '../node_modules/lit-html/lit-html.js'

export function updateNav() {
    let header = document.querySelector('header');
  
    let navTemplate = html`
      <nav>
        <section class="logo">
          <img src="./images/logo.png" alt="logo" />
        </section>
        <ul>
          <!--Users and Guest-->
          <li><a href="/">Home</a></li>
          <li><a href="/catalog">Dashboard</a></li>
          <!--Only Guest-->
          ${!sessionStorage.getItem('userData') ? html`<li><a href="/login">Login</a></li>` : nothing}
          ${!sessionStorage.getItem('userData') ? html`<li><a href="/register">Register</a></li>` : nothing}
          <!--Only Users-->
          ${sessionStorage.getItem('userData') ? html`<li><a href="/create">Create Postcard</a></li>` : nothing}
          ${sessionStorage.getItem('userData') ? html`<li><a href="/logout">Logout</a></li>` : nothing}
        </ul>
      </nav>
    `;

    render(navTemplate, header);
}