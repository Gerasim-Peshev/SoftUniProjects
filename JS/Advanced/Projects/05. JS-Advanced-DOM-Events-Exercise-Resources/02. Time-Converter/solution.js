function attachEventsListeners() {

    let buttons = document.querySelectorAll('input[type = button]');

    for(let butt of buttons){
        butt.addEventListener('click', convert);
    }

    function convert(e){
        let firedButt = e.target.parentNode;
        
        let input = firedButt.querySelector('label').textContent[0];
        let inputNum = Number(firedButt.querySelector('input[type = text]').value);

        switch(input){
            case 'D':
                calc(inputNum);
                break;
            case 'H':
                calc(inputNum / 24);
                break;
            case 'M':
                calc(inputNum / 60 / 24);
                break;
            case 'S':
                calc(inputNum / 60 / 60 / 24);
                break;
        }
    }

    function calc(number){
        let areas = Array.from(document.querySelectorAll('input[type = text]'));

        areas[0].value = number;
        areas[1].value = number * 24;
        areas[2].value = number * 24 * 60;
        areas[3].value = number * 24 * 60 * 60;
    }
}