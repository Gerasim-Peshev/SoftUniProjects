function solve(arr){
    let count = arr.length / 2;

    let smallToBig = arr.sort((a,b) => a - b);
    let bigToSmall = arr.sort((a,b) => a - b);
    let sortedArr = Array();

    for(let i = 0; i < count; i++){
        sortedArr.push(smallToBig.shift());
        sortedArr.push(bigToSmall.pop());
    }

    return sortedArr;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));