//Se define una variable de tipo datable, púlica para la página
var oTabla = $("#tblDepartamentos").DataTable();

jQuery(function () {
    $("#tblDepartamentos tbody").on("click", 'tr', function () {
        //Levanta el evento del click sobre la tabla
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html")
    //Registrar los botones para responder al evento click
    $("#btnInsertar").on("click", function () {
        EjecutarComandos("POST");
    });
    $("#btnActualizar").on("click", function () {
        EjecutarComandos("PUT");
    });
    $("#btnEliminar").on("click", function () {
        EjecutarComandos("DELETE");
    });
    $("#btnConsultar").on("click", function () {
        //Consultar();
    });
    LlenarComboPaises();
    LlenarTablaDepartamentos();
});
function EditarFila(DatosFila) {
    $("#txtCodigo").val(DatosFila.find('td:eq(2)').text());
    $("#txtNombre").val(DatosFila.find('td:eq(3)').text());
    let activo = DatosFila.find('td:eq(4)').text();
    if (activo == 'true') {
        $("#chkActivo").prop('checked', true);
    }
    else {
        $("#chkActivo").prop('checked', false);
    }
    $("#cboPais").val(DatosFila.find('td:eq(0)').text());
}
function LlenarComboPaises() {
    LlenarComboXServicios("http://localhost:53634/api/Paises", "#cboPais");
}
function LlenarTablaDepartamentos() {
    LlenarTablasXServicio("http://localhost:53634/api/Departamento", "#tblDepartamentos");
}
async function EjecutarComandos(Comando) {
    let Codigo = $("#txtCodigo").val();
    let Nombre = $("#txtNombre").val();
    let Activo = $("#chkActivo").prop('checked');
    let CodigoPais = $("#cboPais").val();

    let DatosDepartamento = {
        Codigo: Codigo,
        Nombre: Nombre,
        Activo: Activo,
        CodigoPais: CodigoPais
    }

    //Invocamos el servicio a través del fetch, usando el método fetch de javascript
    try {
        const Respuesta = await fetch("http://localhost:53634/api/Departamento",
            {
                method: Comando,
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(DatosDepartamento)
            });
        const Rpta = await Respuesta.json();
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(Rpta);
        LlenarTablaDepartamentos();
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}