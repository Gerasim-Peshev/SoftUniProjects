function solve(arr){
    let num = 1;
    let secondArr = Array();

    for(let i = 0; i < arr.length; i++){
        if(arr[i] === 'add'){
            secondArr.push(num);
            num++;
        } else if(arr[i] === 'remove'){
            secondArr.pop();
            num++;
        }
    }

    if(secondArr.length === 0){
        console.log('Empty');
    } else {
        console.log(secondArr.join('\n'));
    }
}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);