let buttonRemove = document.getElementsByClassName("button-link-remover");
let confirmOverlay = document.getElementsByClassName("confirm-overlay");

function showConfirmOverlay() {
    confirmOverlay[0].style.display = "flex";
}

function hideConfirmOverlay() {
    confirmOverlay[0].style.display = "none";
}

buttonRemove[0].addEventListener("click", showConfirmOverlay);
buttonConfirm[0].addEventListener("click", hideConfirmOverlay);
