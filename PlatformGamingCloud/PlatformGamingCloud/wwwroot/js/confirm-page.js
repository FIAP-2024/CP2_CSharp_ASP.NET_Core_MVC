﻿let buttonRemove = document.getElementsByClassName("button-link-remover");
let confirmOverlay = document.getElementsByClassName("confirm-overlay");


function showConfirmOverlay() {
    confirmOverlay[0].style.display = "flex";
}

function hideConfirmOverlay() {
    confirmOverlay[0].style.display = "none";
}



for (let i = 0; i < buttonRemove.length; i++) {
    buttonRemove[i].addEventListener("click", showConfirmOverlay);
}

function showAlertMessage() {
    document.getElementById("alert-message").style.display = "flex";
}

function hideAlertMessage() {
    setTimeout(document.getElementById("alert-message").style.display = "none", 5000)
}