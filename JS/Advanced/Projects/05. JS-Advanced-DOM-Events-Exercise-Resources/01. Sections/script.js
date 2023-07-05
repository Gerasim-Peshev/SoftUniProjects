function create(words) {
   
   let initialDiv = document.getElementById('content');

   for(let part of words){
      let divEle = document.createElement('div');
      let pEle = document.createElement('p');

      pEle.textContent = part;

      pEle.style.display = 'none';
      divEle.appendChild(pEle);
      divEle.addEventListener('click', () => {pEle.style.display = 'block'});
      initialDiv.appendChild(divEle);
   }
}