import { html } from "../lib.js";

export async function homeView(ctx) {
  const homeTemp = html`
    <section id="home">
      <img src="./images/landing.png" alt="home" />

      <h2 id="landing-text">
        <span>Add your favourite albums</span> <strong>||</strong>
        <span>Discover new ones right here!</span>
      </h2>
    </section>
  `;

  ctx.render(homeTemp);
}
