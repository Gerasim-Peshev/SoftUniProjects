window.addEventListener("load", solve);

function solve() {
  
  let publishButt = document.getElementById('form-btn');
  publishButt.addEventListener('click', createForm);

  let fName = document.getElementById('first-name');
  let lName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');

  let previewList = document.getElementById('preview-list');
  let mainDiv = document.getElementById('main');

  function createForm(e){
    e.preventDefault();

    if(!fName.value || !lName.value || !age.value || !storyTitle.value || !genre.value || !story.value){
      return
    } else {

      let liToAdd = document.createElement('li');
      liToAdd.className = 'story-info';

      let articleToAdd = document.createElement('article');

      let h4Name = document.createElement('h4');
      h4Name.textContent = `Name: ${fName.value} ${lName.value}`;

      let pAge = document.createElement('p');
      pAge.textContent = `Age: ${age.value}`;

      let pTitle = document.createElement('p');
      pTitle.textContent = `Title: ${storyTitle.value}`;

      let pGenre = document.createElement('p');
      pGenre.textContent = `Genre: ${genre.value}`;

      let pStory = document.createElement('p');
      pStory.textContent = story.value;

      let saveButt = document.createElement('button');
      saveButt.className = 'save-btn';
      saveButt.textContent = 'Save Story';
      saveButt.addEventListener('click', saveStory);

      let editButt = document.createElement('button');
      editButt.className = 'edit-btn';
      editButt.textContent = 'Edit Story';
      editButt.addEventListener('click', editStory);

      let deleteButt = document.createElement('button');
      deleteButt.className = 'delete-btn';
      deleteButt.textContent = 'Delete Story';
      deleteButt.addEventListener('click', deleteStory);

      articleToAdd.appendChild(h4Name);
      articleToAdd.appendChild(pAge);
      articleToAdd.appendChild(pTitle);
      articleToAdd.appendChild(pGenre);
      articleToAdd.appendChild(pStory);

      liToAdd.appendChild(articleToAdd);
      liToAdd.appendChild(saveButt);
      liToAdd.appendChild(editButt);
      liToAdd.appendChild(deleteButt);

      previewList.appendChild(liToAdd);

      fName.value = '';
      lName.value = '';
      age.value = '';
      storyTitle.value = '';
      genre.value = '';
      story.value = '';

      publishButt.disabled = true;
    }

    function saveStory(e){
      e.preventDefault();

      let h1Saved = document.createElement('h1');
      h1Saved.textContent = 'Your scary story is saved!';
      mainDiv.replaceChildren(h1Saved);
    }

    function editStory(e){
      e.preventDefault();

      let button = e.target;
      let parent = button.parentElement;

      fName.value = parent.children[0].children[0].textContent.split(': ')[1].split(' ')[0];
      lName.value = parent.children[0].children[0].textContent.split(': ')[1].split(' ')[1];
      age.value = parent.children[0].children[1].textContent.split(': ')[1];
      storyTitle.value = parent.children[0].children[2].textContent.split(': ')[1];
      genre.value = parent.children[0].children[3].textContent.split(': ')[1];
      story.value = parent.children[0].children[4].textContent;

      parent.remove();

      publishButt.disabled = false;
    }

    function deleteStory(e){
      e.preventDefault();

      let button = e.target;
      let parent = button.parentElement;

      publishButt.disabled = false;
      parent.remove();
    }
  }
}
