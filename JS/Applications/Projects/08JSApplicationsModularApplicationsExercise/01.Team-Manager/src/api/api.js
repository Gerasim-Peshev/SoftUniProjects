const host = 'http://localhost:3030';

async function request(url, options){
    try{
        const response = await fetch(host + url, options);
        if(response.ok === false){
            const err = await response.json();
            throw new Error(err.message);
        }
        try{

            if(response.status === 204){
                return response;
            }

            const data = await response.json();
            return data;
        } catch(err){
            alert(err.message);
            throw err;
        } 
        
    } catch(err){
        alert(err.message);
        throw err;
    }
}

function getOptions(method, body){
    const options = {
        method,
        headers: {}
    };

    const user = JSON.parse(sessionStorage.getItem('userData'));

    if(user){
        const token = user.accessToken;
        options.headers['X-Authorization'] = token;
    }

    if(body){
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url){
    return await request(url, getOptions('GET'));
}

export async function post(url, data){
    return await request(url, getOptions('POST', data));
}

export async function put(url, data){
    return await request(url, getOptions('PUT', data));
}

export async function del(url){
    return await request(url, getOptions('DELETE'));
}