function solve(){
    return{
        fighter: function fighter(nameOfFighter){
        return {
            name: nameOfFighter,
            health: 100,
            stamina: 100,
            fight(){
                this.stamina--;
                console.log(`${this.name} slashes at the foe!`);
                }
            }
        },

        mage: function mage(nameOfMage){
        return {
            name: nameOfMage,
            health: 100,
            mana: 100,
            cast(spellName){
                this.mana--;
                console.log(`${this.name} cast ${spellName}`);
                }
            }
        }
    }
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);