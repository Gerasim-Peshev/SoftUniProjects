class List{

    sortedList;
    size;

    constructor(){
        this.sortedList = [];
        this.size = this.sortedList.length;
    }
    
    updateSort () {
        return this.sortedList.sort((a, b) => a - b);
    }

    add(num) {
        if(typeof num === 'number'){
            this.sortedList.push(num);
            this.sortedList = this.updateSort(this.sortedList);
            this.size++;
            return;
        }
    }

    remove(index) {
        if(typeof index === 'number' && index >= 0 && index < this.sortedList.length){
            delete this.sortedList[index];
            this.sortedList = this.updateSort();
            this.size--;
            return;
        }
    }

    get(index) {
        if(index >= 0 && index < this.sortedList.length){
            return this.sortedList[index];
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));

console.log(List.hasOwnProperty('add'));
