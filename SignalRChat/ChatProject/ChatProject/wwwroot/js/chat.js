"use strict";
chatScrollToBottom();
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("ReplyBtn").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    new Notification("Ny besked fra " + user);
    var container = document.createElement("div");
    container.className = "ChatBeskedContainer";
    var beskeden = document.createElement("p");
    beskeden.className = "ChatBesked";
    beskeden.setAttribute('style', 'white-space: pre;');
    beskeden.textContent = "" + user + "\r\n \r\n" + message;
    container.appendChild(beskeden);
    document.getElementById("ChatBeskedOversigt").appendChild(container);
    chatScrollToBottom();
});

connection.start().then(function () {
    document.getElementById("ReplyBtn").disabled = false;
    var username = document.getElementById("SessionUser").textContent;
    connection.invoke("AddToGroup", username, "", "1");
}).catch(function (err) {
    return console.error(err.toString());
});


document.getElementById("ReplyBtn").addEventListener("click", function (event) {
    var username = document.getElementById("SessionUser").textContent;
    var message = document.getElementById("ReplyInput").value;
    var chatrumID = document.getElementById("chatrumID").textContent;
    connection.invoke("SendMessage", username, message, chatrumID).catch(function (err) {
        return console.error(err.toString());
    });
});

function chatScrollToBottom() {
    const out = document.getElementById("ChatBeskedOversigt");

    out.scrollTop = out.scrollHeight - out.clientHeight;
}
/*
//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

// set up message receival
connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

// organize data
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
*/