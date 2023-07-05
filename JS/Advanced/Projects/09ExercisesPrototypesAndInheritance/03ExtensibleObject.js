function extensibleObject(){
    return {
        __proto__: {},
        extend: function(objToCopyFrom){
            for(let elem of Object.entries(objToCopyFrom)){
                if(typeof elem[1] === 'function'){
                    __proto__[elem[0]] = elem[1];
                } else {
                    [elem[0]] = elem[1];
                }
            }
        }
    }
}

const myObj = extensibleObject(); 
const template = { 
    extensionMethod: function () {}, 
    extensionProperty: 'someString' 
  } 

  myObj.extend(template); 
  