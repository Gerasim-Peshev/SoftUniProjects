import * as api from './api.js';


const endpoints = {
    'login': '/users/login',
    'register': '/users/register',
    'logout': '/users/logout',
    'getAllTeams': '/data/teams',
    'getAllMembers': '/data/members?where=status%3D%22member%22',
    'createTeam': '/data/teams',
    'teamDetails': '/data/teams/',
    'memberRequest': '/data/members'
};

export async function login(email, password){
    const res = await api.post(endpoints.login, {email, password});
    sessionStorage.setItem('userData', JSON.stringify(res));
    return res;
}

export async function register(email, username, password){
    const res = await api.post(endpoints.register, {email, password});
    sessionStorage.setItem('userData', JSON.stringify(res));
    return res;
}

export async function logout(){
    const res = await api.get(endpoints.logout);
    sessionStorage.removeItem('userData');
    return res;
}

export async function getAllTeams(){
    const res = await api.get(endpoints.getAllTeams);
    return res;
}

export async function getAllMembers(){
    const res = await api.get(endpoints.getAllMembers);
    return res;
}

export async function createTeam(name, imageUrl, description){
    const res = await api.post(endpoints.createTeam, {name, imageUrl, description});
    return res;
}

export async function getTeamDetails(id){
    const res = await api.get(endpoints.teamDetails + id);
    return res;
}

export async function updateTeamDetails(id, name, imageUrl, description){
    const res = await api.put(endpoints.teamDetails + id, {name, imageUrl, description});
    return res;
}

export async function requestMember(teamId){
    const res = await api.post(endpoints.memberRequest, {teamId});
    return res;
}