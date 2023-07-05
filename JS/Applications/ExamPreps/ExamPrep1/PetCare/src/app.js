import {html, render, nothing} from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs'
import { catalogView } from './views/catalogView.js';
import { createView } from './views/createView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { updateNav } from './lib.js';
import { detailsView } from './views/detailsView.js';

const mainContainer = document.getElementById('content');


updateNav();

page('/', middleware, homeView);
page('/index.html', middleware, homeView);
page('/catalog', middleware, catalogView);
page('/login', middleware, loginView);
page('/register', middleware, registerView);
page('/logout', logout);
page('/create', middleware, createView);
page('/details/:id', middleware, detailsView);

page.start();

function middleware(ctx, next){
    ctx.render = (content) => render(content, mainContainer);
    //debugger
    next();
}

async function logout(){
    let response = await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {}
    });
    debugger

    if(response.ok === false){
        alert(response.status)
    }
    let data = await response.json();

    sessionStorage.removeItem("userData");
    updateNav();
    page.redirect('/');
}