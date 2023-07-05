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
          <button type="submit">login</button>
          <p class="message">Already registered? <a href="#">Login</a></p>
        </form>
      </div>
    </section>
  `;

  async function onRegister(e){
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.email || !data.password || !data['re-password']){
        return alert('all fields are required');
    }
    if(data.password !== data['re-password']){
        return alert('passwords does not match');
    }

    await register(data.email, data.password);

    updateNav();
    ctx.page.redirect('/');
  }

  ctx.render(registerTemp);
}
