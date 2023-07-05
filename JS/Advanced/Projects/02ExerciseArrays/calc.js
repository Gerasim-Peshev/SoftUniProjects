function solve(num){
    let count = 0;
    let secondNum = 0;

    // for(let i = 0; i < num; i++){
    //     for(let y = i; y > 0; y--){

    //     }
    // }

    let a = 1;
    while(true){
        if(secondNum === num){
            count++;
            break;
        } else{
            secondNum += a;
            a++;
            count++;
        }
    }

    console.log(count);
}

solve(28);
solve(1);
solve(3);
solve(10);
solve(6);
solve(21);
solve(15)
solve(10)