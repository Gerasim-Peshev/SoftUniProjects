import { login } from "../api/user.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export function loginView(ctx) {
  const loginTemp = html`
    <section id="login-page" class="login">
      <form id="login-form" action="" method="" @submit="${onLogin}">
        <fieldset>
          <legend>Login Form</legend>
          <p class="field">
            <label for="email">Email</label>
            <span class="input">
              <input type="text" name="email" id="email" placeholder="Email" />
            </span>
          </p>
          <p class="field">
            <label for="password">Password</label>
            <span class="input">
              <input
                type="password"
                name="password"
                id="password"
                placeholder="Password"
              />
            </span>
          </p>
          <input class="button submit" type="submit" value="Login" />
        </fieldset>
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
