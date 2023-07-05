/**
 * Import views
 */

import { page, render } from "./lib.js";
import { updateNav } from "./navigation.js";
import { getUserData } from "./util.js";
import { addView } from "./views/addView.js";
import { dashboardView } from "./views/dashboardView.js";
import { detailsView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";
import { homeView } from "./views/homeView.js";
import { loginView } from "./views/loginView.js";
import { registerView } from "./views/registerView.js";



//get main element from renderer
const main = document.querySelector('main');

//attached middle ware
page(decorateContext);

//create page routing
page('/', homeView);
page('/index.html', homeView);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/create', addView)
page('/details/:id', detailsView);
page('/edit/:id', editView);

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