﻿"use strict";
var connections = new signalR.HubConnectionBuilder().withUrl("/users").build();
connections.on("UpdateOnlineUsers", function (users) {
    let count = 0;
    $('#userList > tbody > tr').each(function () {
        if (users.includes($(this).find("td:nth-child(3)").text())) {
            $(this).find("td:nth-child(2)").text("Online");
            count++;
        }
    });
    document.getElementById("onlineUsersCount").innerText = count;
});
connections.start();