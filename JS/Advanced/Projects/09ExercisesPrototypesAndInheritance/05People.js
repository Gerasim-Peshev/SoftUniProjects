function solution(){
    class Employee{
        constructor(name, age){
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }
        work = function() {
            console.log(this.tasks[0]);
            this.tasks.push(this.tasks.shift());
        }
        collectSalary = function(){
            let currSalary = this.dividend ? this.salary + this.dividend : this.salary;
            console.log(`${this.name} received ${currSalary} this month.`);
        }
    }

    class Junior extends Employee{
        constructor(name, age){
            super(name, age);
            super.tasks = [`${this.name} is working on a simple task.`];
        }

    }

    class Senior extends Employee{
        constructor(name, age){
            super(name,age);
            super.tasks = [`${this.name} is working on a complicated task.`, 
                           `${this.name} is taking time off work.`, 
                           `${this.name} is supervising junior workers.`];
        }

    }

    class Manager extends Employee{
        constructor(name, age){
            super(name, age)
            super.tasks = [`${this.name} scheduled a meeting.`, 
                           `${this.name} is preparing a quarterly report.`];
            this.dividend = 0;
        }
    }

    return {
        Employee: Employee,
        Junior: Junior,
        Senior: Senior,
        Manager: Manager
    }
}

const classes = solution (); 
const junior = new classes.Junior('Ivan',25); 
 
junior.work();  
junior.work();  
 
junior.salary = 5811; 
junior.collectSalary();  
 
const sinior = new classes.Senior('Alex', 31); 
 
sinior.work();  
sinior.work();  
sinior.work();  
sinior.work();  
 
sinior.salary = 12050; 
sinior.collectSalary();  
 
const manager = new classes.Manager('Tom', 55); 
 
manager.salary = 15000; 
manager.collectSalary();  
manager.dividend = 2500; 
manager.collectSalary();

console.log(manager.hasOwnProperty('dividend'));