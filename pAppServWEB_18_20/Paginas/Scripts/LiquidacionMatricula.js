$(document).ready(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");
    $("#btnCalcular").click(function () {
        CalcularValorMatricula();
    });
});

async function CalcularValorMatricula() {
    //Captura datos de entrada
    let AsignturasBasicas = $("#txtComponentesBasicos").val();
    let AsignaturasComplementarias = $("#txtComplementarias").val();
    let AsignaturasEspecializadas = $("#txtEspecializadas").val();

    //Json es un lenguaje que permite gestionar datos con formato de estructura Clave - Valor, y que puede contener estructuras complejas dentro de sus valores
    let DatosLiquidacion = {
        AsignaturasBasicas: AsignturasBasicas,
        AsignaturasComplementarias: AsignaturasComplementarias,
        AsignaturasEspecializadas: AsignaturasEspecializadas
    }
    try {
        const RespuestaServicio = await fetch("http://localhost:53634/api/LiquidacionMatricula", {  
            method: "POST",
            mode: "cors",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(DatosLiquidacion)
        });
        //Leo la respuesta del servicio en formato json y la guardo en una variable
        const Respuesta = await RespuestaServicio.json();
        //alert(Respuesta.Error);
        if (Respuesta.Error != "") {
            $("#dvMensaje").html(Respuesta.Error);
            $("#txtCreditos").val("");
            $("#txtValorCredito").val("");
            $("#txtValorAntesIVA").val("");
            $("#txtValorIVA").val("");
            $("#txtValorPagar").val("");
        }
        else {
            $("#dvMensaje").html("");
            $("#txtCreditos").val(Respuesta.TotalCreditos);
            $("#txtValorCredito").val(Respuesta.ValorCredito);
            $("#txtValorAntesIVA").val(Respuesta.ValorAntesIVA);
            $("#txtValorIVA").val(Respuesta.ValorIVA);
            $("#txtValorPagar").val(Respuesta.ValorPagar);
        }
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}