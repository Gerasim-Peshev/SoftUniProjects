class Stringer{
    innerString;
    innerLength;


    constructor(string, len){
        this.innerString = string;
        this.innerLength = len;
    }

    increase(length){
            this.innerLength += length;
    }

    decrease(length){
        this.innerLength -= length;
        if(this.innerLength <= 0){
            this.innerLength = 0;
        }
    }

    toString(){
        let tempStr = '';
        if(this.innerLength >= this.innerString.length){
            for (let i = 0; i < this.innerString.length; i++){
                tempStr += this.innerString[i];
            }
        } else {
            for(let i = 0; i < this.innerLength; i++){
                tempStr += this.innerString[i];
            }
            tempStr += '...';
        }

        return tempStr;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
