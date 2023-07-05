(function solve(){
    Array.prototype.last = function() {
        return this[this.length - 1];
    };

    Array.prototype.skip = function(n){
        if(n >= 0 && n < this.length){
        let resultArr = [];

        for(let i = n; i < this.length; i++){
            resultArr.push(this[i]);
        }

        return resultArr;
        } else {
            throw Error();
        }
    };

    Array.prototype.take = function(n){
        if(n >= 0 && n < this.length){
            let resultArr = [];

            for(let i = 0; i < n; i++){
               resultArr.push(this[i]);
            }

            return resultArr;
        } else {
            throw Error();
        }
    };

    Array.prototype.sum = function(){
        let sum = 0;
        for(let i of this){
            sum += i;
        }
        return sum;
    }

    Array.prototype.average = function(){
        let sumAvg = 0;
        for(let i of this){
            sumAvg += i;
        }
        sumAvg /= this.length;
        return sumAvg;
    };

    // let arr = [1, 2, 3, 4];
    // console.log(Array.prototype.hasOwnProperty('last'));
    // console.log(arr.hasOwnProperty('last'));
})()

solve()