function extract(content) {
    let text = document.getElementById(content).textContent;
    let patt = /\(([^)]+)\)/g;
    
    //debugger;

    let result = [];
    let matchCol = text.matchAll(patt);
    for(let match of matchCol){
        result.push(match[1]);
    }

    return result.join('; ');
}

//console.log(extract('The Rose Valley (Bulgaria) is located just south of the Balkan Mountains (Kazanlak).The most common oil-bearing rose found in the valley is the pink-petaled Damask rose (Rosa damascena Mill).'));