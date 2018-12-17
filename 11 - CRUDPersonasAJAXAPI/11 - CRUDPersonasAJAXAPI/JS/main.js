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
        td.setAttribute("name", "fila" + data[i].idPersona)

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
            if (prop != "idPersona") {
                td = document.createElement("td");
                td.setAttribute("name", "fila" + data[i].idPersona)
                var textoCelda = document.createTextNode(prop != "fechaNac" ? data[i][prop] : data[i][prop].split("T")[0]);
                td.appendChild(textoCelda);
                tr.appendChild(td);
            }
        }

        //Agregamos el botón Edit, que viene a partir de este HTML:
        //<p title="Edit"><button class="btn btn-primary btn-xs"><span class="glyphicon glyphicon-pencil"></span></button></p>
        td = document.createElement("td");
        td.setAttribute("name", "fila" + data[i].idPersona)
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
    var fila = "fila" + this.value;
    var columnas = document.getElementsByName(fila);
    var arrayDatos = new Array();

    columnas[0].innerHTML = "";
    var idDepartamento = columnas[1].innerHTML; arrayDatos.push(idDepartamento);
    var nombre = columnas[2].innerHTML; arrayDatos.push(nombre);
    var apellidos = columnas[3].innerHTML; arrayDatos.push(apellidos);
    var fechaNac = columnas[4].innerHTML; fechaNac = fechaNac.split("T")[0]; arrayDatos.push(fechaNac);
    var direccion = columnas[5].innerHTML; arrayDatos.push(direccion);
    var telefono = columnas[6].innerHTML; arrayDatos.push(telefono);
    columnas[7].innerHTML = "";

    //Ponemos los inputs
    columnas[1].innerHTML = "";
    var input = document.createElement("input");
    input.setAttribute("type", "number");
    input.setAttribute("name", "txtDatos");
    input.setAttribute("class", "form-control");
    input.setAttribute("value", idDepartamento);
    columnas[1].appendChild(input);

    for (var i = 2; i < 7; i++) {
        columnas[i].innerHTML = "";
        var input = document.createElement("input");
        input.setAttribute("type", i != 4 ? "text" : "date");
        input.setAttribute("name", "txtDatos");
        input.setAttribute("class", "form-control");
        input.setAttribute("value", arrayDatos[i-1])
        columnas[i].appendChild(input);
    }

    disableAllEditButtons();
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
        hideBtnAceptar();
        hideBtnRechazar();
        showBtnAnadir();
    }
}

function borrarPersonas(listaID) {
    for (var i = 0; i < listaID.length; i++) {
        var llamada = new XMLHttpRequest();
        llamada.open("DELETE", "https://apipennypersonas.azurewebsites.net/api/Personas/" + listaID[i]);

        //Le damos la tarea de recargar la lista solo a la última llamada del listado de IDs
        if (i == listaID.length - 1) {
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

function anadirPersona() {
    // Buscamos el tBody
    var table = document.getElementById("tbodyPersonas");
    // Crear un elemento tr
    var row = table.insertRow(0);
    // Insertar una celda (elemento td)
    var celda = row.insertCell(0);
    // Add some text to the new cells:
    celda.innerHTML = "";

    //Insertamos la celda de número (idDepartamento)
    celda = row.insertCell(1);
    var input = document.createElement("input");
    input.setAttribute("type", "number");
    input.setAttribute("name", "txtDatos");
    input.setAttribute("class", "form-control");
    celda.appendChild(input);

    for (var i = 2; i < 7; i++) {
        celda = row.insertCell(i);
        var input = document.createElement("input");
        input.setAttribute("type", i != 4 ? "text":"date");
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
    if (checkPersonInfo()) {
        var arrayDatos = document.getElementsByName("txtDatos");
        var idDepartamento = arrayDatos[0].value;
        var nombre = arrayDatos[1].value;
        var apellidos = arrayDatos[2].value;
        var fechaNac = arrayDatos[3].value;
        var direccion = arrayDatos[4].value;
        var telefono = arrayDatos[5].value;
        var persona = new Persona(0, nombre, apellidos, fechaNac, direccion, telefono, idDepartamento);
        var json = JSON.stringify(persona);

        //Hacemos la llamada POST a la API
        var llamada = new XMLHttpRequest();
        llamada.open("POST", "https://apipennypersonas.azurewebsites.net/api/Personas/", true);
        llamada.setRequestHeader("Content-Type", "application/json");

        llamada.onreadystatechange = function () {
            if (llamada.readyState == 4 && llamada.status == 200) {
                alert("¡Persona creada correctamente!");

                //CargarListado
                recargarListado();

                hideBtnAceptar();
                hideBtnRechazar();
                showBtnAnadir();
            }
        };

        llamada.send(json);
    }
}

function rechazarPersona() {
    document.getElementById("tbodyPersonas").deleteRow(0);
    hideBtnAceptar();
    hideBtnRechazar();
    showBtnAnadir();
}

function checkPersonInfo() {
    var arrayDatos = document.getElementsByName("txtDatos");
    var idDepartamento = arrayDatos[0].value;
    var nombre = arrayDatos[1].value;
    var apellidos = arrayDatos[2].value;
    var fechaNac = arrayDatos[3].value;
    var direccion = arrayDatos[4].value;
    var telefono = arrayDatos[5].value;
    var esValido = true;

    if (idDepartamento == 0) {
        alert("¡La ID del departamento no puede estar vacía ni ser 0!");
        esValido = false;
    }
    else if (nombre == "") {
        alert("¡El nombre no puede estar vacío!");
        esValido = false;
    }
    else if (apellidos == "") {
        alert("¡Los apellidos no pueden estar vacíos!");
        esValido = false;
    }
    else if (fechaNac == "") {
        alert("¡La fecha de nacimiento no puede estar vacía!");
        esValido = false;
    }
    else if (new Date(fechaNac) > new Date()) {
        alert("¡Fecha inválida! No creo que vayas a nacer en el futuro...");
        esValido = false;
    }
    else if (direccion == "") {
        alert("¡La dirección no puede estar vacía!");
        esValido = false;
    }
    else if (telefono == "") {
        alert("¡El teléfono no puede estar vacío!");
        esValido = false;
    }

    return esValido;
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

function recargarListado() {
    //Guarringoneando
    document.getElementById("tbodyPersonas").innerHTML = "";
    cargarTabla();
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

function disableAllEditButtons() {
    var botones = document.getElementsByName("btnEdit");
    for (var i = 0; i < botones.length; i++) {
        botones[i].disabled = true;
    }
}

function enableAllEditButtons() {
    var botones = document.getElementsByName("btnEdit");
    for (var i = 0; i < botones.length; i++) {
        botones[i].disabled = false;
    }
}