﻿function mascaraCPF(cpf) {
    // Remove caracteres não numéricos
    cpf.value = cpf.value.replace(/\D/g, '');

    // Aplica a máscara
    cpf.value = cpf.value.replace(/(\d{3})(\d)/, '$1.$2');
    cpf.value = cpf.value.replace(/(\d{3})(\d)/, '$1.$2');
    cpf.value = cpf.value.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
}

function calcularDigito(cpf, peso) {
    let soma = 0;
    for (let i = 0; i < peso; i++) {
        soma += Number(cpf[i]) * (peso + 1 - i);
    }
    const resto = (soma * 10) % 11;
    return resto === 10 ? 0 : resto;
}

function validarCPF(cpf) {
    const regex = /^(?!0{11})(\d{3}\.\d{3}\.\d{3}-\d{2})$/;
    if (!regex.test(cpf)) return false;

    cpf = cpf.replace(/\D/g, '');
    const digito1 = calcularDigito(cpf, 9);
    const digito2 = calcularDigito(cpf, 10);
    return cpf[9] == digito1 && cpf[10] == digito2;
}
let msgCPF = document.getElementById('mensagem'),
    inputStatus = document.getElementById('foo'),
    inputTipo = document.getElementById('option-select'),
    btnSalvar = document.getElementById('btnSalvar');
document.getElementById('cpf').addEventListener('blur', function () {
    if (!validarCPF(this.value)) {
        inputTipo.setAttribute('disabled', true);
        inputStatus.setAttribute('disabled', true);
        btnSalvar.setAttribute('disabled', true);
        msgCPF.innerText = 'CPF inválido.';
        msgCPF.style.color = "#ff1010"
    } else {
        inputTipo.removeAttribute('disabled', true);
        inputStatus.removeAttribute('disabled', true);
        btnSalvar.removeAttribute('disabled', true);
        msgCPF.innerText = 'CPF válido.';
        msgCPF.style.color = "#00a50e"
    }
});