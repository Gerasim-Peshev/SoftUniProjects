function createAssemblyLine(){
    return {
        hasClima(car){
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {
                if (car.temp < car.tempSettings){
                    car.temp++;
                } else if (car.temp > car.tempSettings){
                    car.temp--;
                }
            }
        },
        hasAudio(car){
            car.currentTrack = {name: null, artist: null};
            car.nowPlaying = () => {
                if(car.currentTrack.name !== null && car.currentTrack.artist !== null){
                console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`);
                }
            }
        },
        hasParktronic(car){
            car.checkDistance = (distance) => {
                let dis = Number(distance);

                if(dis < 0.1){
                    console.log('Beep! Beep! Beep!');
                } else if(dis >= 0.1 && dis < 0.25){
                    console.log(`Beep! Beep!`);
                } else if(dis >= 0.25 && dis < 0.5){
                    console.log(`Beep!`);
                } else{
                    console.log(``);
                }
            }
        }
    };
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);