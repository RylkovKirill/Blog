"use strict";

const commentItems = ['<div class="card border-dark mb-3 w-50"><div class="card-header"><p class="card-text">',
    '</p></div><div class="card-body"><p class="card-text">',
    '</p><p class="card-text text-right"><small class="text-muted">',
    '</small></p></div></div>'];

var commentConnection = new signalR.HubConnectionBuilder().withUrl("/comments").build();
document.getElementById("send").disabled = true;
commentConnection.start().then(AddToGroup);
document.getElementById("send").addEventListener("click", SendComment);
commentConnection.on("Send", AddComment);

function AddComment(userName, content, postedDate) {
    var clientTimeZoneOffset = new Date().getTimezoneOffset();

    var options = { year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: true };
    var date = new Date(postedDate - clientTimeZoneOffset).toLocaleString('en-US', options).replace(",","");
    var comments = document.getElementById("comments");
    comments.insertAdjacentHTML("afterbegin", commentItems[0] + userName + commentItems[1] + content + commentItems[2] + date + commentItems[3]);
}


function AddToGroup() {
    document.getElementById("send").disabled = false;
    var postId = document.getElementById("postId").value;
    commentConnection.invoke("AddToGroup", postId)
}

function SendComment(event) {
    var postId = document.getElementById("postId").value;
    var content = document.getElementById("content").value;
    commentConnection.invoke("SendComment", postId, content)
    event.preventDefault();
}