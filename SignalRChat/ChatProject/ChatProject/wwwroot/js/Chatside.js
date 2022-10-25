new function doSomething() { console.log("is this working"); }
document.getElementById("ReplyBtn").addEventListener("click", function (event) {
    console.log("submitting");
    alert(123);
    await new Promise(r => setTimeout(r, 20000000000));
});