"use strict";
navigator.geolocation.getCurrentPosition(setPosition);
function setPosition(position) {
    document.getElementById("longitude").value = (position.coords.longitude).toString().replace(".", ",");
    document.getElementById("latitude").value = (position.coords.latitude).toString().replace(".", ",");
}