window.addEventListener("load", solve);

function solve() {
  document.getElementById('publish-btn').addEventListener('click', sendPostForReview);
  document.getElementById('clear-btn').addEventListener('click', clearApprovedList);
  let title = document.getElementById('post-title');
  let category = document.getElementById('post-category');
  let contentOfPost = document.getElementById('post-content');
  let ulToAdd = document.getElementById('review-list');
  let approveUl = document.getElementById('published-list');

  function sendPostForReview(e){
    if(!title.value || !category.value || !contentOfPost.value){
      return;
    }

    createPost(title, category, contentOfPost);
  }

  function createPost(){
    let liToAdd = document.createElement('li');
    let artic = document.createElement('article');

    let h4Elem = document.createElement('h4');
    h4Elem.textContent = title.value;

    let pCatehory = document.createElement('p');
    pCatehory.textContent = `Category: ${category.value}`;

    let pContent = document.createElement('p');
    pContent.textContent = `Content: ${contentOfPost.value}`;

    let buttonEdit = document.createElement('button');
    let buttonAprove = document.createElement('button');

    buttonEdit.textContent = 'Edit';
    buttonAprove.textContent = 'Approve'

    buttonEdit.className = 'action-btn edit';
    buttonAprove.className = 'action-btn approve';

    buttonEdit.addEventListener('click', editPost);
    buttonAprove.addEventListener('click', aprovePost);

    artic.appendChild(h4Elem);
    artic.appendChild(pCatehory);
    artic.appendChild(pContent);
    artic.appendChild(buttonEdit);
    artic.appendChild(buttonAprove);

    liToAdd.classList.add('rpost');
    liToAdd.appendChild(artic);

    title.value = '';
    category.value = '';
    contentOfPost.value = '';
    
    ulToAdd.appendChild(liToAdd);
  }

  function editPost(e){
    let button = e.target;
    let parent = button.parentElement;

    let titleOfCurrPost = parent.querySelector('h4').textContent;
    let categoryOfCurrPost = parent.querySelectorAll('p')[0];
    let contentOfCurrPost = parent.querySelectorAll('p')[1];

    title.value = titleOfCurrPost;
    category.value = categoryOfCurrPost.textContent.split(': ')[1];
    contentOfPost.value = contentOfCurrPost.textContent.split(': ')[1];

    parent.parentElement.remove();
  }

  function aprovePost(e){
    let button = e.target;
    let parent = button.parentElement;
    let supremeParent = parent.parentElement;

    Array.from(supremeParent.querySelectorAll('button')).forEach(butt => butt.remove());

    approveUl.appendChild(supremeParent);
    //supremeParent.remove();
  }

  function clearApprovedList(){
    Array.from(approveUl.querySelectorAll('li')).forEach(l => l.remove());
  }
}
