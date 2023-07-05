function editElement(html, textToChange, replacer) {
    let res = html.textContent;
    let matcher = new RegExp(textToChange, 'g');
    let edited = res.replace(matcher, replacer);

    html.textContent = edited;
}