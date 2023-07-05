function solve(arr){
    let sortedArr = new Array();

    for (num of arr){
        if(num < 0){
            sortedArr.unshift(num);
        } else if (num >= 0){
            sortedArr.push(num);
        }
    }

    console.log(sortedArr.join('\n'));
}

//solve([7, -2, 8, 9]);

solve([3, -2, 0, -1])