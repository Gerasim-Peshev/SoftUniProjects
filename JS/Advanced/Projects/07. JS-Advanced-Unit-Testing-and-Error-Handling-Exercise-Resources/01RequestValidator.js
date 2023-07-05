function validator(obj){

    let validMethods = [`GET`, `POST`, `DELETE`, `CONNECT`];
    let uriValidatePath = /^[\w.]+$/g;
    let validVersions = [`HTTP/0.9`, `HTTP/1.0`, `HTTP/1.1`, `HTTP/2.0`];
    let unvalidChars = [`<`, `>`, `\\`, `&`, `'`, `"`];

    if(!obj.hasOwnProperty('method') || !validMethods.includes(obj.method)){
        throw Error('Invalid request header: Invalid Method');
    }

    if(!obj.hasOwnProperty('uri')){
        throw Error('Invalid request header: Invalid URI');        
    }

    if(obj.uri !== '*' && !obj.uri.match(uriValidatePath)){
        throw Error('Invalid request header: Invalid URI');
    }

    if(!obj.hasOwnProperty('version') || typeof(obj.version) !== 'string' || !validVersions.includes(obj.version)){
        throw Error('Invalid request header: Invalid Version');
    }

    if(!obj.hasOwnProperty('message')){
        throw Error('Invalid request header: Invalid Message');
    }

    for(let ch of obj.message){
        if(unvalidChars.includes(ch)){
            throw Error('Invalid request header: Invalid Message');
        }
    }

    return obj;
}

console.log(validator({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
}));