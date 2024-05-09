let buttonRemove = document.getElementsByClassName("button-link-remover");
let confirmOverlay = document.getElementsByClassName("confirm-overlay");

function showConfirmOverlay() {
    confirmOverlay[0].style.display = "flex";
}

function hideConfirmOverlay() {
    confirmOverlay[0].style.display = "none";
}

// Adiciona o EventListener a todos os botões de classe "button-link-remover"
for (let i = 0; i < buttonRemove.length; i++) {
    buttonRemove[i].addEventListener("click", showConfirmOverlay);
}

for (let i = 0; i < buttonConfirm.length; i++) {
    buttonConfirm[i].addEventListener("click", hideConfirmOverlay);
}