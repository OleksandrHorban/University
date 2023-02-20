var r = confirm("Готові гризти граніт науки?");
if (r == true) {
    myTxt.innerHTML = "ВПЕРЕД ДО ЗНАНЬ!";

} else {
    myTxt.innerHTML = "Мені дуже сумно!";
}
var myImage = document.querySelector('img');
var j = 0;
myImage.onclick = function () {
    j++;
    var mySrc = myImage.getAttribute('src');
    if (mySrc === 'images/firefox-icon.png') {
        myImage.setAttribute ('src', 'images/firefox-icon_bw.png');
    } else {
        myImage.setAttribute ('src', 'images/firefox-icon.png');
    }
    if (j == 3) {
        //myTxt.innerHTML = "Завдання виконано";
        //myImage.parentNode.removeChild(myImage);//x.parentNode.removeChild(x) видалення вузла
        myImage.remove();
        document.write("<h1>Вітаю!</h1><h2>Завдання виконано!</h2>");
    }
}
//var x = myTxt.childNodes[0].nodeValue;//Текст у середині елементів вважаються текстовими вузлами element.childNodes[0].nodeValue
//var x = myTxt.textContent;// document.getElementsByTagName("BUTTON")[0].textContent;
//var x = myTxt.innerHTML;
myTxt.innerHTML += "<br>" + "  Клацніть мишею по емблемі FireFox!";