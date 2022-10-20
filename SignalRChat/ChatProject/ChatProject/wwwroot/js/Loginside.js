function toggleFormpage(formLast, formNext) {

    document.getElementById(formLast).style.display = "none";
    document.getElementById(formNext).style.display = "block";
}



function validatePassword() {
    var kodeordElem = document.getElementById("kodeord");
    var gkodeordElem = document.getElementById("gkodeord");
    var kodeord = kodeordElem.value;
    var gkodeord = gkodeordElem.value;
    console.log(kodeord);
    console.log(gkodeord);
    if (kodeord != gkodeord) {
        gkodeordElem.setCustomValidity("Det er ikke det samme kodeord!!");
        return false;
    } else {
        gkodeordElem.setCustomValidity("");
        return true;
    }
}

gkodeord.onchange = validatePassword;
