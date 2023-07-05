function rectangle(width, height, colorOfRec){
    let res = String(colorOfRec)[0].toUpperCase();
    
    return {
        width: Number(width),
        height: Number(height),
        color: res + String(colorOfRec).substring(1),
        calcArea(){
            return width * height;
        }
    };
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
