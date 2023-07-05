function solve(arr){
    let firstIndex = 0;
    let secondIndex = arr[0].length - 1;
    let firstSum = 0;
    let secondSum = 0;

    for(let i = 0; i < arr.length; i++){
        firstSum+=arr[i][firstIndex];
        secondSum+=arr[i][secondIndex];

        firstIndex++;
        secondIndex--;
    }

    console.log(`${firstSum} ${secondSum}`);
}

solve([[20, 40],
       [10, 60]]);

solve([[3, 5, 17],
       [-1, 7, 14],
       [1, -8, 89]]);