function solve() {
    document.getElementById('add-worker').addEventListener('click', higherWorker);

    let firstName = document.getElementById('fname');
    let lastName = document.getElementById('lname');
    let email = document.getElementById('email');
    let birth = document.getElementById('birth');
    let position = document.getElementById('position');
    let salary = document.getElementById('salary');
    let budget = document.getElementById('sum');

    let tableToAdd = document.getElementById('tbody');

    function higherWorker(e){
        e.preventDefault();

        if(!firstName.value || !lastName.value || !email.value || !birth.value || !position.value || !salary.value){
            return;
        } else {
            let trToAdd = document.createElement('tr');

            let tdFName = document.createElement('td');
            tdFName.textContent = firstName.value;

            let tdLName = document.createElement('td');
            tdLName.textContent = lastName.value;

            let tdEmail = document.createElement('td');
            tdEmail.textContent = email.value;

            let tdBirth = document.createElement('td');
            tdBirth.textContent = birth.value;

            let tdPosition = document.createElement('td');
            tdPosition.textContent = position.value;

            let tdSalary = document.createElement('td');
            tdSalary.textContent = salary.value;
            
            let firedButt = document.createElement('button');
            firedButt.classList.add('fired');
            firedButt.addEventListener('click', firePerson);
            firedButt.textContent = 'Fired';

            let editButt = document.createElement('button');
            editButt.classList.add('edit');
            editButt.addEventListener('click', editPerson);
            editButt.textContent = 'Edit';

            
            let tempBudg = Number(budget.textContent) + Number(salary.value);
            budget.textContent = tempBudg.toFixed(2);

            let tdButts = document.createElement('td');

            tdButts.appendChild(firedButt);
            tdButts.appendChild(editButt);

            //trToAdd.innerHTML = `<td>${firstName.value}</td>\n<td>${lastName.value}</td>\n<td>${email.value}</td>\n<td>${birth.value}</td>\n<td>${position.value}</td>\n<td>${salary.value}</td>`;
            trToAdd.appendChild(tdFName);
            trToAdd.appendChild(tdLName);
            trToAdd.appendChild(tdEmail);
            trToAdd.appendChild(tdBirth);
            trToAdd.appendChild(tdPosition);
            trToAdd.appendChild(tdSalary);
            trToAdd.appendChild(tdButts);

            tableToAdd.appendChild(trToAdd);

            firstName.value = '';
            lastName.value = '';
            email.value = '';
            birth.value = '';
            position.value = '';
            salary.value = '';
        }
    }

    function firePerson(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;

        
        budget.textContent = (Number(budget.textContent) - Number(ultimateParent.children[5].textContent)).toFixed(2);
        ultimateParent.remove();
    }

    function editPerson(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;

        firstName.value = ultimateParent.children[0].textContent;
        lastName.value = ultimateParent.children[1].textContent;
        email.value = ultimateParent.children[2].textContent;
        birth.value = ultimateParent.children[3].textContent;
        position.value = ultimateParent.children[4].textContent;
        salary.value = ultimateParent.children[5].textContent;

        budget.textContent = (Number(budget.textContent) - Number(ultimateParent.children[5].textContent)).toFixed(2);
        ultimateParent.remove();
    }
}
solve()