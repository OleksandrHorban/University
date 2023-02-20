let curT = -1.6;
let curR = 50;
let st = false; // зупинити процес
let proc;

function Start_stop() {
    if (st) {
        clearInterval(proc);
        st = false;
        document.all.B1.innerHTML = "Запустити";
    }
    else
    {
        proc = setInterval("move()", 20);
        st = true;
        document.all.B1.innerHTML = "Стоп";
    }
}

function move() {
    if (curT >= 4.6) curT = -1.6;
    else curT += 0.1;
    var y = +curR * Math.sin(curT);
    var x = +curR * Math.cos(curT);
    //console.log("T: " + curT + ", X: " + x + ", Y: " + y);
    document.all.lv.style.top = 100 + y;
    document.all.lv.style.left = 100 + x;
}

let flag = false;
let bounds;
function init() {
    kv = document.all.kv;
    bounds = document.all.bounds;
    kv.onmousemove = dragIt;
    kv.onmouseup = osvobodi;
    kv.onmousedown = zachvat;
    onmousedown = zachvat;
}
function dragIt(evt) {
    let sobytie = (evt) ? evt : (window.event) ? window.event : "";
    if (flag) {
        if (checkX(sobytie.clientX) && checkY(sobytie.clientY)) {
            sobytie.target.style.top = sobytie.clientY - 35;
            sobytie.target.style.left = sobytie.clientX - 35;
        }
        else if (!checkX(sobytie.clientX) && checkY(sobytie.clientY)) {
            sobytie.target.style.top = sobytie.clientY - 35;
        }
        else if (checkX(sobytie.clientX) && !checkY(sobytie.clientY)) {
            sobytie.target.style.left = sobytie.clientX - 35;
        }
    }
}

function checkX(x) {
    return x > parseInt(bounds.style.left) + parseInt(kv.style.width) / 2 && x < parseInt(bounds.style.left) + parseInt(bounds.style.width) - parseInt(kv.style.width) / 2 
}

function checkY(y) {
    return y > parseInt(bounds.style.top) + parseInt(kv.style.height) / 2 && y < parseInt(bounds.style.top) + parseInt(bounds.style.height) - parseInt(kv.style.height) / 2
}

function osvobodi() {
    flag = false;
}

function zachvat() {
    flag = true;
}