using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios_18_20.Models;

namespace Servicios_18_20.Clases
{
    public class clsEspacio
    {
        private ConectaDBEntities dbConecta = new ConectaDBEntities();
        public espacio espacio { get; set; }
        public IQueryable ConsultarEspaciosConTipo()
        {
            return from tipoEspacio in dbConecta.Set<tipoEspacio>()
                   join espacio in dbConecta.Set<espacio>() on tipoEspacio.ID equals espacio.tipoEspacioID
                   join municipio in dbConecta.Set<municipio>() on espacio.municipioID equals municipio.ID
                   join foto in dbConecta.Set<foto>() on espacio.ID equals foto.espacioID into fotos
                   from foto in fotos.DefaultIfEmpty()
                   orderby tipoEspacio.nombre
                   select new
                   {
                       EspacioID = espacio.ID,
                       Ubicacion = espacio.direccion,
                       Tipo = tipoEspacio.nombre,
                       Municipio = municipio.nombre,
                       Precio = espacio.precio
                   };
        }

    }
}