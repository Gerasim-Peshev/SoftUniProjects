async function attachEvents() {
    
    //debugger;
    document.getElementById('submit').addEventListener('click', createForecast);

    async function createForecast(){

        //debugger;

        let location = checkCity(document.getElementById('location').value);



        let currUrl = `http://localhost:3030/jsonstore/forecaster/today/${location}`;
        let upcommingUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${location}`;
        
        let forecastList = document.getElementById('forecast');
        let currForecastDiv = document.getElementById('current');
        let upcomingForecastDiv = document.getElementById('upcoming');

        try{

            //debugger;
            let responseCurr = await fetch(currUrl);
            let responseUpcom = await fetch(upcommingUrl);

            if(responseCurr.status !== 200 || responseUpcom.status !== 200){
                throw new Error();
            }

            let curData = await responseCurr.json();
            let upcomData = await responseUpcom.json();

            let divToStayInCurr = document.createElement('div');
            divToStayInCurr.className = 'label';
            divToStayInCurr.textContent = 'Current conditions';


            let divToStayInUpcom = document.createElement('div');
            divToStayInUpcom.className = 'label';
            divToStayInUpcom.textContent = 'Three-day forecast';


            currForecastDiv.replaceChildren(divToStayInCurr);
            upcomingForecastDiv.replaceChildren(divToStayInUpcom);

            createCurrent(curData);
            //debugger;
            createUpcoming(upcomData);

            forecastList.style.display = 'block';
        } catch (err){
            forecastList.textContent = 'Error'
            forecastList.style.display = 'block';
        }


        function checkWeather(weather){
            if(weather === 'Sunny'){
                return '&#x2600';
            } else if (weather === 'Partly sunny'){
                return '&#x26C5';
            } else if (weather === 'Overcast'){
                return '&#x2601';
            } else if (weather === 'Rain'){
                return '&#x2614';
            } else if (weather === 'Degrees'){
                return '&#176';
            }
        }

        function checkCity(city){
            if(city === 'New York' || city === 'new york'){
                return 'ny';
            } else if (city === 'London' || city === 'london'){
                return 'london';
            } else if (city === 'Barcelona' || city === 'barcelona'){
                return 'barcelona';
            } else {
                throw new Error();
            }
        }

        async function createCurrent(curData){
            let divForecasts = document.createElement('div');
            divForecasts.className = 'forecasts';

            let spanSymbol = document.createElement('span');
            spanSymbol.className = 'condition symbol';
            spanSymbol.innerHTML = checkWeather(curData.forecast.condition);

            let spanCurr = document.createElement('span');
            spanCurr.className = 'condition';

            let spanCity = document.createElement('span');
            spanCity.className = 'forecast-data';
            spanCity.textContent = curData.name;

            let spanTemp = document.createElement('span');
            spanTemp.className = 'forecast-data';
            spanTemp.innerHTML = `${curData.forecast.low}${checkWeather('Degrees')}\/${curData.forecast.high}${checkWeather('Degrees')}`;

            let spanCondition = document.createElement('span');
            spanCondition.className = 'forecast-data';
            spanCondition.textContent = curData.forecast.condition;

            spanCurr.appendChild(spanCity);
            spanCurr.appendChild(spanTemp);
            spanCurr.appendChild(spanCondition);

            divForecasts.appendChild(spanSymbol);
            divForecasts.appendChild(spanCurr);

            currForecastDiv.appendChild(divForecasts);
        }

        async function createUpcoming(upcomData){
            let divForecastInfo = document.createElement('div');
            divForecastInfo.className = 'forecast-info';

            for(let forecast of upcomData.forecast){
                let spanUpcome = document.createElement('span');
                spanUpcome.className = 'upcoming';

                let spanSymbol = document.createElement('span');
                spanSymbol.className = 'symbol';
                spanSymbol.innerHTML = checkWeather(forecast.condition);

                let spanTemp = document.createElement('span');
                spanTemp.className = 'forecast-data';
                spanTemp.innerHTML = `${forecast.low}${checkWeather('Degrees')}\/${forecast.high}${checkWeather('Degrees')}`;

                let spanCondition = document.createElement('span');
                spanCondition.className = 'forecast-data';
                spanCondition.textContent = forecast.condition;

                spanUpcome.appendChild(spanSymbol);
                spanUpcome.appendChild(spanTemp);
                spanUpcome.appendChild(spanCondition);

                divForecastInfo.appendChild(spanUpcome);
            }

            upcomingForecastDiv.appendChild(divForecastInfo);
        }
    }
}

attachEvents();