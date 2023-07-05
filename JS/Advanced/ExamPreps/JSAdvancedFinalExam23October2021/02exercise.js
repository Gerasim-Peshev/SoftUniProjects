class SummerCamp {
    constructor(organizer, location){
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp =  {"child": 150, "student": 300, "collegian": 500};
        this.listOfParticipants = []; 
    }

    registerParticipant(name, condorion, money){

        if(condorion !== 'child' && condorion !== 'student' && condorion !== 'collegian'){
            throw new Error('Unsuccessful registration at the camp.');
        }

        let findParticipant = this.listOfParticipants.find(x => x.name === name);
        if(findParticipant){
            return `The ${name} is already registered at the camp.`;
        }

        if(money < this.priceForTheCamp[condorion]){
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({name, condorion, power: 100, wins: 0});
        return `The ${name} was successfully registered.`
    }

    unregisterParticipant(name){

        let findParticipant = this.listOfParticipants.find(x => x.name === name);
        if(!findParticipant){
            throw new Error(`The ${name} is not registered in the camp.`);
        } else {
            this.listOfParticipants = this.listOfParticipants.filter(x => x !== findParticipant);
            return `The ${name} removed successfully.`;
        }
    }

    timeToPlay(...params){
        
        let typeOfGame = '';
        let first = undefined;
        let second = undefined;
        if(params.length == 2){
            typeOfGame = params[0];
            first = this.listOfParticipants.find(x => x.name === params[1]);
            if(!first){
                throw new Error('Invalid entered name/s.')
            }
        } else if (params.length === 3){
            typeOfGame = params[0];
            first = this.listOfParticipants.find(x => x.name === params[1]);
            second = this.listOfParticipants.find(x => x.name === params[2]);
            if(!first || !second){
                throw new Error('Invalid entered name/s.')
            }
        }
        
        if (typeOfGame === 'WaterBalloonFights'){
            
            if (first.condorion !== second.condorion){
                throw new Error('Choose players with equal condition.');
            }

            if(first.power > second.power){
                first.wins += 1;
                return `The ${first.name} is winner in the game ${typeOfGame}.`;
            } else if(second > first){
                second.wins += 1;
                return `The ${second.name} is winner in the game ${typeOfGame}.`;
            } else {
                return `There is no winner.`;
            }
        } else if (typeOfGame === 'Battleship'){

            first.power += 20;
            return `The ${first.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString(){
        
        let srtToRet = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        this.listOfParticipants = this.listOfParticipants.sort((a, b) => b.wins - a.wins);

        for(let part of this.listOfParticipants){
            srtToRet += `${part.name} - ${part.condorion} - ${part.power} - ${part.wins}\n`;
        }

        return srtToRet.trimEnd();
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());







