import { post } from "../api/api.js";
import { login } from "../api/user.js";
import { html } from "../lib.js";
import { updateNav } from "../nav.js";

export function loginView(ctx) {
  
  const loginTemp = html`
    <section id="loginaPage">
      <form class="loginForm" @submit="${onLogin}">
        <h2>Login</h2>
        <div>
          <label for="email">Email:</label>
          <input
            id="email"
            name="email"
            type="text"
            placeholder="steven@abv.bg"
            value=""
          />
        </div>
        <div>
          <label for="password">Password:</label>
          <input
            id="password"
            name="password"
            type="password"
            placeholder="********"
            value=""
          />
        </div>

        <button class="btn" type="submit">Login</button>

        <p class="field">
          <span>If you don't have profile click <a href="#">here</a></span>
        </p>
      </form>
    </section>
  `;

  async function onLogin(e){
    e.preventDefault();

    const formData = new FormData(e.target);

    const data = Object.fromEntries(formData);

    if(!data.email || !data.password){
        return alert('all fields are required');
    }

    await login(data.email, data.password);
    updateNav();
    ctx.page.redirect('/');
  }

  ctx.render(loginTemp);
}
