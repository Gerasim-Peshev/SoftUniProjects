function solution(){
    
    let storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let recipes = {
        apple: {carbohydrate: 1, flavour: 2},
        lemonade: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        eggs: {protein: 5, fat: 1, flavour: 1},
        turkey: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}    
    }

    return function manager(inputText){
        let line = inputText.split(' ');

        switch(line[0]){
            case 'restock':
                return restock(line[1], Number(line[2]));
            case 'prepare':
                return prepare(line[1], Number(line[2]));
            case 'report':
                return report();
        }
    }

    function restock(typeFood, quantity){
        storage[typeFood] += quantity;
        return 'Success';
    }

    function prepare(recipe, quantity){
        let canBeCooked = true;

        let meal = recipes[recipe];

        for(let ingridient of Object.entries(meal)){
            if(storage[ingridient[0]] - (meal[ingridient[0]] * quantity) < 0){
                canBeCooked = false;
                return `Error: not enough ${ingridient[0]} in stock`
            }
        }

        if(canBeCooked){
            for(let ingridient of Object.entries(meal)){
                storage[ingridient[0]] -= meal[ingridient[0]] * quantity;
            }
            return `Success`;
        }
    }

    function report(){
        return `protein=${storage['protein']} carbohydrate=${storage['carbohydrate']} fat=${storage['fat']} flavour=${storage['flavour']}`;
    }
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock carbohydrate 10")); // Success 
console.log (manager ("restock flavour 10")); // Success 
console.log (manager ("prepare apple 1")); // Success 
console.log (manager ("restock fat 10")); // Success 
console.log (manager ("prepare burger 1")); // Success 
console.log (manager ("report")); // protein=0 carbohydrate=4 fat=3 flavour=55


