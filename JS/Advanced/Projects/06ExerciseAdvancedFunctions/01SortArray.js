function solve(inputNumbers, text){

    let numbers = Array.from(inputNumbers.map(x => Number(x)));

    if(text === 'asc'){
        return numbers.sort((a, b) => a - b);
    } else if('desc'){
        return numbers.sort((a, b) => b - a);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'desc'));