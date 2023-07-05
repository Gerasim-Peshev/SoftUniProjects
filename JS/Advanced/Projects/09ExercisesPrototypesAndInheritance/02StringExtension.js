function solve(){
    String.prototype.ensureStart = function(srt){
        let start = '';
        for(let i = 0; i < srt.length; i++){
            start += this[i];
        }

        if(srt === start){
            return this.toString();
        } else if(srt !== start){
            return (srt + this).toString();
        }
    };

    String.prototype.ensureEnd = function(srt){
        let end = '';
        for(let i = this.length - 1 - srt.length; i < this.length; i++){
            end += this[i];
        }

        if(srt === end){
            return this;
        } else if(srt !== end){
            return this + srt;
        }
    };

    String.prototype.isEmpty = function(){
        return this.length === 0 ? true : false;
    }

    String.prototype.truncate = function (n) {
        let result = '';
        if (this.length < n) {
            result = this;
        } else {
            let tokens = this.split(' ');
            if (tokens.length > 1) {
                result = trans(tokens, n);
            } else {
                if (n < 4) {
                    for (let i = 0; i < n; i++) {
                        result += '.';
                    }
                } else {
                    result = this.slice(0, n - 3);
                    result += '...';
                }
            }
        }
 
        function trans(tok, count) {
            let result = '';
 
            while(result.length < count){
                result += trans(result, count);
            }
            // if (result.length > count) {
            //     return;
            // }
 
 
            return result;
        }
 
        return result.toString();
    }
 
    String.format = function (string, ...params) {
        let regex = /{[0-9]}+/g;
        let match;
 
        for (let i = 0; i < params.length; i++) {
            match = regex.exec(string)
            if (match !== null) {
                break;
            } else {
                string = string.replace(match[0], params[i]);
            }
        }
 
        return string;
    }

    let str = 'my string';
    console.log(str = str.ensureStart('my'));
    console.log(str = str.ensureStart('hello '));
    console.log(str = str.truncate(16));
    console.log(str = str.truncate(14));
    console.log(str = str.truncate(8));
    console.log(str = str.truncate(4));
    console.log(str = str.truncate(2));
    str = String.format('The {0} {1} fox',
    'quick', 'brown');
    str = String.format('jumps {0} {1}',
    'dog');

}

solve()