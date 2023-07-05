function attachEvents() {

    document.getElementById('submit').addEventListener('click', post);
    document.getElementById('refresh').addEventListener('click', refreshMessages);
}

async function post(e){
    e.preventDefault();

    //debugger;

    let url = `http://localhost:3030/jsonstore/messenger`;

    let author = document.querySelector('input[name="author"]');
    let content = document.querySelector('input[name="content"]');

    let response = await fetch(url, {
        method: "POST",
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify({author: author.value, content: content.value})
    });

    content.value = '';
}


async function refreshMessages(e){
    e.preventDefault();

    let url = `http://localhost:3030/jsonstore/messenger`;

    let messages = document.getElementById('messages');

    let response = await fetch(url);

    //debugger;
    let data = await response.json();

    let content = Object.values(data);

    let buffSrt = '';

    for(let part of content){
        buffSrt += `${part.author}: ${part.content}\n`;
    }

    messages.textContent = buffSrt.slice(0, buffSrt.length - 1);
}

attachEvents();