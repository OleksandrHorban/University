function inputBody() {
    document.body.innerHTML =  '<div class="hcenter">' +
        '<h3>Select function</h3>' +
        '<select id="func">' +
            '<option value="sin">sin</option>' +
            '<option value="cos">cos</option>' +
            '<option value="tan">tg</option>' +
            '<option value="1/tan">ctg</option>' +
        '</select>' +
        '<h3>Input params</h3>' +
        '<p>Start <input id="x0" type="number" value="0" onmousedown="mouseDown(this, event)" onmouseup="mouseUp()" /></p>' +
        '<p>End <input id="x1" type="number" value="5" onmousedown="mouseDown(this, event)" onmouseup="mouseUp()" /></p>' +
        '<p>Step <input id="h" type="number" value="0.2" onmousedown="mouseDown(this, event)" onmouseup="mouseUp()" /></p>' +
        '<p style="cursor: pointer" onclick="Calculate(func.value, x0.value, x1.value, h.value)">Calculate</p>' +
        '</div>'
}

function Calculate(func, start, end, step) {
    if (func == "1/tan") func = "ctg";

    document.body.innerHTML = '<div class="hcenter">' +
        '<h3>Result</h3>' +
        '<table id="tab1">' +
        '<tr>' +
        '<td colspan="2"><b>Angle</b></td>' +
        '<td rowspan="2"><b>' + func + '</b></td>' +
        '</tr >' +
        '<tr>' +
        '<td>In degrees</td>' +
        '<td>In radians</td>' +
        '</tr>' +
        '</table >' +
        '<p style="cursor: pointer" onclick="inputBody()">Back</p>'

    start = parseFloat(start);
    end = +end;
    step = +step;

    if (start > end) {
        start += end;
        end = start - end;
        start -= end;
    }

    if (+step > 0) {
        step = Math.abs(step);
    }

    let command = "";
    let row, cell;
    while (start < end) {

        row = document.all.tab1.insertRow();
        cell = row.insertCell(0);
        cell.innerHTML = start;

        cell = row.insertCell(1);
        cell.innerHTML = start * Math.PI / 180;

        if (func != "ctg") command = "Math.";
        else { command = "1 / Math."; func = "tan"; }
        command += func + "( Math.PI / 180 * " + start + ")";

        cell = row.insertCell(2);
        cell.innerHTML = eval(command);

        start += step;
    }
}

function Update(artId, price, count) {
    artId = +artId;
    price = +price;
    count = +count;

    table = document.all.tovar;
    let oldPrice = table.rows[artId].cells[1];
    oldPrice = +oldPrice.innerHTML.slice(0, oldPrice.innerHTML.indexOf(" ")) * +table.rows[artId].cells[2].innerHTML;
    table.rows[artId].cells[1].innerHTML = price + " грн";
    table.rows[artId].cells[2].innerHTML = count;
    table.rows[artId].cells[3].innerHTML = price * count + " грн";

    let fullPrice = table.rows[table.rows.length - 1].cells[1];
    fullPrice.innerHTML = fullPrice.innerHTML.slice(0, fullPrice.innerHTML.indexOf(" "));
    fullPrice.innerHTML = +fullPrice.innerHTML + price * count - oldPrice + " грн";
}

function mouseDown(elem, event) {
    let box = elem.getBoundingClientRect();
    let body = document.body;
    let docElem = document.documentElement;
    let scrollTop = window.pageYOffset || docElem.scrollTop || body.scrollTop;
    let clientTop = docElem.clientTop || body.clientTop || 0;
    let top = box.top + scrollTop - clientTop;
    let y = event.clientY;
    timer = setInterval(function () {
        if (y <= top + 10) elem.value++;
        else elem.value--;
    }, 50);
}

function mouseUp() {
    clearTimeout(timer);
}

function randomColor() {
    return "rgb(" + Math.floor(Math.random() * 255) + "," + Math.floor(Math.random() * 255) + "," + Math.floor(Math.random() * 255) + ")";
}

function randomReverseColor(rgb) {
    colors = rgb.slice(4, rgb.length - 1).split(",");
    return "rgb(" + (255 - colors[0]) + ", " + (255 - colors[1]) + ", " + (255 - colors[2]) + ")";
}