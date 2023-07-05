function encodeAndDecodeMessages() {

    //debugger;
    const areas = [...document.querySelectorAll('textarea')];

    const encodeArea = areas[0];
    const decodeArea = areas[1];

    const buttons = Array.from(document.getElementsByTagName('button'));

    const encodeButt = buttons[0];
    const decodeButt = buttons[1];

    encodeButt.addEventListener('click', encode);
    decodeButt.addEventListener('click', decode);

    function encode(){

        //debugger;
        let textToEncode = encodeArea.value;

        let result = '';

        for(let i = 0; i < textToEncode.length; i++){
            result+=String.fromCharCode(textToEncode.charCodeAt(i) + 1);
        }

        encodeArea.value = '';
        decodeArea.value = result;
    }

    function decode(){

        //debugger;
        let textToDecode = decodeArea.value;

        let result = '';

        for(let i = 0; i < textToDecode.length; i++){
            result+=String.fromCharCode(textToDecode.charCodeAt(i) - 1);
        }

        decodeArea.value = '';
        decodeArea.value = result;
    }
}