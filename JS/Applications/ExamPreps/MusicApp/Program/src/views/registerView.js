import { register } from "../api/user.js";
import { html } from "../lib.js";
import { updateNav } from "../nav.js";

export function registerView(ctx) {
    ctx.render(registerTemp(onRegister));

    async function onRegister(e){
        e.preventDefault();

        const formData = new FormData(e.target);
        const data = Object.fromEntries(formData);

        //debugger
        if(!data.email || !data.password || !data[`conf-pass`]){
            return alert('all fields is required');
        }
    
        if(data.password !== data[`conf-pass`]){
            return alert('pasword does not match');
        }

        await register(data.email, data.password);

        updateNav();
        ctx.page.redirect('/');
    }
}

const registerTemp = (heandler) => html`
  <section id="registerPage">
    <form @submit="${heandler}">
      <fieldset>
        <legend>Register</legend>

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

        <label for="conf-pass" class="vhide">Confirm Password:</label>
        <input
          id="conf-pass"
          class="conf-pass"
          name="conf-pass"
          type="password"
          placeholder="Confirm Password"
        />

        <button type="submit" class="register">Register</button>

        <p class="field">
          <span>If you already have profile click <a href="/login">here</a></span>
        </p>
      </fieldset>
    </form>
  </section>
`;


