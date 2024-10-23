//cadastro de usuario ajax
const btnSave = document.getElementById('btnSalvar');
const url = "/Usuario/Create"

debugger;
function cadastrarUser() {
    var checkboxValue = $('#foo').is(':checked') ? 0 : 1;
    var dados = $('#usuarios').serialize() + '&Status=' + checkboxValue;
    debugger;
    $.ajax({
        url: url,
        type: 'POST',
        data: dados,
    })
        .done(function (data) {
            if (data.erro == true) {
                alert("Ocorreu um erro");
            }
            else
                alert("Usuario cadastrado");
        })
}
btnSave.addEventListener('click', cadastrarUser);