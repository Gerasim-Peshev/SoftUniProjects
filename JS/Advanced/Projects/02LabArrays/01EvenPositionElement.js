function solve(arr){
    let filteredArr = arr.filter((x, i) => i % 2 == 0);
    console.log(filteredArr.join(' '));
}

solve(['20', '30', '40', '50', '60'])