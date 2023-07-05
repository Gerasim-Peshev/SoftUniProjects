export async function pushTopic(e){
    e.preventDefault();

    const formToCreate = new FormData(document.querySelector('form'));

    let topicName = formToCreate.get('topicName');
    let username = formToCreate.get('username');
    let postText = formToCreate.get('postText');
    let date = new Date();

    let newBody = JSON.stringify({topicName, username, postText, date});

    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'POST',
        headers: {'Content-type': 'application/json'},
        body: newBody
    });

    let data = await response.json();

    createDiv(newBody);
    debugger;
}

async function createDiv(body){
    
    debugger;
    let container = document.querySelector('.topic-container');
    let newBody = JSON.parse(body);
    //container = await container.json();
    
    const divToAdd = document.createElement('div');

    divToAdd.innerHTML = `
    <div class="topic-name-wrapper">
        <div class="topic-name">
            <a href="" class="normal">
                <h2>${newBody.topicName}</h2>
            </a>
            <div class="columns">
                <div>
                    <p>Date: <time>${newBody.date}</time></p>
                    <div class="nick-name">
                        <p>Username: <span>${newBody.username}</span></p>
                    </div>
                </div>    
            </div>
        </div>
    </div>
    `;

    container.appendChild(divToAdd);
}

