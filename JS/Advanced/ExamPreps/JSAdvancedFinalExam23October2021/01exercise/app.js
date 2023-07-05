window.addEventListener('load', solve);

function solve() {

    document.getElementById('add-btn').addEventListener('click', createSong);

    let genreOfSong = document.getElementById('genre');
    let nameOfSong = document.getElementById('name');
    let autorOfSong = document.getElementById('author');
    let dateOfSong = document.getElementById('date');

    let allHitsCollection = document.getElementById('all-hits').children[0];
    let savedSongs = document.getElementById('saved-hits').children[0];
    let totalLikesField = document.getElementById('total-likes').children[0].children[0];
    
    function createSong(e){

        e.preventDefault();
        if(!genreOfSong.value || !nameOfSong.value || !autorOfSong.value || !dateOfSong.value){
            return;
        } else {

            let divToAdd = document.createElement('div');
            divToAdd.classList.add('hits-info');

            let imgToAdd = document.createElement('img');
            let h2GenreToAdd = document.createElement('h2');
            let h2NameToAdd = document.createElement('h2');
            let h2AutorToAdd = document.createElement('h2');
            let h3DateToAdd = document.createElement('h3');

            let buttSave = document.createElement('button');
            let buttLike = document.createElement('button');
            let buttDel = document.createElement('button');

            buttSave.addEventListener('click', saveSong);
            buttLike.addEventListener('click', likeSong);
            buttDel.addEventListener('click', delSong);

            buttSave.classList.add('save-btn');
            buttLike.classList.add('like-btn');
            buttDel.classList.add('delete-btn');

            buttSave.textContent = 'Save song';
            buttLike.textContent = 'Like song';
            buttDel.textContent = 'Delete';

            imgToAdd.setAttribute("src", "./static/img/img.png");;
            h2GenreToAdd.textContent = `Genre: ${genreOfSong.value}`;
            h2NameToAdd.textContent = `Name: ${nameOfSong.value}`;
            h2AutorToAdd.textContent = `Author: ${autorOfSong.value}`;
            h3DateToAdd.textContent = `Date: ${dateOfSong.value}`;

            genreOfSong.value = '';
            nameOfSong.value = '';
            autorOfSong.value = '';
            dateOfSong.value = '';

            divToAdd.appendChild(imgToAdd);
            divToAdd.appendChild(h2GenreToAdd);
            divToAdd.appendChild(h2NameToAdd);
            divToAdd.appendChild(h2AutorToAdd);
            divToAdd.appendChild(h3DateToAdd);
            divToAdd.appendChild(buttSave);
            divToAdd.appendChild(buttLike);
            divToAdd.appendChild(buttDel);

            allHitsCollection.appendChild(divToAdd);
        }
    }

    function saveSong(e){
        
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;

        let divToAddToSaved = document.createElement('div');
        divToAddToSaved.classList.add('hits-info');

        let imgToAdd = parent.children[0];
        let h2GenreToAdd = parent.children[1];
        let h2NameToAdd = parent.children[2];
        let h2AutorToAdd = parent.children[3];
        let h3DateToAdd = parent.children[4];
        let buttDel = parent.children[7];

        divToAddToSaved.appendChild(imgToAdd);
        divToAddToSaved.appendChild(h2GenreToAdd);
        divToAddToSaved.appendChild(h2NameToAdd);
        divToAddToSaved.appendChild(h2AutorToAdd);
        divToAddToSaved.appendChild(h3DateToAdd);
        divToAddToSaved.appendChild(buttDel);

        savedSongs.appendChild(divToAddToSaved);

        parent.remove();
    }

    function likeSong(e){
        e.preventDefault();
        let button = e.target;
        button.disabled = true;
            
            let line = Number(totalLikesField.textContent.split(': ')[1]);
            line++;
            totalLikesField.textContent = `Total Likes: ${line}`;

    }

    function delSong(e){
        e.preventDefault();

        let button = e.target;
        let parent = button.parentElement;

        parent.remove();
    }
}