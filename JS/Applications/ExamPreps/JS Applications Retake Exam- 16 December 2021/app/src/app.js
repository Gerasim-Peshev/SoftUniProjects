import { page, render } from "./lib.js";
import { updateNav } from "./nav.js";
import { getUserData } from "./util.js";
import { createView } from "./views/createView.js";
import { detailsView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";
import { homeView } from "./views/homeView.js";
import { loginView } from "./views/loginView.js";
import { profileView } from "./views/profileView.js";
import { registerView } from "./views/registerView.js";


//get main element from renderer
const main = document.getElementById('content');

//attached middle ware
page(decorateContext);

//create page routing
page('/', homeView);
page('/index.html', homeView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/profile', profileView);
updateNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUserData();
    if(user){
        ctx.user = user;
    }

    next();
}

function renderMain(content){
    render(content, main);
}