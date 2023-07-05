class ChristmasDinner {
    constructor(budget){
        if(budget < 0){
            throw new Error('The budget cannot be a negative number');
        } else {
            this.budget = budget;
            this.dishes = [];
            this.products = [];
            this.guests = {}; 
        }
    }

    shopping(product){
        let productName = product[0];
        let productPrice = product[1];

        if(this.budget - productPrice < 0){
            throw new Error('Not enough money to buy this product');
        } else {
            this.products.push(productName);
            this.budget -= productPrice;
            return `You have successfully bought ${productName}!`;
        }
    }

    recipes(recipe){
        let nameOfRecipe = recipe.recipeName;
        let recipeProducts = recipe.productsList;

        let allProdsHere = true;
        for(let prod of recipeProducts){
            if(!this.products.includes(prod)){
                allProdsHere = false;
            }
        }

        if(allProdsHere){
            this.dishes.push({recipeName: nameOfRecipe, productList: recipeProducts});
            return `${nameOfRecipe} has been successfully cooked!`;
        } else {
            throw new Error("We do not have this product");
        }
    }

    inviteGuests(name, dish){
        let dishToFind = this.dishes.find(x => x.recipeName === dish);
        let guestToFind = this.guests[name];

        if(!dishToFind){
            throw new Error("We do not have this dish");
        }

        if(guestToFind){
            throw new Error("This guest has already been invited");
        }

        this.guests[name] = dish;
        return `You have successfully invited ${name}!`
    }

    showAttendance(){
        let listToRet = [];
        let srtToRet = '';

        let objects = Object.entries(this.guests);
        for(let i = 0; i < objects.length; i++){
            let gus = objects[i];
            let srtToBuild = '';
            let findedDish = this.dishes.find(x => x.recipeName === gus[1]);
            srtToBuild += `${gus[0]} will eat ${gus[1]}, which consists of ${(findedDish.productList).join(', ')}`;
            listToRet.push(srtToBuild);
        }

        srtToRet += listToRet.join('\n');
        
        return srtToRet;
    }
}

let dinner = new ChristmasDinner(300);

console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));
console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
}));
console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
}));

console.log(dinner.inviteGuests('Ivan', 'Oshav'));
console.log(dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice'));
console.log(dinner.inviteGuests('Georgi', 'Peppers filled with beans'));

console.log(dinner.showAttendance());

