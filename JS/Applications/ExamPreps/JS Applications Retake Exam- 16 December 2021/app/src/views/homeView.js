import { get } from "../api/api.js";
import { html, nothing } from "../lib.js";
import { updateNav } from "../nav.js";

export async function homeView(ctx) {
  //debugger;
  const events = await get("/data/theaters?sortBy=_createdOn%20desc&distinct=title");

  const homeTemp = (events) => html`
    <section class="welcomePage">
      <div id="welcomeMessage">
        <h1>My Theater</h1>
        <p>
          Since 1962 World Theatre Day has been celebrated by ITI Centres, ITI
          Cooperating Members, theatre professionals, theatre organizations,
          theatre universities and theatre lovers all over the world on the 27th
          of March. This day is a celebration for those who can see the value
          and importance of the art form “theatre”, and acts as a wake-up-call
          for governments, politicians and institutions which have not yet
          recognised its value to the people and to the individual and have not
          yet realised its potential for economic growth.
        </p>
      </div>
      <div id="events">
        <h1>Future Events</h1>
        <div class="theaters-container">
          <!--Created Events-->
          ${events.length > 0
            ? html`${events.map(eventTemp)}`
            : html`<h4 class="no-event">No Events Yet...</h4>`}
          <!--No Theaters-->
        </div>
      </div>
    </section>
  `;

  const eventTemp = (content) => html`
    <div class="eventsInfo">
      <div class="home-image">
        <img src="${content.imageUrl}" />
      </div>
      <div class="info">
        <h4 class="title">${content.title}</h4>
        <h6 class="date">${content.date}</h6>
        <h6 class="author">${content.author}</h6>
        <div class="info-buttons">
              <a class="btn-details" href="/details/${content._id}">Details</a>
        </div>
      </div>
    </div>
  `;
  updateNav();
  ctx.render(homeTemp(events));
}
