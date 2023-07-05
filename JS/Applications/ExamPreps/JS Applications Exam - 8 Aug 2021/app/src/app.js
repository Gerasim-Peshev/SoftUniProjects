/**
 * Import views
 */

import { page, render } from "./lib.js";
import { updateNav } from "./navigation.js";
import { getUserData } from "./util.js";
import { addView } from "./views/addView.js";
import { booksView } from "./views/booksView.js";
import { dashboardView } from "./views/dashboardView.js";
import { detailsView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";
import { loginView } from "./views/loginView.js";
import { registerView } from "./views/register.js";


//get main element from renderer
const main = document.getElementById('site-content');

//attached middle ware
page(decorateContext);

//create page routing
page('/', dashboardView);
page('/index.html', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/books', booksView);
page('/add', addView);


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