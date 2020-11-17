"use strict";

var images = $('.d-block').each(function () {
    var n = getRandomNumber(0, 360);
    $(this).css("-webkit-filter", "hue-rotate(" + n + "deg)");
    $(this).css("filter", "hue-rotate(" + n + "deg)");
});

function getRandomNumber(a, b)
{
    return Math.floor(Math.random() * (b - a + 1)+ a);
}