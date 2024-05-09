var btn = document.getElementById("gestao-mod");
var div = document.getElementById("div-menu-sus");
btn.addEventListener("click", function () {
    var div = document.getElementById("div-menu-sus");

    if (div.style.display === "none") {
        div.style.display = "flex";
    }
    else {
        div.style.display = "none";
    }
});

$(document).on('click', function (e) {
    // Verifica se o clique ocorreu no botão ou em qualquer de seus elementos filhos
    if (!$(e.target).closest(btn).length) {
        // Se não foi no botão, altera o estilo para "none"
        $(div).css('display', 'none');
    }
});

