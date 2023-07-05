import {del, get, post, put} from './api.js'

export async function getAllCatalogData(){

    const data = await get('/data/albums?sortBy=_createdOn%20desc&distinct=name');

    return data;
}

export async function getCatalogElementDetails(id){

    const data = await get('/data/albums/' + id);

    return data;
}