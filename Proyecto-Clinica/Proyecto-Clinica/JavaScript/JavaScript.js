//validacion para el dni, permite solo numeros con longitud maxima de 8 caracteres
function soloNumeros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    var textBox = document.getElementById('<%= txtDniEdit.ClientID %>');
    if (textBox.value.lenght >= 8) {
        return false;
    }
    return true;

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


