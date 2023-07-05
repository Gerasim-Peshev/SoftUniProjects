function calculator() {
    
    let selector1;
    let selector2;
    let resultSelector;

    let calcer = {
        init: (firstSelector, secondSelector, resSelector) => {
            selector1 = document.querySelector(firstSelector);
            selector2 = document.querySelector(secondSelector);
            resultSelector = document.querySelector(resSelector);
        },
        add: () => {
            let firstNum = Number(selector1.value);
            let secondNum = Number(selector2.value);
            let sum = firstNum + secondNum;
            resultSelector.value = sum;
        },
        subtract: () => {
            let firstNum = Number(selector1.value);
            let secondNum = Number(selector2.value);
            let sum = firstNum - secondNum;
            resultSelector.value = sum;
        }
    }

    return calcer;
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 