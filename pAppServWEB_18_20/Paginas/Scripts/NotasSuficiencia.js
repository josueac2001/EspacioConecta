$(document).ready(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html");
    $("#btnCalcular").click(function () {
        CalcularNota();
    });
});

async function CalcularNota() {
    //alert("Inicia el cálculo"); //Para saber si está funcionando

    //Captura datos de entrada
    let NotaPractica = $("#txtNotaPractica").val();
    let NotaTeorica = $("#txtNotaTeorica").val();
    let NotaTrabajo = $("#txtNotaTrabajo").val();

    //Json es un lenguaje que permite gestionar datos con formato de estructura Clave - Valor, y que puede contener estructuras complejas dentro de sus valores
    let DatosSuficiencia = {
        NotaPractica: NotaPractica,
        NotaTeorica: NotaTeorica,
        NotaTrabajo: NotaTrabajo
    }

    //alert("Nota práctica: " + DatosSuficiencia.NotaPractica + ", Nota teorica: " + DatosSuficiencia.NotaTeorica + ", Nota Trabajo: " + DatosSuficiencia.NotaTrabajo);

    //Invocar el servicio con ajax, utilizando la funcion fetch de javascript
    //Si utilizo fetch tengo que volver la funcion asincrona con async
    try {
        const RespuestaServicio = await fetch("http://localhost:53634/api/Suficiencia", {  //Sacar url del Postman
            method: "POST",
            mode: "cors",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(DatosSuficiencia)
        });
        //Leo la respuesta del servicio en formato json y la guardo en una variable
        const Respuesta = await RespuestaServicio.json();
        //alert(Respuesta.Error);
        if (Respuesta.Error != "") {
            $("#dvMensaje").html(Respuesta.Error);
            $("#txtNotaSuficiencia").val("");
            $("#txtNotaOficial").val("");
        }
        else {
            $("#txtNotaSuficiencia").val(Respuesta.NotaSuficiencia);
            $("#txtNotaOficial").val(Respuesta.NotaOficial);
        }
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}