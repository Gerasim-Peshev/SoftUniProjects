function solve(arr, firstFlavor, secondFlavor){
    
    let res = arr.slice(arr.indexOf(firstFlavor), arr.indexOf(secondFlavor) + 1);
    
    return res;
}

console.log(solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));
