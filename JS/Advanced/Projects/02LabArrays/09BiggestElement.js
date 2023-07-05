function solve(arr){
    
    let biggestNum = Number.MIN_SAFE_INTEGER;

    for(let i = 0; i < arr.length; i++){
        for(let y = 0; y < arr[i].length; y++){
            if(biggestNum < arr[i][y]){
                biggestNum = arr[i][y];
            }
        }
    }

    console.log(biggestNum);
}

solve([[20, 50, 10],[8, 33, 145]]);
solve([[3, 5, 7, 12],[-1, 4, 33, 2],[8, 3, 0, 4]])