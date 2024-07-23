"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/timehub").build();

connection.on("ReceiveTime", function (time) {
    document.getElementById("serverTime").innerText = time;
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

