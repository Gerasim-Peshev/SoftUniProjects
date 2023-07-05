function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   
   function onClick() {
      
      let list = Array(document.querySelectorAll('tbody tr'));
      let searchedText = document.querySelector('input');
      for(let i = 0; i < list[0].length; i++){
         list[0][i].classList.remove('select');
      }


      if(searchedText.value !== ''){
         for(let i = 0; i < list[0].length; i++){
            let part = Array(list[0][i].children);

            for(let word of part[0]){
               if(word.textContent.includes(searchedText.value)){
                  list[0][i].className = 'select';
               }
            }
         }

         searchedText.value = '';
      }
   }
}