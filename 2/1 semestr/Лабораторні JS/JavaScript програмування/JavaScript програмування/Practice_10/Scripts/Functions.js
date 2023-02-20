function changeCivicImg(src) {
    civic.src = "./Images/50px-Civic_" + src + ".png";
    civic.alt = src;
}

function drawEllipse(x, y) {
    x = parseInt(x);
    y = parseInt(y);
    let canvas = document.getElementById('canvas');
    canvas.width = 2 * x + 10;
    canvas.height = 2 * y + 10;
    if (canvas.getContext) {
        let context = canvas.getContext('2d');
        context.beginPath();
        context.ellipse(x + 5, y + 5, x, y, 0, 0, 2 * Math.PI);
        context.stroke();
    }
}

var timer;

function mouseDown(elem, event) {
    var box = elem.getBoundingClientRect();
    var body = document.body;
    var docElem = document.documentElement;
    var scrollTop = window.pageYOffset || docElem.scrollTop || body.scrollTop;
    var clientTop = docElem.clientTop || body.clientTop || 0;
    var top = box.top + scrollTop - clientTop;
    var y = event.clientY;
    timer = setInterval(function () {
        if (y <= top + 10) elem.value++;
        else elem.value--;
        drawEllipse(document.getElementById('x').value, document.getElementById('y').value);
    }, 50);
}

function mouseUp() {
    clearTimeout(timer);
}