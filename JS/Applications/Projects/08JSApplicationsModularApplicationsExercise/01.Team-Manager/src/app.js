import page from "../node_modules/page/page.mjs";
import { html, render } from "../node_modules/lit-html/lit-html.js";
import { homeView } from "./views/homeView.js";
import { loginView } from "./views/loginView.js";
import { registerView } from "./views/registerView.js";
import { logoutView } from "./views/logoutView.js";
import { err404View } from "./views/error404View.js";
import { browseView } from "./views/browseView.js";
import { editView } from "./views/editView.js";
import { myTeamView } from "./views/myTeamView.js";
import { teamHomeView } from "./views/teamHomeView.js";

//console.log('appJs work')

let mainElement = document.querySelector('main');

page('/', midWare, homeView);
page('index.html', midWare, homeView);
page('/login', midWare, loginView);
page('/register', midWare, registerView);
page('/browse', midWare, browseView);
page('/edit/:id', midWare, editView);
page('/my-team', midWare, myTeamView);
page('/team-home', midWare, teamHomeView);
page('/logout', midWare, logoutView);
page('/*', err404View);

page.start();

function midWare(ctx, next){
    ctx.render = (content) => render(content, mainElement);

    next();
}