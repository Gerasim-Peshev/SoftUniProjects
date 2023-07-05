async function getInfo() {
    let stopID = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');
    let busesList = document.getElementById('buses');
    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopID.value}`;

    try{

        let response = await fetch(url);

        if(response.status !== 200){
            throw new Error();
        }

        let data = await response.json();

        stopName.textContent = data.name;

        busesList.replaceChildren();

        for(let elem of Object.entries(data.buses)){
            let liToAdd = document.createElement('li');
            liToAdd.textContent = `Bus ${elem[0]} arrives in ${elem[1]} minutes`;

            busesList.appendChild(liToAdd);
        }

    } catch (err){
        let stopName = document.getElementById('stopName');
        stopName.textContent = 'Error';
        
        let busesList = document.getElementById('buses');
        busesList.replaceChildren();
    }
}