var clientTimeZoneOffset = new Date().getTimezoneOffset();
var options = { year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: true };

const items = document.getElementsByClassName("date-output");
for (let i = 0; i < items.length; i++)
{
    var date = new Date(new Date(items[i].innerHTML).getTime() - clientTimeZoneOffset*60000).toLocaleString('en-US', options).replace(",", "");
    items[i].innerHTML = date;
} 

$('#submitButton').on('click', function () {
    const items = document.getElementsByClassName("date-input");
    for (let i = 0; i < items.length; i++) {
        var date = new Date(new Date(items[i].value).getTime()).toISOString().replace("Z", "");
        //var date = new Date(items[i].value).getTime().toISOString().substr(0, 19);
        items[i].value = date;
    }
});

//$('#submitButton').on('click', function () {
//    const items = document.getElementsByClassName("utc-date");
//    for (let i = 0; i < items.length; i++) {
//        var date = new Date(new Date(items[i].value).getTime() + clientTimeZoneOffset * 60000);
//        var a = date.getFullYear().toString() + "-" + date.getMonth() + "-0" + date.getDate() + "T" + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds() + "." + date.getMilliseconds();
//        items[i].value = a;
//    } 
//});


//function stopDefAction(evt) {
//    const items = document.getElementsByClassName("utc-date");
//    for (let i = 0; i < items.length; i++) {
//        var date = new Date(new Date(items[i].value).getTime()).toISOString().replace("Z","");
//        //var date = new Date(items[i].value).getTime().toISOString().substr(0, 19);
//        items[i].value = date;
//    }
//    evt.preventDefault();
//}

//document.getElementById('submitButton').addEventListener(
//    'click', stopDefAction, false
//);


