function solve(arr){
    let firstSum = 0;
    let secondSum = 0;

    let thirdSum = 0;
    let forthSum = 0;

    let rowsCheck = true;
    let colsCheck = true;

    for(let y = 0; y < arr[0].length; y++){
        firstSum += arr[0][y];
    }

    if(arr.length > 0){
        for(let i = 1; i < arr.length; i++){
            secondSum = 0;
            for(let y = 0; y < arr[i].length; y++){
                secondSum += arr[i][y];
            }

            if(firstSum !== secondSum){
                rowsCheck = false;
                break;
            }
        }
    }

    for(let i = 0; i < arr.length; i++){
        thirdSum += arr[i][0];
    }

    for(let y = 1; y < arr[0].length; y++){
        forthSum = 0;
        for(let i = 0; i < arr.length; i++){
            forthSum += arr[i][y];
        }

        if(thirdSum !== forthSum){
            colsCheck = false;
            break;
        }
    }

    if(!colsCheck || !rowsCheck){
        console.log(false);
    } else if(colsCheck && rowsCheck){
        console.log(true);
    }
}

solve([[4, 5, 6],
       [6, 5, 4],
       [5, 5, 5]]);

solve([[11, 32, 45],
       [21, 0, 1],
       [21, 1, 1]]);

solve([[1, 0, 0],
       [0, 0, 1],
       [0, 1, 0]]);