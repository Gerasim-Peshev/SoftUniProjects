import { get, post } from "./api";
import { clearUserData, setUserData } from "./util";

export async function login(emailToUse, password){
    const {_id, email, accessToken} = await post('/users/login', {emailToUse, password});

    setUserData({
        _id,
        email,
        accessToken
    });
}

export async function register(emailToUse, password){
    const {_id, email, accessToken} = await post('/users/register', {emailToUse, password});

    setUserData({
        _id,
        email,
        accessToken
    });
}

export async function logout(){
    get('/users/logout');
    clearUserData();
}