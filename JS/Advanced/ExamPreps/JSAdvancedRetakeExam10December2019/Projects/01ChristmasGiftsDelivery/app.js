function solution() {
    document.getElementsByTagName('button')[0].addEventListener('click', addgift);
    let giftName = document.getElementsByTagName('input')[0];
    let listOfGifts = document.getElementsByTagName('ul')[0];
    let sentGifts = document.getElementsByTagName('ul')[1];
    let discardedGifts = document.getElementsByTagName('ul')[2];


    function addgift(e){
        let liToAdd = document.createElement('li');
        liToAdd.textContent = giftName.value;
        liToAdd.classList.add('gift');
    
        let sentButton = document.createElement('button');
        let discardButton = document.createElement('button');
    
        sentButton.addEventListener('click', sentGift);
        discardButton.addEventListener('click', discardGift);
    
        sentButton.id = 'sendButton';
        discardButton.id = 'discardButton';
    
        sentButton.textContent = 'Send';
        discardButton.textContent = 'Discard';
    
        liToAdd.appendChild(sentButton);
        liToAdd.appendChild(discardButton);
    
        listOfGifts.appendChild(liToAdd);
    
        //listOfGifts = listOfGifts.sort((a, b) => a.textContent > b.textContent ? 1 : a.textContent < b.textContent ? -1 : 0);
    }
    
    function sentGift(e){
        let button = e.target;
    }
    
    function discardGift(e){
        let button = e.target;
    }

}
