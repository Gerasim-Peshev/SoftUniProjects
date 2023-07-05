function AggregateElements(arr){
    let len = arr.length;

   let sum =0;
   let sumDevided = 0;
   let concated  = '';

   for(let i = 0; i < len; i++){
    sum += Number(arr[i]);
   }
   for(let i = 0; i < len; i++){
    sumDevided += Number(1 / arr[i]);
   }
   for(let i = 0; i < len; i++){
    concated += String(arr[i]);
   }

   console.log(sum);
   console.log(sumDevided);
   console.log(concated);
}

AggregateElements([2, 4, 8, 16])