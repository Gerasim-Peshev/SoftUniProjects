function solve(arr){
let indexOfSmallest = arr.indexOf(Math.min(...arr));
let firstNum = arr.splice(indexOfSmallest, 1);
let indexOfSecond = arr.indexOf(Math.min(...arr));
let secondNum = arr.splice(indexOfSecond, 1);

console.log(`${firstNum} ${secondNum}`);
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);