function on() {
    document.getElementById("image").src = "img/pic_bulbon.jpg";
}
function off() {
    document.getElementById("image").src = "img/pic_bulboff.jpg";
}
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
async function demo(){
    while (true) {
        await sleep(2000);
        document.getElementById("color").src = "img/2.png";
        await sleep(4000);
        document.getElementById("color").src = "img/3.png";
        await sleep(5000);
        document.getElementById("color").src = "img/1.png";    
    }
}

demo();
console.log(document.getElementById("color").src);