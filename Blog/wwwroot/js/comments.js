"use strict";

const commentItems = ['<div class="card border-dark mb-3 w-50"><div class="card-header"><p class="card-text">',
    '</p></div><div class="card-body"><p class="card-text">',
    '</p><p class="card-text text-right"><small class="text-muted">',
    '</small></p></div></div>'];

var connection = new signalR.HubConnectionBuilder().withUrl("/comment").build();
document.getElementById("send").disabled = true;

connection.start().then(AddToGroup);
document.getElementById("send").addEventListener("click", Send);
connection.on("Send", AddComment);

function AddComment(userName, content, postedDate)
{
    var comments = document.getElementById("comments")
    comments.insertAdjacentHTML("afterbegin", commentItems[0] + userName + commentItems[1] + content + commentItems[2] + postedDate + commentItems[3]);
}

function AddToGroup()
{
    document.getElementById("send").disabled = false;
    var postId = document.getElementById("postId").value;
    connection.invoke("AddToGroup", postId)
}

function Send(event)
{
    var postId = document.getElementById("postId").value;
    var content = document.getElementById("content").value;
    connection.invoke("SendComment", postId, content)
    event.preventDefault();
}