window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("xicota").addEventListener("click", persona, false);
    document.getElementById("persona").addEventListener("click", uwuscript, false);
    document.getElementById("holi").addEventListener("click", hola, false);
}

function persona() {
    var llamada = new XMLHttpRequest();
    //llamada.open("GET", "/Home/Index");
    llamada.open("GET", "https://apipennypersonas.azurewebsites.net/api/Personas/6");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4)
            document.getElementById("textouwu").innerHTML = "Cargando...";
        else if (llamada.readyState == 4 && llamada.status == 200)
            document.getElementById("textouwu").innerHTML = llamada.responseText;
    };

    //Mientras viene

    llamada.send();
}

function uwuscript() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "/Home/Index");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4)
            document.getElementById("textouwu").innerHTML = "Cargando...";
        else if (llamada.readyState == 4 && llamada.status == 200)
            document.getElementById("textouwu").innerHTML = llamada.responseText;
    };

    //Mientras viene

    llamada.send();
}

function hola() {
    alert("Holi");
}