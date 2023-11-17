//Creamos una variable de tipo DataTable, con la tabla tblProductos
var oTabla = $("#tblProductos").DataTable();

jQuery(function () {
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
        Consultar();
    });
    //Invoca la función para llenar el combo
    LlenarComboTipoProducto();
    LlenarTablaProductos();
});

async function LlenarTablaProductos() {
    LlenarTablasXServicio("http://localhost:53634/api/Producto", "#tblProductos");
}
async function LlenarComboTipoProducto() {
    LlenarComboXServicios("http://localhost:53634/api/TipoProducto", "#cboTipoProducto");
}

/*
async function LlenarTablaProductos() {
    //Invocar el servicio que trae la lista de los tipos de producto
    try {
        const Respuesta = await fetch("http://localhost:53634/api/Producto",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //En Rpta, está el listado de los tipos de producto
        //Recorrer la lista para llenar la tabla con encabezado y datos
        var Columnas = [];
        NombresColumna = Object.keys(Rpta[0]);
        for (var i in NombresColumna) {
            Columnas.push({
                data: NombresColumna[i],
                title: NombresColumna[i]
            });
        }
        //Llena los datos de la tabla
        $("#tblProductos").DataTable({
            data: Rpta,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}
*/
/*
async function LlenarComboTipoProducto() {
    //Invocar el servicio que trae la lista de los tipos de producto
    try {
        const Respuesta = await fetch("http://localhost:53634/api/TipoProducto",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //En Rpta, está el listado de los tipos de producto
        //Recorrer la lista para agregarla al combo
        for (i = 0; i < Rpta.length; i++) {
            $("#cboTipoProducto").append('<option value=' + Rpta[i].Codigo + '>' + Rpta[i].Nombre + '</option>')
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}
*/