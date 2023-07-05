class Rectangle{
    constructor(wid, hei, col){
        this.width = wid;
        this.height = hei;
        this.color = col;
    }

    calcArea = () => {
        return this.width * this.height;
    }
}

let rect = new Rectangle(4, 5, 'Red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
