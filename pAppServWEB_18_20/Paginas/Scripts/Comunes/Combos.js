﻿async function LlenarComboXServicios(urlServicio, ComboLlenar) {
    //Invocar el servicio
    try {
        const Respuesta = await fetch(urlServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();
        //En Rpta, está el listado de los elementos del combo
        //Se debe limpiar el combo
        $(ComboLlenar).empty();
        //Recorrer la lista para agregarla al combo
        for (i = 0; i < Rpta.length; i++) {
            $(ComboLlenar).append('<option value=' + Rpta[i].Codigo + '>' + Rpta[i].Nombre + '</option>')
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}