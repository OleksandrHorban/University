function str_del_last() {
    let srt = document.getElementById("text").textContent;
    let result = srt.slice(0, -1);
    document.getElementById("text").textContent = result
}


function str_del() {
    var selection = window.getSelection().toString();

    let str = document.getElementById("element").textContent;
    var start = str.indexOf(selection);
    let end = start + selection.length;
    let result = str.slice(0, start) + str.slice(end);
    document.getElementById("element").textContent = result;
}


function getFullName(name, surname) {
    return name + " " + surname;
}

console.log(getFullName("John", "Smith"));



function getLengthOfWord(word) {
    return word.length;
}

console.log(getLengthOfWord('some'));



function getLengthOfTwoWord(firstWord, secondWord) {
    return firstWord.length + secondWord.length;
}

console.log(getLengthOfTwoWord('some', 'kai'));



function isGreaterThen(firstNum, secondNum) {
    if(firstNum > secondNum){
        return true;
    }
    else{
        return false;
    }
}

console.log(isGreaterThen(11,10));



function isEven(num) {
    if(num % 2 == 0){
        return true;
    }
    else{
        return false;
    }
}

console.log(isEven(4));



function isSameLength(firstWord, secondWord) {
    let lfw = firstWord.length;
    let lsw = secondWord.length;
    if(lfw == lsw){
        return true;
    } 
    else{
        return false;
    }
}

console.log(isSameLength("some","word"));




function isEvenAndGreaterThanTen(num) {
    if(num % 2 == 0 && num > 10){
        return true;
    }
    else{
        return false;
    }
}

console.log(isEvenAndGreaterThanTen(14));




function computeAreaOfATriangle(firstNum, secondNum) {
    return 0.5 * secondNum * firstNum;
}

console.log(computeAreaOfATriangle(4,6));


function getProperty(object, name) {
    var result = "";
    for (var i in object) {
        if (i == name) {
            result = object[i];
        }
    }
    return result;
}
var obj = {
    key: 'value',
    str: 'rest'
};

console.log(getProperty(obj, "key"));

var myObj = {};



function addProperty(object, myproperty) {
    let P = myproperty;
   return object[P] = true;
}

addProperty(myObj, "myProp");
console.log(myObj.myProp);

var delObj = {
    name : "Sam",
    age: 20
};



function removeProperty(obj, property) {
    let removedP = property;
    return delete obj[removedP];
}

removeProperty(delObj, 'name');
console.log(delObj.name);
