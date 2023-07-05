function Fruit(fruit, weight, price){
    let kilos = (weight/1000);

    let sum = price*kilos;

    console.log(`I need \$${sum.toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`)
}

Fruit('apple', 1563, 2.35)