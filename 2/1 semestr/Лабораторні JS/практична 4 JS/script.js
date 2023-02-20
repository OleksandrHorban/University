function findMinLengthOfThreeWords(str1, str2, str3) {
  var words = [str1.length, str2.length, str3.length];
  return Math.min(...words);
}

console.log(findMinLengthOfThreeWords('Sasha', 'Oleksandr', 'Sanyok'));



function filterOddElements(arr) {
  let new_arr = arr.filter(number => !(number % 2 == 0));
  return new_arr;
}

console.log(filterOddElements([1, 2, 3, 4, 5]));



function getLengthOfShortestElement(arr) {
  let array = new Array();
  for (let i = 0; i < arr.length; i++) {
    const el = arr[i];
    array[i] = el.length;
  }
  return Math.min(...array);

}

console.log(getLengthOfShortestElement(["one", "two", "three"]));



function joinArrayOfArrays(arr) {
  return arr.reduce((a, b) => a.concat(b), []);
}

console.log(joinArrayOfArrays([[1, 4], [true, false], ["x", "y"]]));



function findSmallestNumberAmongMixedElements(arr) {
  let array = new Array();
  if (arr.length == 0) {
    return 0;
  }
  else {
    for (let i = 0; i < arr.length; i++) {
      const element = arr[i];
      if (typeof element !== 'number') {
        break;
      }
    }
    for (let i = 0; i < arr.length; i++) {
      const element = arr[i];
      if (typeof element == 'number') {
        array.push(element);
      }
    }
    if (array.length == 0) {
      return 0;
    }
  }
  return Math.min(...array);
}

console.log(findSmallestNumberAmongMixedElements([4, 'lincoln', 9, 'octopus']));



function computeSummationToN(number) {
  var result = 0;
  while (number) {
    result += number--;
  }
  return result;
}

console.log(computeSummationToN(6));



function convertScoreToGrade(score) {
  var result;
  if (score <= 100 && score >= 90 ){
    result = 'A';
  } else if( score <= 89 && score >= 82 ){
    result = 'B';
  } else if ( score <= 81 && score >= 75 ){
    result = 'C';
  } else if ( score <= 74 && score >= 69 ){
    result = 'D';
  } else if ( score <= 68 && score >= 60 ){
    result = 'E';
  } else if ( score <= 59 && score >= 35 ){
    result = 'Fx';
  } else if ( score <= 34 && score >= 0 ){
    result = 'F';
  } else if (score > 100 || score < 0){
    result = 'INVALID SCORE';
  }
  return result;
}

console.log(convertScoreToGrade(91));



function getLongestOfThreeWords(word1, word2, word3) {
  var words = [word1, word2, word3];
  var words_length = [word1.length, word2.length, word3.length]

  if (words_length[0] == words_length[1] && words_length[1] == words_length[2]) {
    return word1;
  }
  else {
    return words[words_length.indexOf(Math.min(...words_length))];
  }
}

console.log(getLongestOfThreeWords('these', 'three', 'words'));



function multiply(num1, num2) {
  var result = 0;

  for (let i = 0; i < num2; i++) {
    result += num1;    
  }
  return result;
}

console.log(multiply(4,7));



function computeSumBetween(num1, num2) {
  var result = 0;
  if (num2 < num1){
    return result;
  }
  else{
  while (num1 < num2) {
    result += num1;
    num1++;
    }
  }
  return result;
}

console.log(computeSumBetween(2, 5));