/**
 * Import views
 */
import { page, render } from "./lib.js";
import { updateNav } from "./nav.js";
import { getUserData } from "./util.js";
import { catalogView } from "./views/catalogView.js";
import { createView } from "./views/createView.js";
import { detailView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";
import { homeView } from "./views/homeView.js";
import { loginView } from "./views/loginView.js";
import { registerView } from "./views/registerView.js";
import { searchView } from "./views/searchView.js";

const user = getUserData();

//get main element from renderer
const main = document.getElementById('main-content');

//attached middle ware
page(decorateContext);

//create page routing
page('/', homeView);
page('/index.html', homeView);
page('/catalog', catalogView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailView);
page('/edit/:id', editView);
page('/search', searchView);

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