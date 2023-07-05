function lowest(arr){
    let result = {};

    for (let part of arr){
        let arr2 = part.split(' | ');
        let town = arr2[0];
        let product = arr2[1];
        let price = Number(arr2[2]);

        price = Number(price);

        if(result[product] === undefined){
            result[product] = {
                town: town,
                price: price
            }
        } else if(result[product].price > price){
            result[product].town = town;
            result[product].price = price;
        }
    }

    for(let value of Object.entries(result)){
        console.log(`${value[0]} -> ${value[1].price} (${value[1].town})`);
    }
}

lowest(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);