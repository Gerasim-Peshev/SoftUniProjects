import page from '../node_modules/page/page.mjs'


page('/index.html', '/');
page('/', 'my-furniture.html');
page.start();