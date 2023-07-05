let chooseYourCar = require('../chooseYourCar');
let {assert} = require('chai');

describe('tests', () => {
    describe('choosingType tests', () => {
        it('throw1', () => {
            assert.throw(() => chooseYourCar.choosingType('Sedan', 'red', 1888), "Invalid Year!");
        });
        it('throw2', () => {
            assert.throw(() => chooseYourCar.choosingType('Sedan', 'red', 2024), "Invalid Year!");
        });

        it('valid input', () => {
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2010), "This red Sedan meets the requirements, that you have.");
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2014), "This red Sedan meets the requirements, that you have.");

            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 2004), "This Sedan is too old for you, especially with that red color.");
            assert.equal(chooseYourCar.choosingType('Sedan', 'red', 1996), "This Sedan is too old for you, especially with that red color.");
        });
    });

    describe('brandName tests', () => {
        it('invalid inputs', () => {
            assert.throw(() => chooseYourCar.brandName('arr', 4), "Invalid Information!");
            assert.throw(() => chooseYourCar.brandName([], '4'), "Invalid Information!");
            assert.throw(() => chooseYourCar.brandName(['BMW'], -4), "Invalid Information!");
            assert.throw(() => chooseYourCar.brandName(['BMW'], 4), "Invalid Information!");
        });

        it('valid inputs', () => {
            assert.equal(chooseYourCar.brandName(['BMW', 'Toyota', 'Peugeot'], 2), 'BMW, Toyota');
        });
    });

    describe('CarFuelConsumption tests', () => {
        it('invalid inputs', () => {
            assert.throw(() => chooseYourCar.carFuelConsumption('4', 4), "Invalid Information!");
            assert.throw(() => chooseYourCar.carFuelConsumption(4, '4'), "Invalid Information!");
            assert.throw(() => chooseYourCar.carFuelConsumption('4', '4'), "Invalid Information!");
            assert.throw(() => chooseYourCar.carFuelConsumption(-4, 4), "Invalid Information!");
            assert.throw(() => chooseYourCar.carFuelConsumption(4, -4), "Invalid Information!");
            assert.throw(() => chooseYourCar.carFuelConsumption(-4, -4), "Invalid Information!");
        });

        it('valid input', () => {
            assert.equal(chooseYourCar.carFuelConsumption(100, 5), `The car is efficient enough, it burns 5.00 liters/100 km.`);
            assert.equal(chooseYourCar.carFuelConsumption(100, 7), `The car is efficient enough, it burns 7.00 liters/100 km.`);

            assert.equal(chooseYourCar.carFuelConsumption(100, 8), `The car burns too much fuel - 8.00 liters!`);
            assert.equal(chooseYourCar.carFuelConsumption(100, 12), `The car burns too much fuel - 12.00 liters!`);
        });
    });
});