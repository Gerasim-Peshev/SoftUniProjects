function solve() {

  let wholeText = document.getElementById('input').value;
  let area = document.getElementById('output');

  let splitedText = wholeText.split('.');
  splitedText.pop();
  let count = Math.ceil(splitedText.length / 3);

  let tempCount = splitedText.length;
  while(count > 0){
    let tempText = '';
    
    if(count === 1){
      for(let sentence = 0; sentence < splitedText.length; sentence++){
        if(splitedText[sentence] !== undefined){
          tempText+=splitedText[sentence] + '.';
          delete splitedText[sentence];
        }
      }
    } else {
        
        let times = 3;
        
        for(let i = splitedText.length - tempCount; i < splitedText.length; i++){
          tempText += splitedText[i] + '.';
          delete splitedText[i];
          tempCount--;
          times--;
          if(times === 0){
            break;
          }
        }
    }

    area.innerHTML+= `<p>${tempText}</p>`;

    count--;
  }
}