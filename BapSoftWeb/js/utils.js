function PageInit() {
    $dialog = $('<div></div>')
       .dialog({
           autoOpen: true,
           title: 'Dialogo Básico',
           modal: true
       });
}

//Función que muestra el div flotante con el mensaje
function MostrarMensajeModal(mensajeTexto) {
    $dialog.text(mensajeTexto);
    $dialog.dialog('open');
}