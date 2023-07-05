function solve2(arr){
    let first = Number(arr.shift());
    let last = Number(arr.pop());
    console.log(first + last);
}

solve2(['20', '30', '40']);
solve2(['5', '10']);