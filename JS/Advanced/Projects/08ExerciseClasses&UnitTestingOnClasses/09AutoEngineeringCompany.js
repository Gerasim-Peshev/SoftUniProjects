function solve(rawCarsArr){

    class Manufactor{
        constructor(carBrand){
            this.brand = carBrand
            this.models = {};
        }
    }


    carsList = [];

    for(let car of rawCarsArr){
        let line = car.split(' | ');
        let manif = line[0];
        let mod = line[1];
        let quanty = Number(line[2]);

        let carToFind = carsList.find(x => x.brand === manif);
        if(carToFind !== undefined){
            //let carToMod1 = carsList.find(x => x.brand === manif);
            if(carToFind.models[mod] === undefined){
                carToFind.models[mod] = quanty;
            } else { 
                carToFind.models[mod] += quanty;
            }
        } else if(carToFind === undefined){
            let carToAdd = new Manufactor(manif);
            carToAdd.models[mod] = quanty;
            carsList.push(carToAdd);
            // let carToMod2 = carsList.find(x => x.brand === manif);
            // carToMod2.models[mod] = quanty;
        }
    }

    let carsToResurn = '';
    for(let brandOfCar of carsList){
        carsToResurn += brandOfCar.brand + '\n';
        for(modelOfBrand of Object.entries(brandOfCar.models)){
            let carMod = modelOfBrand[0];
            let carQuant = modelOfBrand[1];
            carsToResurn += `###${carMod} -> ${carQuant}\n`;
        }
    }

    return carsToResurn.slice(0, -1);
}

console.log(solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
));