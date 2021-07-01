function Message() {
    $("#file-name").val();
    var fileName = $("#file-name").val();
    if (!fileName) {
        alert("Please enter a directory!");
    } else {
        alert("The file has been accepted for processing!");
    }
}
    