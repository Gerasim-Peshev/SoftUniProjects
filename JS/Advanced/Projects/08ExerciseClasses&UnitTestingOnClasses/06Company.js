class Company {
    departments = {};
    
    addEmployee(name, salary, position, department){
        if(name === '' || name === undefined || name === null){
            throw Error('Invalid input!');
        }

        if(salary === '' || salary === undefined || salary === null){
            throw Error('Invalid input!');
        }

        if(position === '' || position === undefined || position === null){
            throw Error('Invalid input!');
        }

        if(department === '' || department === undefined || department === null){
            throw Error('Invalid input!');
        }

        if(salary < 0){
            throw Error('Invalid input!');
        }

        if(!this.departments.hasOwnProperty(department)){
            this.departments[department] = [];
        }
        this.departments[department].push({name, salary, position, department});
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){
        let best = {};

        let bestSal = 0;
        let bestAvgSal = 0;
        for(let dep of Object.entries(this.departments)){
            let summedSal = 0;
            for(let emp of dep[1]){
                summedSal += emp.salary;
            }

            let avg = summedSal / dep[1].length;
            if(avg > bestAvgSal){
                best = dep;
                bestSal = summedSal;
                bestAvgSal = avg;
            }
        }

        let sorted = best[1].sort((a, b) => (a.name > b.name) ? 1 : (a.name < b.name) ? -1 : 0);
        sorted = sorted.sort((a, b) => b.salary - a.salary);

        let srt = '';
        srt += `Best Department is: ${best[0]}\n` + `Average salary: ${bestAvgSal.toFixed(2)}\n`;

        for(let emplo of sorted){
            srt += `${emplo.name} ${emplo.salary} ${emplo.position}\n`;
        }

        return srt.slice(0, -1);
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");

console.log(c.bestDepartment());

