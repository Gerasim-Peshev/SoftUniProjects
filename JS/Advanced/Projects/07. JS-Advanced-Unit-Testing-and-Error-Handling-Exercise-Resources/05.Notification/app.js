function notify(message) {
  let hiddenDiv = document.getElementById('notification');

  hiddenDiv.textContent = message;

  hiddenDiv.style.display = 'block';

  hiddenDiv.addEventListener('click', hideMe);

  function hideMe(e){
    let butt = e.target;

    butt.style.display = 'none';
  }
}