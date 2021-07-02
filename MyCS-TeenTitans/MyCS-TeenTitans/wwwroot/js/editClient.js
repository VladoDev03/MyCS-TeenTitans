$(document).ready(function () {
    fetch("https://localhost:44369/single") //endpoint
        .then(response => response.json())
        .then(function (data) {
        $("#first-name").val(data.firstName);
            
    })
})
