function calc() {
    let num1 = Number(document.getElementById("num1").value);
    let num2 = Number(document.getElementById("num2").value)
    let area = document.getElementById('sum');

    let sum = num1 + num2;

    //debugger;

    area.value = sum;
}
