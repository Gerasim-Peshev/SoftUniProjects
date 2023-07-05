function solve(...params){

    let result = {};

    for(element of params){
        let eleType = typeof(element);
        console.log(`${eleType}: ${element}`);

        if(!result.hasOwnProperty(eleType)){
            result[eleType] = 0;
        }

        result[eleType] += 1;

    }

    let stringResult = '';
    for([key, val] of Object.entries(result)){
        stringResult += `${key} = ${val}\n`;
    }
    console.log(stringResult);
}

solve('cat', 42, function () { console.log('Hello world!'); });