function DayCalculator(year, month, day){
    let myDate = new Date(year,month - 1,day - 1);

    //myDate.setDate(myDate.getDate - 1);
    console.log(`${myDate.getFullYear()}-${myDate.getMonth()+1}-${myDate.getDate()}`);
}

DayCalculator(2016, 9, 30)