using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios_18_20.Models;

namespace Servicios_18_20.Clases
{
    public class clsProducto
    {
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public PRODucto producto { get; set; }
        public IQueryable ConsultarProductosConTipo()
        {
            /*
                SELECT		TP.Codigo as CodTipoProducto, TP.Nombre as Tipo_Producto,
			                P.Codigo, P.Nombre as Producto
                FROM		TIpoPRoducto TP inner join producto P
			                on TP.Codigo = P.CodigoTipoProducto
                ORDER by	TP.Nombre, P.Nombre;
             */
            return from TP in dbSuper.Set<TIpoPRoducto>()
                   join P in dbSuper.Set<PRODucto>()
                   on TP.Codigo equals P.CodigoTipoProducto
                   orderby (TP.Nombre)
                   select new
                   {
                       Cod_Tipo_Producto = TP.Codigo,
                       Tipo_Producto = TP.Nombre,
                       Codigo = P.Codigo,
                       Producto = P.Nombre,
                       Descripcion = P.Descripcion,
                       Cantidad = P.Cantidad,
                       Valor_Unitario = P.ValorUnitario
                   };
        }
        public List<PRODucto> ConsultarXTipoProducto(int TipoProducto)
        {
            return dbSuper.PRODuctoes
                    .Where (p=> p.CodigoTipoProducto == TipoProducto)
                    .ToList();
        }
        public IQueryable ConsultarXTipoValorUnitario(int TipoProducto)
        {
            return from P in dbSuper.Set<PRODucto>()
                   where P.CodigoTipoProducto == TipoProducto
                   select new
                   {
                       Codigo = P.Codigo + "|" + P.ValorUnitario,
                       Nombre = P.Nombre
                   };
        }
    }
}