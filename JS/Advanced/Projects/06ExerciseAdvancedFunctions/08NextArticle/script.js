function getArticleGenerator(articles) {
    
    let artics = Array.from(articles);
    let content = document.getElementById('content');

    return () => {
        if(!artics.length){
            return;
        }

        let currArtic = artics.shift();
        content.innerHTML += `<article>${currArtic}</article>`;
    }
}
