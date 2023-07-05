function search() {
   let butt = document.querySelector('button');
   let townsList = document.querySelectorAll('ul li');
   let searchedText = document.getElementById('searchText').value;
   let count = 0;

   for (let town of townsList){
      if(town.textContent.includes(searchedText)){
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         count++;
      } else {
         town.style.textDecoration = 'none';
         town.style.fontWeight = '';
      }
   }

   document.getElementById('result').innerText = `${count} matches found`;
}
