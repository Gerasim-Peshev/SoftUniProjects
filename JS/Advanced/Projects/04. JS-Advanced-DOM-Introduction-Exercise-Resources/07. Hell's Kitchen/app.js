function solve() {
   document.querySelector('body').addEventListener('click', onClick);
   
   function onClick () {
      
      const input = document.querySelector('#inputs textarea');
      const bestRestaurantArea = document.querySelector('#bestRestaurant p');
      const bestRestaurantWorkersArea = document.querySelector('#workers p');

      let arr = JSON.parse(input.value);

      let restaurants = [];

      for(let restaurant of arr){

         let restaurantName = restaurant.split(' - ')[0];
         let tempWorkers = restaurant.split(' - ')[1].split(', ');
         let workers = [];

         

         let res= restaurants.findIndex(x => x.restaurantName === restaurantName);
         for(let work of tempWorkers){
            let workerName = work.split(' ')[0];
            let workerSalery = Number(work.split(' ')[1]);
            workers.push({name: workerName, salary: workerSalery});
         }

         if(res === -1){

            restaurants.push({restaurantName, bestSalery: bestSalery(workers), 
            avgSalery: avgSalery(workers), workers})
         } else {
            for(worker of workers){
               restaurants[res].workers.push(worker);
            }

            restaurants[res].bestSalery = bestSalery(restaurants[res].workers);
            restaurants[res].avgSalery = avgSalery(restaurants[res].workers);
            console.log(`Avg Salery: ${restaurants[res].avgSalery}`);
            console.log(`Best Salety: ${restaurants[res].bestSalery}`);
         }


         function bestSalery(workers){
            let best = 0;
            for(let worker of workers){
               if(best < worker.salary){
                  best = worker.salary;
               }
            }

            return best;
         }

         function avgSalery(workers){
            let sum = 0;
            for(let worker of workers){
               sum += worker.salary;
            }

            return sum / workers.length;
         }
      }

      let bestRestaurant = restaurants.sort((a,b) => b.avgSalery - a.avgSalery)[0];

      
      bestRestaurantArea.textContent = `Name: ${bestRestaurant.restaurantName} Average Salary: ${bestRestaurant.avgSalery.toFixed(2)} Best Salary: ${bestRestaurant.bestSalery.toFixed(2)}`;

      let workersToString = '';
      for(let worker of bestRestaurant.workers.sort((a, b) => b.salary - a.salary)){
         workersToString += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }
      bestRestaurantWorkersArea.textContent = workersToString;
   }
}