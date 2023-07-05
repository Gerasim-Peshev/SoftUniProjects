function solution(){
    class Balloon {
        constructor(col, wei){
            this.color = col;
            this.hasWeight = wei;
        };
    };

    class PartyBalloon extends Balloon{
        constructor(col, wei, ribCol, rinLen){
            super(col, wei);
            this.ribbon = {};
            this.ribbon.color = ribCol;
            this.ribbon.length = rinLen;
        };
    };

    class BirthdayBalloon extends PartyBalloon {
        constructor(col, wei, ribCol, rinLen, tex){
            super(col, wei, ribCol, rinLen);
            this._text = tex;
        }

        get text() {return this._text;};
    };

    return {
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }
}

let classes = solution();
let testBalloon = new classes.Balloon("yellow", 20.5);
let testPartyBalloon = new classes.PartyBalloon("yellow", 20.5, "red", 10.25);
let testBirth = new classes.BirthdayBalloon("yellow", 20.5, "red", 10.25, 'qdene');
let textOfBall = testBirth.text;
let ribbon = testPartyBalloon.ribbon;
console.log(testBalloon);
console.log(testPartyBalloon);
console.log(ribbon);
console.log(textOfBall);

