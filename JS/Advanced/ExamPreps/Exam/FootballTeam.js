class footballTeam {
    constructor(clubName, country){
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = []; 
    }

    newAdditions(footballPlayers){
        let srtToRet = 'You successfully invite ';

        for(let player of footballPlayers){
            let line = player.split('/');
            let name = line[0];
            let age = Number(line[1]);
            let playerValue = Number(line[2]);

            let playerToFind = this.invitedPlayers.find(x => x.name === name);

            if(playerToFind){
                if(playerToFind.playerValue < playerValue){
                    playerToFind.playerValue = playerValue;
                }
            } else {
                this.invitedPlayers.push({name: name, age: age, playerValue: playerValue});
                srtToRet += `${name}, `;
            }
        }

        srtToRet = srtToRet.slice(0, srtToRet.length - 2);
        return srtToRet + '.';
    }

    signContract(selectedPlayer){
        let line = selectedPlayer.split('/');
        let name = line[0];
        let playerOffer = Number(line[1]);

        let playerToFind = this.invitedPlayers.find(x => x.name === name);

        if(!playerToFind){
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if(playerOffer < playerToFind.playerValue){
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${playerToFind.playerValue - playerOffer} million more are needed to sign the contract!`);
        }

        playerToFind.playerValue = 'Bought';

        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age){

        let playerToFind = this.invitedPlayers.find(x => x.name === name);

        if(!playerToFind){
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if(playerToFind.age >= age){
            return `${name} is above age limit!`;
        }

        let ageDifference = age - playerToFind.age;
        if(ageDifference < 5){
            return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
        }
        
        if(ageDifference > 5){
            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        }
    }

    transferWindowResult(){
        let srtToRet = "Players list:\n";

        let arrSorted = this.invitedPlayers.sort((a, b) => a.name > b.name ? 1 : a.name < b.name ? -1 : 0);
        for(let player of arrSorted){
            srtToRet += `Player ${player.name}-${player.playerValue}\n`;
        }

        srtToRet = srtToRet.slice(0, srtToRet.length - 1);
        return srtToRet;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());



