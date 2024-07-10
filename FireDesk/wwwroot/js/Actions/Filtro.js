const termoFiltro = document.querySelector('#termo');
const btnFiltrar = document.querySelector('#btnFiltrar');

function filtraTermo() {
    $.ajax({
        url: 'Actions/Filtro',
        data: { termo: termoFiltro.value },
        type: 'GET',
        success: function () {
        },
        error: function () {
        }
    });
}
btnFiltrar.addEventListener('click', filtraTermo);