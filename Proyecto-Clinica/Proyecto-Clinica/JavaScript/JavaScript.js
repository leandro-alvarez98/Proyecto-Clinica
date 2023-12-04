//validacion para el dni, permite solo numeros con longitud maxima de 8 caracteres
//function soloNumeros(evt) {
//    var charCode = (evt.which) ? evt.which : event.keyCode;
//    if (charCode > 31 && (code >= 48 && code <= 57)) {
//        return false;
//    }
//    var textBox = document.getElementById('<%= txtDniEdit.ClientID %>');
//    if (textBox.value.length >= 8) {
//        return false;
//    }
//    return true;

//}

//-------------------
function soloNumeros(evt) {

    // code is the decimal ASCII representation of the pressed key.
    var code = (evt.which) ? evt.which : evt.keyCode;

    if (code == 8) { // backspace.
        return true;
    } else if (code >= 48 && code <= 57) { // is a number.
        return true;
    } else { // other keys.
        return false;
    }
}

//TEST DEL DESPLAZAMIENTO AL FOOTER

$(document).ready(function () {
    $('a.nav-link').click(function (event) {
        event.preventDefault();

        var targetPosition = $('#footer').offset().top;

        $('html, body').animate({
            scrollTop: targetPosition
        }, 500);
    });
});


