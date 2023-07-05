function Validator(first, second, third, forth){

    let firstCheck = Number.isInteger(Math.sqrt(((0-first)**2)+((0-second)**2)));

    let secondCheck = Number.isInteger(Math.sqrt(((0-third)**2)+((0-forth)**2)));

    let thirdCheck = Number.isInteger(Math.sqrt(((third-first)**2)+((forth-second)**2)));

    if(firstCheck === true){
       
        console.log(`{${first}, ${second}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${first}, ${second}} to {0, 0} is invalid`);
    }

    if(secondCheck === true){
       
        console.log(`{${third}, ${forth}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${third}, ${forth}} to {0, 0} is invalid`);
    }

    if(thirdCheck === true){
      
        console.log(`{${first}, ${second}} to {${third}, ${forth}} is valid`);
    }
    else{
        console.log(`{${third}, ${forth}} to {${third}, ${forth}} is invalid`);
    }
}

Validator(2, 1, 1, 1)


Math.sqrt(((0-1)**2)+((0-1)**2))