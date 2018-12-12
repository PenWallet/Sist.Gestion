/// <reference path="entidades.js" />
window.onload = inicializaEventos;

function inicializaEventos() {
    hideBtnBorrar();
    cargarTabla();
}

function cargarTabla() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "https://apipennypersonas.azurewebsites.net/api/Personas/");

    llamada.onreadystatechange = function ()
    {
        if (llamada.readyState < 4)
        {
            document.getElementById("tbodyPersonas").innerHTML = "Cargando...";
        }
        else if (llamada.readyState == 4 && llamada.status == 200)
        {
            //CargarListado
            document.getElementById("tbodyPersonas").innerHTML = "";
            var texto = llamada.responseText;
            var data = JSON.parse(texto);
            cargarListado(data);
        }
    };

    llamada.send();
}

function cargarListado(data)
{
    var tbody = document.getElementById("tbodyPersonas");
    var tr;
    for (var i = 0; i < data.length; i++)
    {
        tr = document.createElement("tr");
        var td = document.createElement("td");
        var checkBox = document.createElement("input");
        checkBox.setAttribute("type", "checkbox");
        checkBox.setAttribute("class", "checkthis");
        checkBox.setAttribute("name", "checkBoxDelete");
        checkBox.setAttribute("id", data[i].idPersona);
        checkBox.addEventListener("change", checkBoxesChanged, false)
        td.appendChild(checkBox);
        tr.appendChild(td);
        for (var prop in data[0])
        {
            td = document.createElement("td");
            var textoCelda = document.createTextNode(data[i][prop]);
            td.appendChild(textoCelda);
            if (prop == "idPersona")
                td.style.display = "block";
            tr.appendChild(td);
        }
        //Agregamos el botón Edit, que viene a partir de este HTML:
        //<p title="Edit"><button class="btn btn-primary btn-xs"><span class="glyphicon glyphicon-pencil"></span></button></p>
        td = document.createElement("td");
        var p = document.createElement("p");
        p.setAttribute("title", "Edit");
        var buttonEdit = document.createElement("button");
        buttonEdit.setAttribute("class", "btn btn-primary btn-xs");
        buttonEdit.setAttribute("name", "btnEdit");
        buttonEdit.setAttribute("value", data[i].idPersona);
        var span = document.createElement("span");
        span.setAttribute("class", "glyphicon glyphicon-pencil");
        buttonEdit.appendChild(span);
        buttonEdit.addEventListener("click", prueba,false)
        p.appendChild(buttonEdit);
        td.appendChild(p);
        tr.appendChild(td);
        tbody.appendChild(tr);
    }
}

function hideBtnBorrar() {
    var botonBorrar = document.getElementById("btnBorrar");
    botonBorrar.style.display = "none";
}

function showBtnBorrar() {
    var botonBorrar = document.getElementById("btnBorrar");
    botonBorrar.style.display = "block";
}

function prueba() {
    showBtnBorrar();
}

function checkBoxesChanged() {
    var arrayCB = document.getElementsByName("checkBoxDelete");
    var isAtLeastOneChecked = false;
    var isAtLeastOneNotChecked = false;
    var checkBoxAll = document.getElementById("checkall");

    for (var i = 0; i < arrayCB.length; i++) {
        if (arrayCB[i].checked)
            isAtLeastOneChecked = true;
        else
            isAtLeastOneNotChecked = true;
    }

    if (!isAtLeastOneNotChecked)
        checkBoxAll.checked = true;
    else
        checkBoxAll.checked = false;

    if (isAtLeastOneChecked)
        showBtnBorrar();
    else
        hideBtnBorrar();
}

function checkAll() {
    var checkall = document.getElementById("checkall");
    var checkBoxes = document.getElementsByName("checkBoxDelete");
    for (var i = 0; i < checkBoxes.length; i++)
        checkBoxes[i].checked = checkall.checked;

    if (checkall.checked)
        showBtnBorrar();
    else
        hideBtnBorrar();
}

