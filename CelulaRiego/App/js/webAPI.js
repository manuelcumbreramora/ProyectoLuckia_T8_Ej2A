//DIRECCIÓN LOCAL
var raizUrl = '';

/*USUARIOS*/

function enviarRegistro(usuario, password) {
    $.ajax({
        url: raizUrl + '/api/usuarios/registro',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { nombre: usuario, pass: password },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    localStorage.setItem("idUsuario", objeto.data[0].id);
                    location.href = "../App/Monedero/IngresarDinero.html"
                } else {
                    alert('El usuario no ha llegado sin id.');
                }
            } else {
                alert('El usuario no ha sido guardado.');
            }
        }
    });
}

function enviarInicioSesion(usuario, password) {
    $.ajax({
        url: raizUrl + '/api/usuarios/inicioSesion',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { nombre: usuario, pass: password },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    localStorage.setItem("idUsuario", objeto.data[0].id);
                    location.href = "../App/Monedero/VerMonedero.html"
                } else {
                    alert('Error de conexión a BBDD.');
                }
            } else {
                alert('Usuario Incorrecto.');
            }
        }
    });
}

function generarSesion() {
    location.href = "../App/Usuario/registroUsuario.html"
}

function enviarMonedero(ingreso, divisa) {
    var id = localStorage.getItem("idUsuario");
    $.ajax({
        url: raizUrl + '/api/monedero/registro',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { importeMonedero: ingreso, divisaMonedero: divisa, idUsuario : id },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    localStorage.setItem("idMonedero", objeto.data[0].id);
                    location.href = "../App/Monedero/VerMonedero.html"
                } else {
                    alert('El monedero ha llegado sin id.');
                }
            } else {
                alert('El monedero no ha sido guardado.');
            }
        }
    });
}

function consultarMonedero() {
    var id = localStorage.getItem("idMonedero");
    $.ajax({
        url: raizUrl + '/api/monedero/consultar',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { idMonedero: id },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    localStorage.setItem("idMonedero", objeto.data[0].id);
                    //$('#saldo').val(objeto.data[0].saldo);
                } else {
                    alert('El monedero ha llegado sin id.');
                }
            } else {
                alert('El monedero no ha sido guardado.');
            }
        }
    });
}

function enviarTransaccion(ingreso, tipo) {
    var id = localStorage.getItem("idUsuario");
    $.ajax({
        url: raizUrl + '/api/transaccion/registro',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { importeTransaccion: ingreso, tipoTransaccion: tipo, idUsuario: id },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    localStorage.setItem("idTransaccion", objeto.data[0].id);
                    location.href = "../App/Monedero/VerMonedero.html"
                } else {
                    alert('El monedero ha llegado sin id.');
                }
            } else {
                alert('El monedero no ha sido guardado.');
            }
        }
    });
}


function historialTransaccion() {
    var id = localStorage.getItem("idUsuario");
    $.ajax({
        url: raizUrl + '/api/transaccion/listarHistorialTransacciones',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { idUsuario: id },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    localStorage.setItem("idTransaccion", objeto.data[0].id);
                    //recorrer los datos y mostrarlos con DOM -->  posible solucion 1 ASP TABLE DE MANUEL
                    // --> posible soulción 2 INNERHTML

                } else {
                    alert('El monedero ha llegado sin id.');
                }
            } else {
                alert('El monedero no ha sido guardado.');
            }
        }
    });
}

function viewTransaccion() {
    location.href = "../App/Transaccion/registroTransaccion.html"
}

function viewMonederoCrear() {
    location.href = "../App/Monedero/IngresarDinero.html"
}