class Garden {
	constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = []; 
    }

    addPlant(plantName, spaceRequired){
        if(this.spaceAvailable < spaceRequired){
            throw new Error('Not enough space in the garden.');
        } else {
            let plant = {
                plantName: plantName,
                spaceRequired: spaceRequired,
                ripe: false,
                quantity: 0
            }

            this.plants.push(plant);
            this.spaceAvailable -= spaceRequired;

            return `The ${plantName} has been successfully planted in the garden.`
        }
    }

    ripenPlant(plantName, quantity){
        let plant = this.plants.find(x => x.plantName === plantName);

        if(plant === undefined){
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if(plant.ripe){
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if(quantity <= 0){
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plant.ripe = true;
        plant.quantity += quantity;

        return plant.quantity === 1 ? `${quantity} ${plantName} has successfully ripened.` : `${quantity} ${plantName}s have successfully ripened.`
    }

    harvestPlant(plantName){
        let plant = this.plants.find(x => x.plantName === plantName);

        if(plant === undefined){
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if(!plant.ripe){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.storage.push({plantName: plant.plantName, quantity: plant.quantity});
        this.spaceAvailable += plant.spaceRequired;
        this.plants = this.plants.filter(x => x !== plant);

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport(){
        let srtToReturn = '';

        srtToReturn += `The garden has ${this.spaceAvailable} free space left.\n`;

        this.plants = this.plants.sort((a, b) => a.plantName > b.plantName ? 1 : a.plantName < b.plantName ? -1 : 0);

        srtToReturn += `Plants in the garden: ` 
        this.plants.forEach(x => srtToReturn += x.plantName + ', ');
        srtToReturn = srtToReturn.slice(0, srtToReturn.length - 2);
        srtToReturn += '\n';

        if(this.storage.length === 0){
            srtToReturn += `Plants in storage: The storage is empty.\n`;
        } else {
            srtToReturn += `Plants in storage: `;
            this.storage.forEach(x => srtToReturn += `${x.plantName} (${x.quantity}), `);

            srtToReturn = srtToReturn.slice(0, srtToReturn.length - 2);
        }

        return srtToReturn;
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





