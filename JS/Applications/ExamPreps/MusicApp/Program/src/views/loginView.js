import { login } from "../api/user.js";
import { html } from "../lib.js";
import { updateNav } from "../nav.js";

export function loginView(ctx) {
    ctx.render(loginTemp(onLogin));

    async function onLogin(e){

        //debugger
        e.preventDefault();
        const formData = new FormData(e.target);
        const data = Object.fromEntries(formData);

        //debugger
        const email = data.email;
        const pass = data.password;

        await login(email, pass);

        updateNav();
        ctx.page.redirect('/');
    }
}

const loginTemp = (heandler) => html`
  <section id="loginPage">
    <form @submit="${heandler}">
      <fieldset>
        <legend>Login</legend>

        <label for="email" class="vhide">Email</label>
        <input
          id="email"
          class="email"
          name="email"
          type="text"
          placeholder="Email"
        />

        <label for="password" class="vhide">Password</label>
        <input
          id="password"
          class="password"
          name="password"
          type="password"
          placeholder="Password"
        />

        <button type="submit" class="login">Login</button>

        <p class="field">
          <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
      </fieldset>
    </form>
  </section>
`;


