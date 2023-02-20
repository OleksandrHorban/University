function computeAreaOfARectangle(l, w) {
    return l*w;
}
console.log(computeAreaOfARectangle(4,8));

function computeAreaOfACircle(r) {
    return Math.PI * Math.pow(r,2);
}
console.log(computeAreaOfACircle(4));

function computePower(num, up){
    return Math.pow(num, up);
}
console.log(computePower(2, 3));

function computeSquareRoot(num) {
    return Math.sqrt(num);
}
console.log(computeSquareRoot(9));

function getLengthOfThreeWords(word1, word2, word3) {
   var result_word = word1+word2+word3;
   return result_word.length;
}
console.log(getLengthOfThreeWords('word', 'some', 'text'));

function joinArrays(arr1, arr2) {
    return arr1.concat(arr2);
}
console.log(joinArrays([1,2], [3,4]));

// function getProductOfAllEIementsAtProperty(obj, key) {
//     const reducer = (accumulator, currentValue) => accumulator + currentValue;
//     if (obj.key.length == 0) {
//         return 0;
//     } else if(typeof obj.key !== 'object'){
//         return 0;
//     } else if(typeof obj.key == 'undefined'){
//         return 0;
//     } else{
//         return obj.key.reduce(reducer);
//     }
// }
// var obj = {
//     key: [1,2,3,4]
// };
// var output = getProductOfAllEIementsAtProperty(obj, 'key');
// console.log(output);

function sumDigits(num) {
    var arr;
    if (num < 0){
        arr = num.toString(10).replace(/\D/g, '0').split('').map(Number);
        arr[1] = arr[1] * -1;
    }else{
        arr = num.toString(10).replace(/\D/g, '0').split('').map(Number);
    }   
    console.log(arr);
    const reducer = (accumulator, currentValue) => accumulator + currentValue;
    return arr.reduce(reducer);
}
console.log(sumDigits(1148));



function findShortestWordAmongMixedElements(arr) {
    var demo_arr = new Array();
    var demo_arr_2 = new Array();
    var demo_arr_2_len = new Array();

    if (arr.length == 0) {
        return " ";
    }
    for (let i = 0; i < arr.length; i++) {
        const element = arr[i];
        if (typeof element == "string") {
            demo_arr.push(element);
        }
        
    }
    console.log(demo_arr);
    if (demo_arr.length == 0) {
        return " ";
    }
    for (let i = 0; i < demo_arr.length; i++) {
            if (demo_arr[i] !== demo_arr[i+1]) {
                demo_arr_2.push(demo_arr[i]);
            }        
    }
    for (let i = 0; i < demo_arr_2.length; i++) {
        const element = demo_arr_2[i];
        demo_arr_2_len.push(element.length);
    }

    return demo_arr_2[demo_arr_2_len.indexOf(Math.min(...demo_arr_2_len))];
}
console.log(findShortestWordAmongMixedElements([1, 'two', 5, 'two', 'three']));

function findSmallestNumberAmongMixedElements(arr) {
    let demo_arr = new Array();
    if (arr.length == 0) {
      return " ";
    }
    else {
      for (let i = 0; i < arr.length; i++) {
        const element = arr[i];
        if (typeof element == 'number') {
          demo_arr.push(element);
        }
      }
      if (demo_arr.length == 0) {
        return " ";
      }
    }
    return Math.min(...demo_arr);
  }

  console.log(findSmallestNumberAmongMixedElements([4, 'lincoln', 9, 'octopus']));

function modulo(num1, num2) {
    if (num1 == 0) {return 0;}
    if (num2 == 0) {return NaN;}
    if (isNaN(num1) || isNaN(num2)) {return NaN;}
    var result = Math.trunc(num1 / num2);
    var result2 = result * num2;
    return num1 - result2;
}

console.log(modulo(-16, 6));

function flipEveryNChar(a, b) {
    let arr = [];
    let c = 0;
    let d = b;
    let n = a.length / b;
    let revArr = [];
    let join = "";
    let temp = "";
    for (let i = 0; i < n; i++) {
        arr[i] = a.slice(c, d);
        revArr[i] = arr[i].split('').reverse().join('');
        temp = revArr[i];
        join += temp;
        c += b;
        d += b;
    }
    return join;
}

var input = "a short example";
console.log(flipEveryNChar(input, 5));

function detectOutlierValue(nums) {
    var arr_odd = [];
    var arr_even = [];
    var arr = nums.split(' ').map(function (item) {
        return +item;
    });
    for (let i = 0; i < arr.length; i++) {
        const element = arr[i];
        if (element%2 == 0) {
            arr_even.push(element);
        }
        if (element%2 !== 0) {
            arr_odd.push(element);
        }
    }
    if (arr_odd.length == 1) {
        return arr_odd[0];
    }else if (arr_even.length == 1){
        return arr_even[0];
    }else{
        return 'Немає одинарного парного чи непарного числа'
    }
}

console.log(detectOutlierValue("1 1 10 1 1"));

function findPairsForSum(a, b) {
    var str;
    for (let i = 0; i < a.length; i++) {
        for (let j = 0; j < a.length; j++) {
            if (a[i] + a[j] == b) {
                str = ("[" + a[i] + "," + a[j] + "] = " + b);
            }
        }
    }
    return str;
}

console.log(findPairsForSum([1, 5, 4, 8], 5));

function isMirrorString(word1, word2) {
    return word1 == word2.split('').reverse().join('') ? true : false;
}

console.log(isMirrorString("hello", "olleh"));

function binary(arr, target){
    let start = 0;
    let end = arr.length;
    let pivot = Math.floor((start + end) / 2);
    let steps = 0;
  
    for (let i = 0; i < arr.length; i++) {
      if (arr[pivot] !== target) {
        if (target < arr[pivot]) end = pivot;
        else start = pivot;
        pivot = Math.floor((start + end) / 2);
        steps++;
      }
  
      if (arr[pivot] === target) return pivot;
    }
  
    return 'Nothing Found';
  }
  var arrr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 
    16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50];
  console.log(binary(arrr, 9));

  function isIsogram(a) {
    let arr = [];
    let n = a.length;
    let count = 0;
    for (let i = 0; i < n; i++) {
        arr = a.split('');
    }
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr.length; j++) {
            if (arr[i] == arr[j]) {
                count++
            } else { continue; }
        }
    }
    if (count == a.length) {
        return "isogram";
    } else {
        return "not isogram.";
    }
}

console.log(isIsogram("exact"));

function checkPalindrom(a) {
    return a == a.split('').reverse().join('');
}

console.log(checkPalindrom("alla"));