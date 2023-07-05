function solve(arrOfJuice){
    let jucesToStore = {};
    let bottelsOfJuice = {};

    for(let juice of arrOfJuice){
        let line = juice.split(' => ');

        if(jucesToStore[line[0]] === undefined){
            jucesToStore[line[0]] = Number(line[1]);
        } else {
            jucesToStore[line[0]] += Number(line[1]);
        }

        if(jucesToStore[line[0]] >= 1000){
            if(bottelsOfJuice[line[0]] === undefined){
                let num1 = Math.floor(Number((jucesToStore[line[0]] / 1000)));
                bottelsOfJuice[line[0]] = num1;
            } else {
                let num2 = Math.floor(Number((jucesToStore[line[0]] / 1000)));
                bottelsOfJuice[line[0]] += num2;
            }

            jucesToStore[line[0]] -= Math.floor(Number(jucesToStore[line[0]] / 1000)) * 1000;
        }
    }

    for(let bottle of Object.entries(bottelsOfJuice)){
        let key = bottle[0];
        let val = bottle[1];
        console.log(`${key} => ${val}`);
    }
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);