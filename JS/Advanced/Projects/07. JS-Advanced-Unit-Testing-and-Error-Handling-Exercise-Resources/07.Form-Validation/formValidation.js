function validate() {
    let username = document.getElementById('username');
    let email = document.getElementById('email');
    let password = document.getElementById('password');
    let confirmPass = document.getElementById('confirm-password');
    let checkBox = document.getElementById('company');
    let companyInfo = document.getElementById('companyInfo');
    let companyNumber = document.getElementById('companyNumber');
    let submitButt = document.getElementById('submit');
    let validMess = document.getElementById('valid');


    let usernamePatern = /^([A-Za-z0-9]){3,20}$/gm;
    let passwordPatern = /^([a-z_]){5,15}$/gm;
    let emailPatern = /^(?<name>[a-z]+)\@(?<domain>[a-z]+)\.(?<extension>[a-z]+)$/gm;


    checkBox.addEventListener('change', unhideCompanyNum)
    submitButt.addEventListener('click', checkinfo);

    function unhideCompanyNum(e){
        let currStatus = companyInfo.style.display;

        currStatus === 'none' ? companyInfo.style.display = 'block' : companyInfo.style.display = 'none';
    }

    function checkinfo(e){
        e.preventDefault();

        let userCheck = true;
        let emailCheck = true;
        let passCheck = true;
        let confPassCheck = true;
        let companyNumCheck = true;

        
        if(username.value.match(usernamePatern)){
            userCheck = true;
            username.style.borderColor = '';
        } else {
            userCheck = false;
            username.style.borderColor = 'red';
        }

        if(email.value.match(emailPatern)){
            emailCheck = true;
            email.style.borderColor = '';
        } else {
            emailCheck = false;
            email.style.borderColor = 'red';
        }

        if(password.value.match(passwordPatern)){
            passCheck = true;
            password.style.borderColor = '';
        } else {
            passCheck = false;
            password.style.borderColor = 'red';
        }

        if(confirmPass.value.match(passwordPatern) && password.value === confirmPass.value){
            confPassCheck = true;
            confirmPass.style.borderColor = '';
        } else{
            confPassCheck = false;
            confirmPass.style.borderColor = 'red';
        }

        if(checkBox.checked){
            if(companyNumber.value >= 1000 && companyNumber.value <= 9999){
                companyNumCheck = true;
                companyNumber.style.borderColor = '';
            } else {
                companyNumCheck = false;
                companyNumber.style.borderColor = 'red';
            }
        } else {
            companyNumber.style.borderColor = '';
            companyNumber.value = '';
        }

        if(checkBox.checked){
            if(userCheck && emailCheck && passCheck && confPassCheck && companyNumCheck){
                validMess.style.display = 'block';
            } else {
                validMess.style.display = 'none';
            }
        } else {
            if(userCheck && emailCheck && passCheck && confPassCheck){
                validMess.style.display = 'block';
            } else {
                validMess.style.display = 'none';
            }
        }
    }

}
