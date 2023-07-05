function solve(arr){

    return arr.sort().sort((a,b) => a.length - b.length).join('\n');
}

solve(['alpha', 'beta', 'gamma']);
solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
solve(['test', 'Deny', 'omen', 'Default']);