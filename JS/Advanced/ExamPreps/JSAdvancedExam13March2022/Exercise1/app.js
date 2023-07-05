function solve() {
    document.querySelectorAll('button')[0].addEventListener('click', addToList);
    document.querySelectorAll('button')[1].addEventListener('click', resetFields);

    let recipientName = document.getElementById('recipientName');
    let title = document.getElementById('title');
    let message = document.getElementById('message');

    let ulOfMail = document.getElementById('list');
    let ulSentMails = document.querySelectorAll('ul')[1];
    let deletedMails = document.querySelectorAll('ul')[2];

    function addToList(e){
        e.preventDefault();

        //debugger
        if(!recipientName.value || !title.value || !message.value){
            return;
        } else {

            let liToAdd = document.createElement('li');

            let h4Title = document.createElement('h4');
            h4Title.textContent = `Title: ${title.value}`;

            let h4RecipientName = document.createElement('h4');
            h4RecipientName.textContent = `Recipient Name: ${recipientName.value}`;

            let spanMessage = document.createElement('span');
            spanMessage.textContent = message.value;

            let divButts = document.createElement('div');
            divButts.id = 'list-action';

            let sendButt = document.createElement('button');
            sendButt.type = 'submit';
            sendButt.id = 'send';
            sendButt.textContent = 'Send';
            sendButt.addEventListener('click', sendMail);

            let deleteButt = document.createElement('button');
            deleteButt.type = 'submit';
            deleteButt.id = 'delete';
            deleteButt.textContent = 'Delete';
            deleteButt.addEventListener('click', deleteMail);

            divButts.appendChild(sendButt);
            divButts.appendChild(deleteButt);

            liToAdd.appendChild(h4Title);
            liToAdd.appendChild(h4RecipientName);
            liToAdd.appendChild(spanMessage);
            liToAdd.appendChild(divButts);

            ulOfMail.appendChild(liToAdd);

            recipientName.value = '';
            title.value = '';
            message.value = '';
        }
    }

    function resetFields(e){
        e.preventDefault();

        recipientName.value = '';
        title.value = '';
        message.value = '';
    }

    function sendMail(e){
        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;

        let liToAdd = document.createElement('li');

        let spanTo = document.createElement('span');
        spanTo.textContent = `To: ${ultimateParent.children[1].textContent.split(': ')[1]}`;

        let spanTitle = document.createElement('span');
        spanTitle.textContent = `Title: ${ultimateParent.children[0].textContent.split(': ')[1]}`;
        
        let divButt = document.createElement('div');
        divButt.classList.add('btn');

        let buttDel = document.createElement('button');
        buttDel.type = 'submit';
        buttDel.classList.add('delete');
        buttDel.textContent = 'Delete';
        buttDel.addEventListener('click', deleteMail);

        divButt.appendChild(buttDel);

        liToAdd.appendChild(spanTo);
        liToAdd.appendChild(spanTitle);
        liToAdd.appendChild(divButt);

        ulSentMails.appendChild(liToAdd);
        ultimateParent.remove();
    }

    function deleteMail(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;

        let spanTo = document.createElement('span');
        let spanTitle = document.createElement('span');

        
        for(let i = 0; i < 2; i++){
            let line = ultimateParent.children[i].textContent.split(': ');
            if(line[0] === 'Title'){
                spanTitle.textContent = `Title: ${line[1]}`;
            } else if(line[0] === 'To' || line[0] === 'Recipient Name'){
                spanTo.textContent = `To: ${line[1]}`;
            }
        }

        let liToAdd = document.createElement('li');

        liToAdd.appendChild(spanTo);
        liToAdd.appendChild(spanTitle);

        deletedMails.appendChild(liToAdd);

        ultimateParent.remove();
    }
}
solve()