function mostrarModal() {
    document.getElementById("modalOverlay").style.display = "block";
    document.getElementById("modal").style.display = "flex";
}
function fecharModal() {
    document.getElementById("modalOverlay").style.display = "none";
    document.getElementById("modal").style.display = "none";
}
const btnCheckbox = document.getElementById('foo');
const statusSpan = document.getElementById('ativoInativo');
function statusAtivoInativo() {
    const checkbox = document.getElementById('foo');
    checkbox.checked ? statusSpan.textContent = "Ativo" : statusSpan.textContent = "Inativo";
}
btnCheckbox.addEventListener("click", statusAtivoInativo);

//função para mostrar Tipo de usuario
document.getElementById('option-select').addEventListener('change', function () {
    const lista = document.getElementById('cx-lista');
    lista.style.display = this.checked ? 'block' : 'none';
});