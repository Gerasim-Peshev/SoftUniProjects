class Request{
    constructor(meth, ur, vers, mess){
        this.method = meth;
        this.uri = ur;
        this.version = vers;
        this.message = mess;
    }

    response = undefined
    fulfilled = false
}

let myData = new Request('GET', 'http://google.com', 'HTTP/1.1', '')
console.log(myData);
