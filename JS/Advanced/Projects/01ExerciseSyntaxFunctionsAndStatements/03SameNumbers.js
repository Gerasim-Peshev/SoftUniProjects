function numsChecker(num){
    let sum = 0;
    let check = true;
    let numAsString = String(num);
    let count = numAsString.length;

    let firstNum = numAsString[0];
    for(let i = 0; i < count; i++){
        if(numAsString[i] !== firstNum){
            check = false;
            break;
        }
    }

    for(let i = 0; i < count; i++){
        sum+=Number(numAsString[i]);
    }

    console.log(check);
    console.log(sum);
}

numsChecker(2222222)
numsChecker(1234)