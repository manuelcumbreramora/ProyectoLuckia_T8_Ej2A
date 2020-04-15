//DIRECCIÓN LOCAL
var raizUrl = '';

/*USUARIOS*/

function indentificar(vnombre, vpass) {

    $.ajax({
        url: raizUrl + '/api/usuarios/indentificacion',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { nombre: vnombre, pass: vpass },
        success: function (objeto) {
            localStorage.setItem("idUsuario", objeto.data[0].id);
            localStorage.setItem("nombreUsuario", objeto.data[0].nombre);
        }
    });
}

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
                    //localStorage.setItem("idUsuario", objeto.data[0].id);
                    //localStorage.setItem("nombreUsuario", objeto.data[0].nombre);
                    //window.location.href = "partidos.html";
                } else {
                    alert('Error de conexión a BBDD.');
                }
            } else {
                alert('Usuario Incorrecto.');
            }
        }
    });
}

function enviarInicioSesion(usuario, password) {
    /*$.ajax({
        url: raizUrl + '/api/usuario/inicioSesion',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { nombre: usuario, pass: password },
        success: function (objeto) {
            //var usuario = objeto.data;
            if (objeto.data.length > 0) {
                if (parseInt(objeto.data[0].id) > 0) {
                    //localStorage.setItem("idUsuario", objeto.data[0].id);
                    //localStorage.setItem("nombreUsuario", objeto.data[0].nombre);
                    //window.location.href = "partidos.html";
                } else {
                    alert('Error de conexión a BBDD.');
                }
            } else {
                alert('Usuario Incorrecto.');
            }
        }
    });*/
    console.log(usuario, password);
    location.href = "../Transaccion/registroTransaccion.html"
}

function generarSesion() {
    location.href = "../App/Usuario/registroUsuario.html"
}
