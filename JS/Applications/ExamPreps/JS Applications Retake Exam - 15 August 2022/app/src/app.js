/**
 * Import views
 */

import { page, render } from "./lib.js";
import { getUserData } from "./util.js";
import {updateNav} from './navigation.js'
import { homeView } from "./views/homeView.js";
import { dashboardView } from "./views/dashboardView.js";
import { loginView } from "./views/loginView.js";
import { registerView } from "./views/registerView.js";
import { createView } from "./views/createView.js";
import { detailsView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";


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
page('/create', createView);
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