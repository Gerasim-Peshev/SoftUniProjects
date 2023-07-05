class SmartHike{
    constructor(username){
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100; 
    }

    addGoal(peak, altitude){
        let goalToFind = this.goals[peak];

        if(goalToFind){
            return `${peak} has already been added to your goals`;
        }

        this.goals[peak] = altitude;
        return `You have successfully added a new goal - ${peak}`;
    }

    hike(peak, time, difficultyLevel){
        let goalToFind = this.goals[peak];

        if(!goalToFind){
            throw new Error(`${peak} is not in your current goals`);
        }

        if(this.resources === 0){
            throw new Error("You don't have enough resources to start the hike");
        }

        if(this.resources - time * 10 < 0){
            return "You don't have enough resources to complete the hike";
        }

        this.resources -= time * 10;
        this.listOfHikes.push({peak: peak, time: time, difficultyLevel: difficultyLevel});

        return`You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    rest(time){
        this.resources += time * 10;

        if(this.resources >= 100){
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`;
        }

        return `You have rested for ${time} hours and gained ${time * 10}% resources`;
    }

    showRecord(criteria){
        if(criteria === 'hard' || criteria === 'easy'){
            if(criteria === 'hard'){
                let hardArr = this.listOfHikes.filter(x => x.difficultyLevel === 'hard');
                if(hardArr.length === 0){
                    return `${this.username} has not done any ${criteria} hiking yet`;
                }

                let best = hardArr.sort((a, b) => a.time > b.time ? 1 : a.time < b.time ? -1 : 0)[0];

                return `${this.username}'s best ${criteria} hike is ${best.peak} peak, for ${best.time} hours`;
            } else if(criteria === 'easy'){
                let easyArr = this.listOfHikes.filter(x => x.difficultyLevel === 'easy');
                if(easyArr.length === 0){
                    return `${this.username} has not done any ${criteria} hiking yet`;
                }

                let best = easyArr.sort((a, b) => a.time > b.time ? 1 : a.time < b.time ? -1 : 0)[0];

                return `${this.username}'s best ${criteria} hike is ${best.peak} peak, for ${best.time} hours`;
            }
        } else if(criteria === 'all'){
            if(this.listOfHikes.length === 0){
                return `${this.username} has not done any ${criteria} hiking yet`;
            }

            let srtToRet = 'All hiking records:\n';

            for(let hike of this.listOfHikes){
                srtToRet += `${this.username} hiked ${hike.peak} for ${hike.time} hours\n`;
            }

            srtToRet = srtToRet.slice(0, srtToRet.length - 1);
            return srtToRet;
        }
    }
}

const user = new SmartHike('Vili');
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));




