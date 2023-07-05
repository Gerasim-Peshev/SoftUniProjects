let christmas = new ChristmasMovies();

console.log(christmas.buyMovie('Last Christmas', ['Madison Ingoldsby', 'Emma Thompson', 'Boris Isakovic', 'Madison Ingoldsby']));
console.log(christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']));
console.log(christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']));
console.log(christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Rashida Jones']));
christmas.watchMovie('The Grinch');
console.log(christmas.discardMovie('The Grinch'));
christmas.watchMovie('Home Alone');
christmas.watchMovie('Home Alone');
christmas.watchMovie('Home Alone');
christmas.watchMovie('Last Christmas');
christmas.watchMovie('Last Christmas');
console.log(christmas.favouriteMovie());
console.log(christmas.mostStarredActor());
