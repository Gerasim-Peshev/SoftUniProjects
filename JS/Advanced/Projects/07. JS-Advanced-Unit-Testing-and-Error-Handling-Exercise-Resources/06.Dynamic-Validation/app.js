function validate() {
    let inputArea = document.getElementById('email');

    let matchPatern = /(?<name>[a-z]+)\@(?<domain>[a-z]+)\.(?<extension>[a-z]+)/gm;

    inputArea.addEventListener('change', checkMail);

    function checkMail(e){
        let area = e.target;

        if(!area.value.match(matchPatern)){
            inputArea.className = 'error';
        } else {
            inputArea.className = '';
        }
    }
}