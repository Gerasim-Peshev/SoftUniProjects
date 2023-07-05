import { register } from "../api/user.js";
import { html } from "../lib.js";
import { updateNav } from "../nav.js";

export function registerView(ctx) {
  const registerTemp = html`
    <section id="registerPage">
      <form class="registerForm" @submit="${onRegister}">
        <h2>Register</h2>
        <div class="on-dark">
          <label for="email">Email:</label>
          <input
            id="email"
            name="email"
            type="text"
            placeholder="steven@abv.bg"
            value=""
          />
        </div>

        <div class="on-dark">
          <label for="password">Password:</label>
          <input
            id="password"
            name="password"
            type="password"
            placeholder="********"
            value=""
          />
        </div>

        <div class="on-dark">
          <label for="repeatPassword">Repeat Password:</label>
          <input
            id="repeatPassword"
            name="repeatPassword"
            type="password"
            placeholder="********"
            value=""
          />
        </div>

        <button class="btn" type="submit">Register</button>

        <p class="field">
          <span>If you have profile click <a href="#">here</a></span>
        </p>
      </form>
    </section>
  `;

  async function onRegister(e){
    e.preventDefault();

    debugger
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.email || !data.password || !data.repeatPassword){
        return alert('all fields are required');
    }
    if(data.password !== data.repeatPassword){
        return alert('password does not match');
    }

    await register(data.email, data.password);
    updateNav();
    ctx.page.redirect('/');
  }

  ctx.render(registerTemp);
}
