import { html } from "../../node_modules/lit-html/lit-html.js";

export function registerView(ctx){
    let template = html`
    <section id="register">
        <article class="narrow">
            <header class="pad-med">
                <h1>Register</h1>
            </header>
            <form @submit=${onSubmit} id="register-form" class="main-form pad-large">
                <div class="error">Error message.</div>
                <label>E-mail: <input type="text" name="email"></label>
                <label>Username: <input type="text" name="username"></label>
                <label>Password: <input type="password" name="password"></label>
                <label>Repeat: <input type="password" name="repass"></label>
                <input class="action cta" type="submit" value="Create Account">
            </form>
            <footer class="pad-small">Already have an account? <a href="#" class="invert">Sign in here</a>
            </footer>
        </article>
    </section>
    `;

    ctx.render(template);

    async function onSubmit(e){
        e.preventDefault();

        debugger;
        let formData = new FormData(e.target);

        let email = formData.get('email');
        let username = formData.get('username');
        let password = formData.get('password');
        let repass = formData.get('repass');
    }
}