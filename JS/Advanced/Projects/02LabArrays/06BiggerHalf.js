function solve(arr){
    let half = Math.floor(arr.length / 2);
    
    let sortedArr = arr.sort((a,b) => a - b).slice(half);

    return sortedArr;
}

solve([4, 7, 2, 5]);
solve([3, 19, 14, 7, 2, 19, 6]);