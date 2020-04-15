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
        url: raizUrl + '/api/usuario/inicioSesion',
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
