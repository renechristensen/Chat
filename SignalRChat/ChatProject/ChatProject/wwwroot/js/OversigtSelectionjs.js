document.getElementById("Alias2").value = document.getElementById("aliasField").value;
document.getElementById("aliasField").onchange = function () {
    document.getElementById("Alias2").value = this.value;
};