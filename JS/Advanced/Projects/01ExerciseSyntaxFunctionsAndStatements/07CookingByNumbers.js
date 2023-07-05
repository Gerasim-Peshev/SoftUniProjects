function Cooker(number, first, second, third, forth, fifth){
    let num = Number(number);
    let arr = new Array(first,second,third,forth,fifth);

    for(let i = 0; i < arr.length; i++){
        if(arr[i] === `chop`){
            num /= 2;
        }
        else if(arr[i] === `dice`){
            num = Math.sqrt(num);
        }
        else if(arr[i] === `spice`){
            num+=1;
        }
        else if(arr[i] === `bake`){
            num*=3;
        }
        else if(arr[i] === `fillet`){
            num-=(num*0.2);
        }

        console.log(num);
    }
}

Cooker('9', 'dice', 'spice', 'chop', 'bake', 'fillet')