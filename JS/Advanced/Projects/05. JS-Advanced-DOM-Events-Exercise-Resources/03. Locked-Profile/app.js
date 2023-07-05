function lockedProfile() {

    const buttons = [...document.getElementsByTagName('button')];
    
    for(let button of buttons){
        button.addEventListener('click', showOrHide);
    }

    function showOrHide(e){

        const butt = e.target;

        const profile = butt.parentNode;

        const hiddenDiv = profile.getElementsByTagName('div')[0];

        const locked = profile.querySelector('input[type="radio"]:checked').value;
        
        if(locked === 'unlock'){
            if(butt.textContent === 'Show more'){

                hiddenDiv.style.display = 'inline-block';

                butt.textContent = 'Hide it';

            } else if(butt.textContent === 'Hide it'){

                hiddenDiv.style.display = 'none';

                butt.textContent = 'Show more';
            }
        }
    }
}