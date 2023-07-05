function solve(arr){
    let count = 0;

    for(let i = 0; i < arr.length; i++){
        for(let y = 0; y < arr[i].length; y++){
            if(arr[i][y] === arr[i][y+1]){
                count++;
            }
            if(i != arr.length - 1 && arr[i][y] === arr[i+1][y]){
                count++;
            }
        }
    }

    return count;
}

console.log(solve([[2, 2, 5, 7, 4],
                   [4, 0, 5, 3, 4],
                   [2, 5, 5, 4, 2]]));

console.log(solve([['2', '3', '4', '7', '0'],
                   ['4', '0', '5', '3', '4'],
                   ['2', '3', '5', '4', '2'],
                   ['9', '8', '7', '5', '4']]));

console.log(solve([['test', 'yes', 'yo', 'ho'],
                   ['well', 'done', 'yo', '6'],
                   ['not', 'done', 'yet', '5']]));
