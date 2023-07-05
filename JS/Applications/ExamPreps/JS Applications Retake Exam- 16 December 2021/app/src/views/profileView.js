import { get } from "../api/api.js";
import { html } from "../lib.js";
import { updateNav } from "../nav.js";

export async function profileView(ctx) {
  //debugger
  const events = await get(
    `/data/theaters?where=_ownerId%3D%22${ctx.user._id}%22&sortBy=_createdOn%20desc`
  );

  const evTemp = (content) => html`
    <div class="eventBoard">
      <div class="event-info">
        <img src="${content.imageUrl}" />
        <h2>${content.title}</h2>
        <h6>${content.date}</h6>
        <a href="/details/${content._id}" class="details-button">Details</a>
      </div>
    </div>
  `;

  const profileTemp = html`
    <section id="profilePage">
      <div class="userInfo">
        <div class="avatar">
          <img src="./images/profilePic.png" />
        </div>
        <h2>${ctx.user.email}</h2>
      </div>
      <div class="board">
        <!--If there are event-->
        ${events.length > 0
          ? html`${events.map(evTemp)}`
          : html`<div class="no-events">
              <p>This user has no events yet!</p>
            </div>`}
        <!--If there are no event-->
      </div>
    </section>
  `;

  updateNav();
  ctx.render(profileTemp);
}
