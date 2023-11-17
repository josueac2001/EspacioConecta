using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_18_20.Clases
{
    public class clsFactura
    {
        public FACTura factura { get; set; }
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public int GrabarFactura()
        {
            factura.Numero = CalcularNumeroFactura() + 1;
            factura.Fecha = DateTime.Now;
            dbSuper.FACTuras.Add(factura);
            dbSuper.SaveChanges();

            return factura.Numero;
        }
        private int CalcularNumeroFactura()
        {
            return dbSuper.FACTuras.Select(f => f.Numero).DefaultIfEmpty(0).Max();
        }
    }
}