import { register } from "../api/user.js";
import { html } from "../lib.js";
import { updateNav } from "../navigation.js";

export async function registerView(ctx) {
  const registerTemp = html`
    <section id="register">
      <div class="form" @submit="${onRegister}">
        <h2>Register</h2>
        <form class="login-form">
          <input
            type="text"
            name="email"
            id="register-email"
            placeholder="email"
          />
          <input
            type="password"
            name="password"
            id="register-password"
            placeholder="password"
          />
          <input
            type="password"
            name="re-password"
            id="repeat-password"
            placeholder="repeat password"
          />
          <button type="submit">register</button>
          <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
      </div>
    </section>
  `;

async function onRegister(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    //debugger
    if (!data.email || !data.password || !data["re-password"]) {
      return alert("all fields are required");
    }
    if (data.password !== data["re-password"]) {
      return alert("passwords does not match");
    }

    await register(data.email, data.password);

    updateNav();
    ctx.page.redirect("/dashboard");
  }

  ctx.render(registerTemp);
}
