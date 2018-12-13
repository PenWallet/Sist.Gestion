/// <reference path="entidades.js" />
window.onload = inicializaEventos;

function inicializaEventos() {
    hideBtnBorrar();
    hideBtnAceptar();
    hideBtnRechazar();
    document.getElementById("btnBorrar").addEventListener("click", borrarPersonasClick, false);
    document.getElementById("btnAnadir").addEventListener("click", anadirPersona, false);
    document.getElementById("btnAceptar").addEventListener("click", aceptarPersona, false);
    document.getElementById("btnRechazar").addEventListener("click", rechazarPersona, false);
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
        //Creamos el elemento table row (tr)
        tr = document.createElement("tr");

        //También el elemento table data (td)
        var td = document.createElement("td");

        //Y el checkbox para hacer el input
        var checkBox = document.createElement("input");
        checkBox.setAttribute("type", "checkbox");
        checkBox.setAttribute("class", "checkthis");
        checkBox.setAttribute("name", "checkBoxDelete");
        checkBox.setAttribute("id", data[i].idPersona);
        checkBox.addEventListener("change", checkBoxesChanged, false)

        //Lo agregamos a td
        td.appendChild(checkBox);
        //Y eso a tr
        tr.appendChild(td);

        //Recorremos todas las filas de información e insertamos
        for (var prop in data[0])
        {
            td = document.createElement("td");
            var textoCelda = document.createTextNode(data[i][prop]);
            td.appendChild(textoCelda);
            if (prop == "idPersona")
                td.style.display = "none";
            tr.appendChild(td);
        }
        //Agregamos el botón Edit, que viene a partir de este HTML:
        //<p title="Edit"><button class="btn btn-primary btn-xs"><span class="glyphicon glyphicon-pencil"></span></button></p>
        td = document.createElement("td");
        var p = document.createElement("p");
        p.setAttribute("title", "Editar");
        var buttonEdit = document.createElement("button");
        buttonEdit.setAttribute("class", "btn btn-primary btn-xs");
        buttonEdit.setAttribute("name", "btnEdit");
        buttonEdit.setAttribute("value", data[i].idPersona);
        var span = document.createElement("span");
        span.setAttribute("class", "glyphicon glyphicon-pencil");
        buttonEdit.appendChild(span);
        buttonEdit.addEventListener("click", editPersona, false)
        p.appendChild(buttonEdit);
        td.appendChild(p);
        tr.appendChild(td);
        tbody.appendChild(tr);
    }
}

function editPersona() {
    alert(this.value);
}

function borrarPersonasClick() {
    var listado = document.getElementsByName("checkBoxDelete");
    var listadoId = new Array();
    for (var i = 0; i < listado.length; i++) {
        if (listado[i].checked) {
            listadoId.push(listado[i].getAttribute("id"));
        }
    }

    if (confirm(listadoId.length == 1 ? "¿Está seguro de que desea borrar este usuario?" : "¿Está seguro que desea borrar estos usuarios?")) {
        borrarPersonas(listadoId);
        alert(listadoId.length == 1 ? "Usuario borrado con éxito" : "Usuarios borrados con éxito")
        hideBtnBorrar();
    }
}

function borrarPersonas(listaID) {
    for (var i = 0; i < listaID.length; i++) {
        var llamada = new XMLHttpRequest();
        llamada.open("DELETE", "https://apipennypersonas.azurewebsites.net/api/Personas/" + listaID[i]);

        //Le damos la tarea de recargar la lista solo a la última llamada del listado de IDs
        if (i == listaID.length - 1)
        {
            llamada.onreadystatechange = function () {
                if (llamada.readyState == 4 && llamada.status == 200) {
                    //CargarListado
                    recargarListado();
                }
            };
        }
        

        llamada.send();
    }
}

function recargarListado() {
    //Guarringoneando
    document.getElementById("tbodyPersonas").innerHTML = "";
    cargarTabla();
}

function anadirPersona() {
    // Buscamos el tBody
    var table = document.getElementById("tbodyPersonas");
    // Crear un elemento tr
    var row = table.insertRow(0);
    // Insertar una celda (elemento td)
    var celda = row.insertCell(0);
    // Add some text to the new cells:
    celda.innerHTML = "";

    for (var i = 1; i < 7; i++) {
        celda = row.insertCell(i);
        var input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("name", "txtDatos");
        input.setAttribute("class", "form-control");
        celda.appendChild(input);
    }

    //Celda de Edit
    celda = row.insertCell(7);
    celda.innerHTML = "";

    showBtnAceptar();
    showBtnRechazar();
    hideBtnAnadir();
}

function aceptarPersona() {
    var arrayDatos = document.getElementsByName("txtDatos");
    for (var i = 0; i < arrayDatos.length; i++) {
        alert(arrayDatos[i].value);
    }
    document.getElementById("tbodyPersonas").deleteRow(0);
    hideBtnAceptar();
    hideBtnRechazar();
    showBtnAnadir();
}

function rechazarPersona() {
    document.getElementById("tbodyPersonas").deleteRow(0);
    hideBtnAceptar();
    hideBtnRechazar();
    showBtnAnadir();
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

function hideBtnBorrar() {
    var botonBorrar = document.getElementById("btnBorrar");
    botonBorrar.style.display = "none";
}

function showBtnBorrar() {
    var botonBorrar = document.getElementById("btnBorrar");
    botonBorrar.style.display = "";
}

function hideBtnAnadir() {
    var botonAnadir = document.getElementById("btnAnadir");
    botonAnadir.style.display = "none";
}

function showBtnAnadir() {
    var botonAnadir = document.getElementById("btnAnadir");
    botonAnadir.style.display = "";
}

function hideBtnAceptar() {
    var botonAceptar = document.getElementById("btnAceptar");
    botonAceptar.style.display = "none";
}

function showBtnAceptar() {
    var botonAceptar = document.getElementById("btnAceptar");
    botonAceptar.style.display = "";
}

function hideBtnRechazar() {
    var botonRechazar = document.getElementById("btnRechazar");
    botonRechazar.style.display = "none";
}

function showBtnRechazar() {
    var botonRechazar = document.getElementById("btnRechazar");
    botonRechazar.style.display = "";
}