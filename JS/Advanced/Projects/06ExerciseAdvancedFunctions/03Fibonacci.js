function solve(){
    
    let firstNum = 0;
    let secondNum = 1;
    let result = 0;

    return function fibonacci(){
        result = firstNum + secondNum;
        firstNum = secondNum;
        secondNum = result;

        return firstNum;
    }
}

let fib = solve();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
