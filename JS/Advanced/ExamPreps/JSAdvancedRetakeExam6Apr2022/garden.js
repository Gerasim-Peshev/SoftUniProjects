class Garden {
	constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = []; 
    }

    addPlant(plantName, spaceRequired){

        if(this.spaceAvailable - spaceRequired < 0){
            throw new Error("Not enough space in the garden.");
        }

        this.plants.push({plantName: plantName, spaceRequired: spaceRequired, ripe: false, quantity: 0});
        this.spaceAvailable -= spaceRequired;
        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity){
        let plantToFind = this.plants.find(x => x.plantName === plantName);

        if(!plantToFind){
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if(plantToFind.ripe){
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if(quantity <= 0){
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plantToFind.ripe = true;
        plantToFind.quantity += quantity;

        if(quantity === 1){
            return `${quantity} ${plantName} has successfully ripened.`;
        } else {
            return `${quantity}s ${plantName} has successfully ripened.`;
        }
    }

    harvestPlant(plantName){
        let plantToFind = this.plants.find(x => x.plantName === plantName);

        if(!plantToFind){
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if(!plantToFind.ripe){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.storage.push({plantName: plantToFind.plantName, quantity: plantToFind.quantity});
        this.spaceAvailable += plantToFind.spaceRequired;
        this.plants = this.plants.filter(x => x !== plantToFind);

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport(){
        let srtToRet = `The garden has ${this.spaceAvailable} free space left.\n`;

        let arrOfPlants = this.plants.sort((a, b) => a.plantName > b.plantName ? 1 : a.plantName < b.plantName ? -1 : 0);
        srtToRet += `Plants in the garden: `;
        for(let i = 0; i < arrOfPlants.length; i++){
            if(i === arrOfPlants.length - 1){
                srtToRet += `${arrOfPlants[i].plantName}\n`;
            } else {
                srtToRet += `${arrOfPlants[i].plantName}, `;
            }
        }

        if(this.storage.length === 0){
            srtToRet += "Plants in storage: The storage is empty.";
        } else {
            srtToRet += `Plants in storage: `;
            for(let i = 0; i < this.storage.length; i++){
                if(i === this.storage.length - 1){
                    srtToRet += `${this.storage[i].plantName} (${this.storage[i].quantity})`;
                } else {
                    srtToRet += `${this.storage[i].plantName} (${this.storage[i].quantity}), `
                }
            }
        }

        return srtToRet;
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());






