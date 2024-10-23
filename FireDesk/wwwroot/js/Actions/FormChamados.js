// Função para mostrar o modal e a sobreposição
function mostrarModal() {
    document.getElementById("modalOverlay").style.display = "block";
    var modal = document.getElementById("modal");
    modal.style.right = '0';
}

// Função para ocultar o modal e a sobreposição
function fecharModal() {
    document.getElementById("modalOverlay").style.display = "none";
    var modal = document.getElementById("modal");
    modal.style.right = '-100%';
}
//Função para o select
let select = document.querySelector('.select2'),
    selectedValue = document.getElementById('selected-value'),
    optionsViewButton = document.getElementById('options-view-button'),
    inputsOptions = document.querySelectorAll('.option input')

inputsOptions.forEach(input => {
    input.addEventListener('click', event => {
        selectedValue.textContent = input.dataset.label
        const isMouseOrTouch =
            event.pointerType == "mouse" ||
            event.pointerType == "touch"
        isMouseOrTouch && optionsViewButton.click()
    })

    input.addEventListener('keydown', event => {
        if (event.key === "Enter") {
            selectedValue.textContent = input.dataset.label
            optionsViewButton.click()
        }
    })
})

const inputElement = document.querySelector('#search-select');
let listElement = document.querySelector("ul"),
    itemElement = document.querySelectorAll('li.option');
inputElement.addEventListener('input', (e) => {
    let inputed = e.target.value.toLowerCase()
    const elementP = document.getElementById("options").getElementsByTagName("p");
    if (elementP.length > 0) {
        for (let i = 0; i < elementP.length; i++) {
            elementP[i].remove();
        }
    }
    var cont = 0;
    itemElement.forEach((li) => {
        let text = li.textContent.toLowerCase()
        if (text.includes(inputed)) {
            li.style.display = "block"
        }
        else {
            li.style.display = "none"
            cont++
        }
    })
    if (cont === itemElement.length) {
        const p = document.createElement("p");
        p.innerHTML = "Não encontrado";
        document.getElementById("options").appendChild(p);
    }
})
//função para envio de formulário
let btnSubmit = document.getElementById("btn-submit");
const url = "/Actions/CreateTicket"

function save() {
    debugger;
    fecharModal();
    $.ajax({
        url: url,
        type: 'POST',
        data: $('#desk').serialize(),
    })
        .done(function (data) {
            debugger;
            if (data.erro == true) {
                const divEspecifica = document.getElementById('modal');
                const novoHTML = '<div id="b1" class="box-sucess">' +
                    '<div class="sucess-title">Acompanhe o processo</div>' +
                    '<div class="status-loading">' +
                    '<span><strong>' +

                    data.resultado +
                    '</strong></span > ' +
                    '<img src="/img/erro.svg"/>' +
                    '</div>' +
                    '</div>';
                divEspecifica.insertAdjacentHTML('afterend', novoHTML);
                setTimeout(function () {
                    const b = document.querySelector("#b1");
                    b.remove();
                }, 5000);
            }
            else {
                const divEspecifica = document.getElementById('modal');
                const novoHTML = '<div id="b1" class="box-sucess">' +
                    '<div class="sucess-title">Acompanhe o processo</div>' +
                    '<div class="status-loading">' +
                    '<span><strong>Processando...</strong></span>' +
                    '<img src="/img/Pulse-1s-200px.gif"/>' +
                    '</div>' +
                    '</div>';
                divEspecifica.insertAdjacentHTML('afterend', novoHTML);

                let formReset = document.querySelector('#desk');
                formReset.reset();
                setTimeout(function () {
                    const b = document.querySelector("#b1");
                    b.remove();
                    const divEspecifica = document.getElementById('modal');
                    const novoHTML = '<div id="b2" class="box-sucess">' +
                        '<div class="sucess-title">Acompanhe o processo</div>' +
                        '<div class="status-loading">' +
                        '<span><strong>Sucesso na operação.</strong></span>' +
                        '<img src="/img/check.svg"/>' +
                        '</div>' +
                        '</div>';
                    divEspecifica.insertAdjacentHTML('afterend', novoHTML);
                }, 3000);
                setTimeout(function () {
                    const b = document.querySelector("#b2");
                    b.remove();
                }, 5000);
            }
        })
}
btnSubmit.addEventListener('click', save);