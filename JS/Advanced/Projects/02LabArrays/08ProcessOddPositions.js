function solve(arr){
    let filteredArr = Array();

    for(let i = 0; i < arr.length; i++){
         
        if (i % 2 !== 0){
            filteredArr.push(arr[i]);
        }
    }

    return filteredArr.map(x => x * 2).reverse();
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]))

console.log(5 % 2 !== 0);