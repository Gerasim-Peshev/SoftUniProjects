import { html } from "../lib.js";
import { login } from "../api/user.js";
import { updateNav } from "../navigation.js";

export async function loginView(ctx) {
  const loginTemp = html`
    <section id="login">
      <div class="form" @submit="${onLogin}">
        <h2>Login</h2>
        <form class="login-form">
          <input type="text" name="email" id="email" placeholder="email" />
          <input
            type="password"
            name="password"
            id="password"
            placeholder="password"
          />
          <button type="submit">login</button>
          <p class="message">
            Not registered? <a href="/register">Create an account</a>
          </p>
        </form>
      </div>
    </section>
  `;

async function onLogin(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if (!data.email || !data.password) {
      return alert("all fields are required");
    }

    await login(data.email, data.password);

    updateNav();
    ctx.page.redirect("/dashboard");
  }

  ctx.render(loginTemp);
}
