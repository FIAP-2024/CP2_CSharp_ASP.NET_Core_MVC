let buttonRemove = document.getElementsByClassName("button-link-remover");
let confirmOverlay = document.getElementsByClassName("confirm-overlay");

function showConfirmOverlay() {
    confirmOverlay[0].style.display = "flex";
}

function hideConfirmOverlay() {
    confirmOverlay[0].style.display = "none";
}
