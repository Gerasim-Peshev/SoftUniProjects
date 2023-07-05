window.addEventListener("load", solve);

function solve() {
  document.getElementById('publish-btn').addEventListener('click', generatePost);
  document.getElementById('clear-btn').addEventListener('click', clearPublished);

  let title = document.getElementById('post-title');
  let category = document.getElementById('post-category');
  let content = document.getElementById('post-content');

  let ulForReview = document.getElementById('review-list');
  let ulpublishedList = document.getElementById('published-list');

  function generatePost(e){

    e.preventDefault();

    if(!title.value || !category.value || !content.value){
      return;
    } else {
      let liToAdd = document.createElement('li');
      liToAdd.classList.add('rpost');

      let articleToFill = document.createElement('article');

      let h4Title = document.createElement('h4');
      h4Title.textContent = `${title.value}`;

      let pCategory = document.createElement('p');
      pCategory.textContent = `Category: ${category.value}`;

      let pContent = document.createElement('p');
      pContent.textContent = `Content: ${content.value}`;

      let editButt = document.createElement('button');
      editButt.textContent = 'Edit';
      editButt.addEventListener('click', editElem);
      editButt.className = 'action-btn edit'

      let approveButt = document.createElement('button');
      approveButt.textContent = 'Approve';
      approveButt.addEventListener('click', approveElem);
      approveButt.className = 'action-btn approve';

      articleToFill.appendChild(h4Title);
      articleToFill.appendChild(pCategory);
      articleToFill.appendChild(pContent);

      liToAdd.appendChild(articleToFill);
      liToAdd.appendChild(editButt);
      liToAdd.appendChild(approveButt);

      ulForReview.appendChild(liToAdd);

      title.value = '';
      category.value = '';
      content.value = '';
    }

  }

  function editElem(e){
    e.preventDefault();

    let button = e.target;
    let parent = button.parentElement;

    title.value = parent.children[0].children[0].textContent;
    category.value = parent.children[0].children[1].textContent.split(': ')[1];
    content.value = parent.children[0].children[2].textContent.split(': ')[1];

    parent.remove();
  }

  function approveElem(e){
    e.preventDefault();

    let button = e.target;
    let parent = button.parentElement;

    let liToAdd = document.createElement('li');
    liToAdd.classList.add('rpost');

    let articleToFill = document.createElement('article');

    let h4Title = document.createElement('h4');
    h4Title.textContent = parent.children[0].children[0].textContent;

    let pCategory = document.createElement('p');
    pCategory.textContent = parent.children[0].children[1].textContent;

    let pContent = document.createElement('p');
    pContent.textContent = parent.children[0].children[2].textContent;

    articleToFill.appendChild(h4Title);
    articleToFill.appendChild(pCategory);
    articleToFill.appendChild(pContent);

    liToAdd.appendChild(articleToFill);

    ulpublishedList.appendChild(liToAdd);

    parent.remove();
  }

  function clearPublished(e){
    e.preventDefault();

    Array.from(ulpublishedList.querySelectorAll('li')).forEach(x => x.remove());
  }
}
