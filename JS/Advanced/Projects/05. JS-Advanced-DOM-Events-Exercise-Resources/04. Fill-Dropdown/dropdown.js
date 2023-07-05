function addItem() {
    const textItem = document.getElementById('newItemText');
    const valueItem = document.getElementById('newItemValue');
    const selectItem = document.getElementById('menu');

    const optElem = document.createElement('option');

    optElem.textContent = textItem.value;
    optElem.value = valueItem.value;

    selectItem.appendChild(optElem);

    textItem.value = '';
    valueItem.value = '';
}