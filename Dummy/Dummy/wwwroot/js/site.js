// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function ()
{
    $('#tablePeople').DataTable();

    $("#fullname").bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-Z ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    });
    $("#lastname").bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-Z ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    });
});
$('button#valuedata').click(function () {
    var url = 'https://localhost:44377' + $(this).attr("value");
    console.log(url);
    $('#ModalEdit').modal('show').find('.modal-body').load(url);
});

function ShowCreate() {
    var create = 'https://localhost:44377/Home/create';
    $('#exampleModal').modal('show').find('.modal-body').load(create);
}
function Operations() {
    var table = document.getElementById("myTable");
    var row = table.insertRow(0);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var sel = document.getElementById("select");
    var text = sel.options[sel.selectedIndex].text;

    var logContact = {
        IdTypeContact: document.getElementById("select").value,
        Contact: document.getElementById("dato").value,
        Document: document.getElementById("document").value
    }
    $.ajax({
        url: '/Home/ValidateContact',
        data: logContact,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            console.log(response);
            if (response === 003) {
                cell1.innerHTML = text, cell2.innerHTML = document.getElementById("dato").value;

                document.getElementById("dato").value = "";
            }
            if (response === 002) {
                alert("Ya cumpliste con el maximo de contactos para el tipo" + text);
            }
            if (response === 0) {
                alert("Ingrese un documento");
            }
            if (response === 004) {
                alert("El documento que Ingreso ya existe....");
            }
        },
        failure: function (response) {
            $('#result').html(response);
        }
    });
}