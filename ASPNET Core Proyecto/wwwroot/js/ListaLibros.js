var dataTable;

$(document).ready(function () {
    cargarTablaDatos();
});

function cargarTablaDatos() {
    dataTable = $('#DTCargar').DataTable({ // se caraga la tabla en la tabla del index con id DTCargar
        "ajax": { // se hace una llamada ajax
            "url": "/api/libro", // url dada en el controller
            "type": "GET",
            "datatype": "json"
        },
        "columns": [ // se construye la tabla
            { "data": "nombre", "width": "20%" },
            { "data": "autor", "width": "20%" },
            { "data": "isbm", "width": "20%" },
            {
                "data": "id",
                "render": function (data) { // se pasa el id que contiene data arriba
                    return `<div class="text-center">
                        <a href="/ListaLibros/Editar?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px;'>
                            Editar
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px;' onclick=Delete('/api/libro?id='+${data})>
                            Eliminar
                        </a>
                    </div>`;
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No se encontraron datos."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "¿Seguro de realizar esta acción?",
        text: "Una vez eliminada, no será posile recuperar esta información.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}