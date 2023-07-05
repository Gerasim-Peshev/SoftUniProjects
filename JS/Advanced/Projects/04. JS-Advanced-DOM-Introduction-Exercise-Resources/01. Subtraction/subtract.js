function subtract() {
    let firstNum = Number(document.getElementById('firstNumber').value);
    let secondNum = Number(document.getElementById('secondNumber').value);
    let area = document.getElementById('result');

    area.textContent = String(firstNum - secondNum);

}