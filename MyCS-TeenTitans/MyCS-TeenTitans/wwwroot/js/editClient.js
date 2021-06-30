$(document).ready(function () {
    fetch("https://jsonplaceholder.typicode.com/todos/1") //endpoint
        .then(response => response.json())
        .then(function (data) {
        //$("#first-name").val(data.firstName);
            $("#first-name").val("Ivan");
            $("#last-name").val("Ivanov");            
    })
})
