class VegetableStore{
    constructor(owner, location){
        this.owner = owner;
        this.location = location;
        this.availableProducts = []; 
    }

    loadingVegetables(vegetables){

        let vegNames = [];
        for(let veg of vegetables){
            let line = veg.split(' ');
            let typeOfVeg = line[0];
            let quantityOfVeg = Number(line[1]);
            let priceOfVeg = Number(line[2]);

            let vegToFind = this.availableProducts.find(x => x.type === typeOfVeg);
            if(vegToFind){
                vegToFind.quantity += quantityOfVeg;
                if(vegToFind.price < priceOfVeg){
                    vegToFind.price = priceOfVeg;
                }
            } else {
                this.availableProducts.push({type: typeOfVeg, quantity: quantityOfVeg, price: priceOfVeg});
                vegNames.push(typeOfVeg);
            }
        }

        return `Successfully added ${vegNames.join(', ')}`;
    }

    buyingVegetables(selectedProducts){
        let totalPrice = 0;
        for(let prod of selectedProducts){
            let line = prod.split(' ');
            let typeOfProd = line[0];
            let quantityOfProd = Number(line[1]);

            let prodToFind = this.availableProducts.find(x => x.type === typeOfProd);

            if(!prodToFind){
                throw new Error(`${typeOfProd} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if(quantityOfProd > prodToFind.quantity){
                throw new Error(`The quantity ${quantityOfProd} for the vegetable ${typeOfProd} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            totalPrice += prodToFind.price * quantityOfProd;
            prodToFind.quantity -= quantityOfProd;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity){
        
        let prodToFind = this.availableProducts.find(x => x.type === type);
        if(!prodToFind){
            throw new Error(`${type} is not available in the store.`);
        }

        if(prodToFind.quantity < quantity){
            prodToFind.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        prodToFind.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }

    revision(){
        let srtToRet = "Available vegetables:\n";

        this.availableProducts = this.availableProducts.sort((a, b) => a.price - b.price);
        for(let veg of this.availableProducts){
            srtToRet += `${veg.type}-${veg.quantity}-$${veg.price}\n`;
        }

        srtToRet += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;
        return srtToRet;
    }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());



