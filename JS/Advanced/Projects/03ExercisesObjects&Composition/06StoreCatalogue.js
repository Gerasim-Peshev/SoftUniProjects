function catalog(books){
    let result = {
        letterStart: [{}], 
    };

    for(let book of books){
        let res = book.split(' : ');
        let productName = res[0];
        let priceOfProfuct = Number(res[1]);
        let firstLetter = productName[0].toUpperCase();

        if(result[firstLetter] === undefined){
            result[firstLetter].push({name: productName, price: priceOfProfuct});
        } else {
            result[firstLetter].push({name : productName, price: priceOfProfuct});
        }

        // if(result.letterStart.includes(productName[0].toUpperCase()) !== undefined){
        //     result.letterStart[productName[0].toUpperCase()].push({name: productName, price: priceOfProfuct});
        // } else if(!result.letterStart[productName[0].toUpperCase].includes()) {
        //     result.letterStart[productName[0].toUpperCase].push({name: productName, price: priceOfProfuct});
        // }
    }

    let keysOfObj = Object.keys(result);
    let valuesOfObj = Object.values(result).sort();

    for(let key of keysOfObj){
        console.log(key);
        for (let val of valuesOfObj[key]){
            console.log(val);
        }
    }
}

catalog(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);