function factory(requirements){
    
    let engineEmum = (hp) => {
        if(hp <= 90){
            return {
                power: 90,
                volume: 1800
            };
        } else if(hp > 90 && hp <= 120){
            return {
                power: 120,
                volume: 2400
            };
        } else{
            return {
                power: 200,
                volume: 3500
            };
        }
    }   

    let whiles = requirements.wheelsize % 2 === 0 ? requirements.wheelsize - 1 : requirements.wheelsize;

    let wheels = Array(4).fill(whiles);
    
    let result = {
        model: requirements.model,
        engine: engineEmum(requirements.power),
        carriage: {
            type: requirements.carriage,
            color: requirements.color
        },
        wheels: wheels
    };

    return result;
}

console.log(factory({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));

console.log(factory({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
));