$(document).ready(function () {
    var emailreg = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
    $(".botonX").click(function () {
        $(".errorX").remove();
        if ($(".fcha").val() == "") {
            $(".fcha").focus().after("<span class='errorX'>Llenar</span>");
            return false;
        } else if ($(".naci").val() == "") {
            $(".naci").focus().after("<span class='errorX'>Llenar</span>");
            return false;
        } else if ($(".tdoc").val() == "") {
            $(".tdoc").focus().after("<span class='errorX'>Llenar</span>");
            return false;
        } else if ($(".ndoc").val() == "") {
            $(".ndoc").focus().after("<span class='errorX'>Llenar</span>");
            return false;
        }
    });

    $(".fcha, .naci, .tdoc, .ndoc").keyup(function () {
        if ($(this).val() != "") {
            $(".errorX").fadeOut();
            return false;
        }
    });
//    $(".email").keyup(function () {
//        if ($(this).val() != "" && emailreg.test($(this).val())) {
//            $(".errorX").fadeOut();
//            return false;
//        }
//    });
});