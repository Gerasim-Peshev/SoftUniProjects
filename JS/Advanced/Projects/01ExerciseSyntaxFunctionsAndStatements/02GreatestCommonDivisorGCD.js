function GCD(firstNum, secondNum){
    let greater = firstNum > secondNum ? firstNum : secondNum;

    let greatestDivisor = 0;
    for (let i = 0; i < greater; i++){
        if(firstNum % i === 0 && secondNum % i === 0){
            greatestDivisor = i;
        }
    }

    console.log(greatestDivisor);
}

GCD(2154, 458)