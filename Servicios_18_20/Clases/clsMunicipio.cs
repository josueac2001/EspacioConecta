using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios_18_20.Models;

namespace Servicios_18_20.Clases
{
    public class clsMunicipio
    {
        //La propiedad de la clase que tiene la información que voy a procesar en la base de datos, para el ejemplo: TipoProducto
        public municipio municipio { get; set; }
        //Creo un objeto de DBSuperEntities, para procesar la información contra la base de datos
        private ConectaDBEntities dbConecta = new ConectaDBEntities();
        
        
        //Método consultar
        public municipio Consultar(int Codigo)
        {
            return dbConecta.municipios.FirstOrDefault(t => t.ID == Codigo);
        }
        //Método de insertar
        
    }
}