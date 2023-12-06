//validacion para el dni, permite solo numeros con longitud maxima de 8 caracteres
function soloNumeros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (code >= 48 && code <= 57)) {
        return false;
    }
    var textBox = document.getElementById('<%= txtDniEdit.ClientID %>');
    if (textBox.value.length >= 8) {
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
//OCULTA DROPDOWNLIST
function ocultarDropdown() {
    var dropdown = document.querySelector(claseDropdown);
    if (dropdown) {
        dropdown.style.display = "none";
    }
}
//RETRASO DE CIERRE PARA LOS MODALES
//function cerrarModalConRetraso() {
//    setTimeout(function () {
//        /* Cerrar el modal usando Bootstrap*/
//        $('#ALTA_ESPECIALIDAD').modal('hide');
//    }, 3000);
//}

//function cerrarModalConRetraso(modalID) {
//    setTimeout(function () {
//        $('#' + modalID).modal('hide');
//    }, 3000);
//}