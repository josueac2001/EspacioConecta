using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicios_18_20.Clases;
using Servicios_18_20.Models;
using System.Web.Http.Cors;

namespace Servicios_18_20.Controllers
{
    [EnableCors(origins: "http://localhost:53462", headers: "*", methods: "*")]
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get()
        {
            clsProducto producto = new clsProducto();
            return producto.ConsultarProductosConTipo();
        }
        /*
        public List<PRODucto> Get (int CodigoTipoProducto)
        {
            clsProducto producto = new clsProducto();
            return producto.ConsultarXTipoProducto(CodigoTipoProducto);
        }
        */
        public IQueryable Get(int CodigoTipoProducto)
        {
            clsProducto producto = new clsProducto();
            return producto.ConsultarXTipoValorUnitario(CodigoTipoProducto);
        }
    }
}