function solve(arr){
    let reducedArr = Array();
    let biggestNum = Number.MIN_SAFE_INTEGER;

    for(let i = 0; i < arr.length; i++){
        if(arr[i] >= biggestNum){
            biggestNum = arr[i];
            reducedArr.push(biggestNum);
        }
    }
    
    return reducedArr;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3,4]));
console.log(solve([20, 3, 2, 15,6, 1]));