function toggleFormpage(formLast, formNext) {

    document.getElementById(formLast).style.display = "none";
    document.getElementById(formNext).style.display = "block";
}



function validatePassword() {
    var kodeord = document.getElementById("kodeord");
    var gkodeord = document.getElementById("gkodeord");
    console.log(kodeord.value);
    console.log(gkodeord.value);
    if (kodeord.value !== gkodeord.value) {
        gkodeord.setCustomValidity("Det er ikke det samme kodeord!!");
        return false;
    } else {
        return true;
    }
}

gkodeord.onchange = validatePassword;
gkodeord.onkeyup = validatePassword;