//var myHeading = document.querySelector('h1.n1');
var myTxt = document.querySelector('h1.n2');
var myFont = document.querySelectorAll('.myclass');
for (var i = 0; i < myFont.length; i++) {
    myFont[i].style.fontSize = '35px';
    myFont[i].style.color = '#fff';
}
myTxt.innerHTML = 'Привіт, cтуденте!';
var person = prompt('Як Вас звати');
if (person != null) {
    myTxt.innerHTML =
        "Я вітаю Вас " + person + "!" + "<br>" + "";
}
myTxt.style.color = 'red';