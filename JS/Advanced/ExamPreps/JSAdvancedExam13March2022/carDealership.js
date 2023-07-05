class CarDealership {
    constructor(name){
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;      
    }

    addCar(model, hp, price, mileage){

        if(typeof(model) !== 'string' || model.length <= 0 || !Number.isInteger(hp) || hp < 0 || typeof(price) !== 'number' || price < 0 || typeof(mileage) !== 'number' || mileage < 0){
            throw new Error("Invalid input!");
        }
        
        this.availableCars.push({model: model, horsepower: hp, mileage: mileage, price: price});
        return `New car added: ${model} - ${hp} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }

    sellCar(model, desiredMileage){
        let carToFind = this.availableCars.find(x => x.model === model);

        if(!carToFind){
            throw new Error(`${model} was not found!`);
        }

        let diff = carToFind.mileage - desiredMileage;

        if(diff > 40000){
            carToFind.price -= carToFind.price * 0.1;
        } else if(diff <= 40000 && diff > 0){
            carToFind.price -= carToFind.price * 0.05;
        }

        this.soldCars.push({model: carToFind.model, horsepower: carToFind.horsepower, mileage: carToFind.mileage, price: carToFind.price});
        this.totalIncome += carToFind.price;
        this.availableCars = this.availableCars.filter(x => x !== carToFind);

        return `${carToFind.model} was sold for ${carToFind.price.toFixed(2)}$`;
    }

    currentCar(){
        let srtToRet = '';

        if(this.availableCars.length > 0) {
            srtToRet += '-Available cars:\n';
            for(let car of this.availableCars){
                srtToRet += `---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$\n`
            }
            srtToRet = srtToRet.slice(0, srtToRet.length - 1);
        } else {
            srtToRet += "There are no available cars";
        }

        return srtToRet;
    }

    salesReport(criteria){

        let srtToRet = '';

        if(criteria !== "horsepower" && criteria !== "model"){
            throw new Error("Invalid criteria!");
        }

        let carsSorted = [];
        if(criteria === "horsepower"){
            carsSorted = this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
        }

        if(criteria === "model"){
            carsSorted = this.soldCars.sort((a, b) => a.model > b.model ? 1 : a.model < b.model ? -1 : 0);
        }

        srtToRet += `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$\n`;
        srtToRet += `-${this.soldCars.length} cars sold:\n`;
        
        for(let car of this.soldCars){
            srtToRet += `---${car.model} - ${car.horsepower} HP - ${car.price.toFixed(2)}$\n`
        }

        srtToRet = srtToRet.slice(0, srtToRet.length - 1);
        return srtToRet;
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('horsepower'));


