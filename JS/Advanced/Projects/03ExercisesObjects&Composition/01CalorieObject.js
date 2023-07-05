function solve(products){
    let result = {};

    for(let i = 0; i < products.length; i+=2){
        let productName = products[i];
        let calorie = Number(products[i+1]);

        result[productName] = calorie;
    }

    console.log(result);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);