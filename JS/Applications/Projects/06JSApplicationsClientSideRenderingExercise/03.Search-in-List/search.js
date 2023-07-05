import { html, render } from "./node_modules/lit-html/lit-html.js";
import {towns} from "./towns.js";

(function search() {

   let root = document.getElementById('towns');

const allTowns = (towns) => html
`
    <ul>
      ${towns.map(createTown)}
    </ul>
`;

const createTown = (town) => html`
<li>${town}</li>
`;

//debugger;
render(allTowns(towns), root);
   
   document.querySelector('button').addEventListener('click', searchResults)

   let searchText = document.getElementById('searchText');
   let resultArea = document.getElementById('result');

   function searchResults(e){
      e.preventDefault();

      //debugger;
      let allTowns = document.getElementById('towns').children[0].children;

      let count = 0;
      if(searchText.value === ''){

         for(let town of allTowns){
               town.className = '';
         }

         resultArea.textContent = `${count} matches found`;
         searchText.value = '';
         return;
      }

      for(let town of allTowns){

         if(town.textContent.includes(searchText.value)){
            town.className = 'active';
            count++;
         } else {
            town.className = '';
         }
      }

      resultArea.textContent = `${count} matches found`;
      searchText.value = '';
   }
})()


