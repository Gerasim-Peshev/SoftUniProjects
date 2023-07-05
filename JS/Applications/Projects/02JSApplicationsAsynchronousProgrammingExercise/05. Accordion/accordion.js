(async function solution() {
    
    //debugger;
    let main = document.getElementById('main');

    let urlTitle = `http://localhost:3030/jsonstore/advanced/articles/list`;

    let responseTitles = await fetch(urlTitle);

    let dataTitles = await responseTitles.json();

    for(let elem of dataTitles){
        
        let divMain = document.createElement('div');
        divMain.className = 'accordion';

        let divHead = document.createElement('div');
        divHead.className = 'head';

        let spanTitle = document.createElement('span');
        spanTitle.textContent = elem.title;

        let buttonMoreLess = document.createElement('button');
        buttonMoreLess.className = 'button';
        buttonMoreLess.id = elem._id;
        buttonMoreLess.onclick = getInfo;
        buttonMoreLess.textContent = 'More';

        let divExtra = document.createElement('div');
        divExtra.className = 'extra';
        divExtra.style.display = 'none';

        let pText = document.createElement('p');


        divHead.appendChild(spanTitle);
        divHead.appendChild(buttonMoreLess);

        divExtra.appendChild(pText);

        divMain.appendChild(divHead);
        divMain.appendChild(divExtra);

        
        main.appendChild(divMain);
    }

    async function getInfo(e){
        
        //debugger;
        let button = e.target;
        let parent = button.parentElement;
        let ultimateParent = parent.parentElement;

        let pTextToShow = ultimateParent.children[1].children[0];

        if(button.textContent === 'More'){
            let info = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${button.id}`).then(response => response.json());

            pTextToShow.textContent = info.content;
            ultimateParent.children[1].style.display = 'block';
            button.textContent = 'Less'
        } else if (button.textContent === 'Less'){

            pTextToShow.textContent = '';
            ultimateParent.children[1].style.display = 'none';
            button.textContent = 'More';
        }
    }
})()