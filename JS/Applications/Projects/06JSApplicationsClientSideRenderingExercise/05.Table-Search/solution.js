import {html, render} from './node_modules/lit-html/lit-html.js';

(async function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let root = document.querySelector('tbody');

   let data = await getData();

   const tableTemplate = (dataToUse) => html`
      <tr>
          <td>${dataToUse[1].firstName} ${dataToUse[1].lastName}</td>
          <td>${dataToUse[1].email}</td>
          <td>${dataToUse[1].course}</td>
      </tr>
   `;

   //debugger;
   render(Object.entries(data).map(tableTemplate), root);
   
   function onClick(e) {
      e.preventDefault();

      //debugger;
      let textToSearch = document.getElementById('searchField');
      let children = root.children;

      if(textToSearch.value === ''){
         for(let child of children){
            child.classList.remove('select'); 
         }
         return;
      }


      //debugger;
      for(let child of children){
         for(let ch of child.children){
            if(ch.textContent.toLowerCase().includes(textToSearch.value.toLowerCase())){
               child.classList.add('select');
               break;
            } else {
               child.classList.remove('select');
            }
         }
      }
      textToSearch.value = '';
   }
})()

async function getData(){
   let response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   let data = await response.json();

   return data;
}