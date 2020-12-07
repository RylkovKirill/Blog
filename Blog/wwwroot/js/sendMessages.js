"use strict";

const commentItems = ['<div  class="box box_left"><p class="card-text">',
    '<div  class="box box_right"><p class="card-text">',
    '</p><div class="card text-white bg-info mb-3 w-100"><div class="card-body"><h5 class="card-title">',
    '</h5><p class="card-text text-right"><small class="text">',
    '</small></p></div></div></div>'];

var messageConnection = new signalR.HubConnectionBuilder().withUrl("/messages").build();
document.getElementById("send").disabled = true;
messageConnection.start().then(AddToGroup);
document.getElementById("send").addEventListener("click", SendComment);
messageConnection.on("Send", AddComment);
const a = currentUserName;

function AddComment(userName, content, postedDate) {
    let isCurrentUser = userName === a
    var clientTimeZoneOffset = new Date().getTimezoneOffset();

    var options = { year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: true };
    var date = new Date(postedDate - clientTimeZoneOffset).toLocaleString('en-US', options).replace(",", "");
    var comments = document.getElementById("comments");
    var li = document.createElement("div");
    if (!isCurrentUser) {
        li.innerHTML = commentItems[0] + userName + commentItems[2] + content + commentItems[3] + date + commentItems[4];
    }
    else {
        li.innerHTML = commentItems[1] + userName + commentItems[2] + content + commentItems[3] + date + commentItems[4];
    }
    comments.appendChild(li);
    var comments = document.getElementById("comments");
    objDiv.scrollTop = comments.scrollHeight;
}


function AddToGroup() {
    document.getElementById("send").disabled = false;
    var postId = document.getElementById("postId").value;
    messageConnection.invoke("AddToGroup", postId)
}

function SendComment(event) {
    var postId = document.getElementById("postId").value;
    var content = document.getElementById("content").value;
    messageConnection.invoke("SendComment", postId, content);
    //$("#comments").load("dialogsList/", function () {
    //    $(".box:last").addClass('box_right');
    //})
    event.preventDefault();
}