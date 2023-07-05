import { html } from "../lib.js";
import {register} from "../api/user.js"
import { updateNav } from "../navigation.js";

export function registerView(ctx) {
  const registerTemp = html`
    <section id="register-page" class="register">
      <form id="register-form" action="" method="" @submit="${onRegister}">
        <fieldset>
          <legend>Register Form</legend>
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
          <p class="field">
            <label for="repeat-pass">Repeat Password</label>
            <span class="input">
              <input
                type="password"
                name="confirm-pass"
                id="repeat-pass"
                placeholder="Repeat Password"
              />
            </span>
          </p>
          <input class="button submit" type="submit" value="Register" />
        </fieldset>
      </form>
    </section>
  `;

  async function onRegister(e){
    e.preventDefault();

    //debugger
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    if(!data.email || !data.password || !data['confirm-pass']){
      return alert('all fields are required');
    }
    if(data.password !== data['confirm-pass']){
      return alert('passwords does not match');
    }

    await register(data.email, data.password);

    updateNav();
    ctx.page.redirect('/');
  }

  ctx.render(registerTemp);
}
