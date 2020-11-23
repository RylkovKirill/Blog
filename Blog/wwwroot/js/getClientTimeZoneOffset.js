"use strict";
var clientTimeZoneOffset = new Date().getTimezoneOffset();
var cookieValue = encodeURIComponent(clientTimeZoneOffset);

document.cookie = 'ClientTimeZone=' + cookieValue + ';path=/';
