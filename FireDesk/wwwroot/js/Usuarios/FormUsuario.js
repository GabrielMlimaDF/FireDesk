function mostrarModal() {
    document.getElementById("modalOverlay").style.display = "block";
    document.getElementById("modal").style.display = "flex";
}
function fecharModal() {
    document.getElementById("modalOverlay").style.display = "none";
    document.getElementById("modal").style.display = "none";
    document.getElementById('usuarios').reset();
}
const btnCheckbox = document.getElementById('foo');
const statusSpan = document.getElementById('ativoInativo');
function statusAtivoInativo() {
    const checkbox = document.getElementById('foo');
    checkbox.checked ? statusSpan.textContent = "Ativo" : statusSpan.textContent = "Inativo";
}
btnCheckbox.addEventListener("click", statusAtivoInativo);

//função para mostrar caixa Tipo de usuario
const lista = document.getElementById('cx-lista');
const optionSelect = document.getElementById('option-select');
//mostrar e ocultar após seleção
optionSelect.addEventListener('change', function () {
    lista.style.display = this.checked ? 'block' : 'none';
});
let inputSelectTipo = document.querySelectorAll('.li-option input'),
    selectValue = document.getElementById('selected-value')

inputSelectTipo.forEach(input => {
    input.addEventListener('click', event => {
        selectValue.textContent = input.dataset.label
        lista.style.display = 'none'
        optionSelect.checked = false
    })
})