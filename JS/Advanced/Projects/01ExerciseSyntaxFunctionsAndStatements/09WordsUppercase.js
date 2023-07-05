function Convertor(sentence){
    let regex = /\w+/g;
    let founded = sentence.match(regex);

    let sum = ``;

    for(let i = 0; i < founded.length; i++){
        if(i === founded.length - 1){
            sum += `${String(founded[i]).toUpperCase()}`
        }
        else{
            sum += `${String(founded[i]).toUpperCase()}, `
        }
    }

    console.log(sum);
}

Convertor('Hi, how are you?')