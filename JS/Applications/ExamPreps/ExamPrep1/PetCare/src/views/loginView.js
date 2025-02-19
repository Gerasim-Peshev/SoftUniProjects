import { html } from "../../node_modules/lit-html/lit-html.js";
import { setUserData } from "../api/util.js";
import { updateNav } from "../lib.js";

let cont;

export function loginView(ctx) {

cont = ctx;

  const loginTemplate = html`
    <section id="loginPage">
      <form @submit="${onLogin}" class="loginForm">
        <img src="./images/logo.png" alt="logo" />
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
          <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
      </form>
    </section>
  `;

  ctx.render(loginTemplate);
}

async function onLogin(e){
    e.preventDefault();
    
    debugger
    let formData = new FormData(e.target);

    let email = formData.get('email');
    let password = formData.get('password');

    const response = await login(email, password);
    updateNav();
    cont.page.redirect('/');
}

async function login(emailToUse, password){

    const body = JSON.stringify({email: emailToUse, password});

    const response = await fetch('http://localhost:3030/users/login', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body
    });

    const {_id, email, accessToken} = await response.json();

    sessionStorage.setItem("userData", JSON.stringify({_id, email, accessToken}));
}
