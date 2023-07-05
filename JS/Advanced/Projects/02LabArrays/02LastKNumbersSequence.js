function solve(n, k){
let arr = Array(n);
arr[0] = 1;

for (let i = 0; i < arr.length; i++){
    for(let y = 0; y <= k; y++){
        if(arr[i - y] !== undefined){
            arr[i] += arr[i - y];
        }
        else{
            break;
        }
    }
}

console.log(arr);
}



// solve(6,3);
// console.log();
// solve(8,2);

