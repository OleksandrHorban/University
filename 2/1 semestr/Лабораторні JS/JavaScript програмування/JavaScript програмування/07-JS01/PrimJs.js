var a = "backgroud-color: #00ffff; color: black;";
a += "font-size: 24pt; font-family: 'Times New Roman'";
namee = 'Мережа магазинів "ВСЕ ДЛЯ БУДИНКУ"';
var da = new Date();
var d = da.getDate() + '.' + (da.getMonth() + 1) + '.' + da.getFullYear();
document.write('<p style = "text-align: center; '+ a +'">' + namee + '</p> <p> Сьогодні '+ d + '</p>');