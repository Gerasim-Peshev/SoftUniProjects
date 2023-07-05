function conver(arr){
    let firstCol = arr.shift().split(' | ');

    let result = [];

    for(let part of arr){
        let line = part.split(/[\s,]+/).filter(x => x !== '|');
    
        let longitudeOfPart = Math.round(Number(line.pop() * 100)) / 100;;
        let latitudeOfPart = Math.round(Number(line.pop() * 100)) / 100;;
        let count = -1;

        result.push({Town: line.join(' '), Latitude: latitudeOfPart, Longitude: longitudeOfPart})
    }

    console.log(JSON.stringify(result));
}

// console.log(Math.round((123.432 + Number.EPSILON) * 100) / 100);
// return;

conver(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);

conver(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);