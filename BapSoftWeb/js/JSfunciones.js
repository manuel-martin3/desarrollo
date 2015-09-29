/*************************************************************************
formulario busqueda popup
*************************************************************************/
function cerrar() {
    $find('ModalPopupExtender1').hide();
}

function cerrar2() {
    $find('ModalPopupExtender2').hide();
}

function cerrartodo() {
    $find('ModalPopupExtender1').hide();
    $find('ModalPopupExtender2').hide();
}

function cerrar_popup() {
    $("#fondo_popup").css("display", "none");
}



function mueve_divbuscar() {
    //            var x = $(window).width();
    //            var y = $(window).height();
    //            var formx = $("#pnlEditData").width();
    //            var formy = $("#pnlEditData").height();
    //            posicionReal = $("#pnlEditData").offset();
    //            var x = posicionReal.top;
    //             var y = posicionReal.left;
    //            capa = $("#pnlEditData");
    //            var dimensiones = "";
    //            dimensiones += "Dimensiones internas: " + capa.innerWidth() + "x" + capa.innerHeight();
    //            dimensiones += "\nDimensiones externas: " + capa.outerWidth() + "x" + capa.outerHeight();
    //            alert(dimensiones);
    $("#pnlEditData").draggable({ containment: 'document' });
    var containment = $("#pnlEditData").draggable("option", "containment");
    $("#pnlEditData").draggable("option", "containment", 'document');
    /*$("#pnlEditData").draggable();*/

}

/*... funciones para validar datos*/
function esnulo(campo) { return (campo == null || campo == ""); }
function esnumero(campo) { return (!(isNaN(campo))); }
function eslongrucok(ruc) { return (ruc.length == 11); }
function esrucok(ruc) {
    return (!(esnulo(ruc) || !esnumero(ruc) || !eslongrucok(ruc) || !valruc(ruc)));
}
function trim(cadena) {
    cadena2 = "";
    len = cadena.length;
    for (var i = 0; i <= len; i++) if (cadena.charAt(i) != " ") { cadena2 += cadena.charAt(i); }
    return cadena2;
}

/*... funciones para validar datos numero de ruc*/
function valruc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length == 8) {
            suma = 0
            for (i = 0; i < valor.length - 1; i++) {

                digito = valor.charAt(i) - '0';
                /* aqui lo que no entiendo es - '0' no se que es, supongo que elimina los ceros, parece una resta pero como se va a restar si el chaart solo te devuelve un digito?
                Exactamente, al parecer, esto elimina los posibles ceros que existan dentro de los parametro que se ingresaron en el input*/
                if (i == 0) suma += (digito * 2)
                else suma += (digito * (valor.length - i))
            }
            resto = suma % 11;
            if (resto == 1) resto = 11;
            if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
                return true
            }
        } else if (valor.length == 11) {
            suma = 0
            x = 6
            for (i = 0; i < valor.length - 1; i++) {
                if (i == 4) x = 8
                digito = valor.charAt(i) - '0';
                x--
                if (i == 0) suma += (digito * x)
                else suma += (digito * x)
            }
            resto = suma % 11;
            resto = 11 - resto

            if (resto >= 10) resto = resto - 10;
            if (resto == valor.charAt(valor.length - 1) - '0') {
                return true
            }
        }
    }
    return false
}

function RUC(source, arguments) {
    if (!esrucok(arguments)) {
        arguments.IsValid = true;
    } else {
        arguments.IsValid = false;
    }
}

/*ESTILIZAR ONFOCUS DE CAJA DE TEXTO CADENA*/
function Change_txt(obj, evt) {
    if (evt.type == "focus") {
        obj.className = "textbox_form_onfoc";
    } else if (evt.type == "blur") {
        obj.className = "textbox_form";
    }
}

/*ESTILIZAR ONFOCUS DE CAJA DE TEXTO NUMERO*/
function Change_txt_n(obj, evt) {
    if (evt.type == "focus") {
        obj.className = "textbox_form_onfoc";
    } else if (evt.type == "blur") {
        obj.className = "textbox_form_n";
    }
}

/*ESTILIZAR ONFOCUS DE BOTON AÑADIR DETALLE*/
function Change_btnadd(obj, evt) {
    if (evt.type == "focus") {
        obj.src = "../../../Images/btn_additems_foc.jpg";
    } else if (evt.type == "blur") {
        obj.className = "";
    }
}

/* DAR FORMATO A UN NUMERO */
function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
    numero = parseFloat(numero);
    if (isNaN(numero)) {
        return "";
    }

    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }

    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }

    return numero;
}

//**FORMATO MONEDA
function formatCurrency(num) {
    num = num.toString().replace(/$|,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + '$' + num + '.' + cents);
}


/***BLOQUEAR BOTONES RETROCEDER DE NAVEGADOR*****/
// Para recoger eventos de teclas
//document.onkeydown = keyPressed;

function keyPressed(evt) {
    var retroceso = 8; // ASCII del retroceso

    //    if (document.all) {
    // Controlamos las pulsaciones del teclado y comparamos con retroceso
    if (event.keyCode == retroceso) {
        // Con event.keyCode anulamos la accion
        event.keyCode = 0;
        window.event.returnValue = false;
    }

    else if (event.ctrlKey) {
        if (event.keyCode == retroceso) {
            // Con event.keyCode anulamos la accion
            event.keyCode = 0;
            window.event.returnValue = false;
        }
    }
    //    }
}

//    valida key==45 el ingreso del signo negativo
function Numeros(e) {
    key = (document.all) ? e.keyCode : e.which;

    if (key < 48 || key > 57) {
        if (key == 8 || key == 47 || key == 45 || key == 44 || key == 46 || key == 0) {
            return true
        }
        else
        //alert(key);
            return false;
    }
}

//FUNCION PARA REEMPLAZAR TAB POR ENTER
function enterTo(e, number) {
    var intKey = window.Event ? e.which : e.KeyCode;
    if (intKey == 13) {
        var wow = document.getElementById("ContentPlaceHolder1_" + number);
        wow.focus();
        wow.select();
    }
}
function enterToTab1(e, number) {
    var intKey = window.Event ? e.which : e.KeyCode;
    if (intKey == 13) {
        var wow = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_" + number);
        wow.focus();
        wow.select();
    }
}
function enterToTab2(e, number) {
    var intKey = window.Event ? e.which : e.KeyCode;
    if (intKey == 13) {
        var wow = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_" + number);
        wow.focus();
        wow.select();
    }
}
function enterToTab3(e, number) {
    var intKey = window.Event ? e.which : e.KeyCode;
    if (intKey == 13) {
        var wow = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_" + number);
        wow.focus();
        wow.select();
    }
}