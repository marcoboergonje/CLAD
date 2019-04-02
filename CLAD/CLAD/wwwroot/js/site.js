$(document).ready(function () {
    $('#jquerytable').DataTable();
});

$(document).ready(function () {
    $("#filter").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#consultant *").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});