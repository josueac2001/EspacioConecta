using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicios_18_20.Models;
using Servicios_18_20.Clases;
using System.Web.Http.Cors;

namespace Servicios_18_20.Controllers
{
    [EnableCors(origins: "http://localhost:53462", headers: "*", methods: "*")]
    public class TipoProductoController : ApiController
    {
        public List<TIpoPRoducto> Get()
        {
            clsTipoProducto _tipoProducto = new clsTipoProducto();
            return _tipoProducto.ConsultarActivos();
        }
        public TIpoPRoducto Get(int Codigo)
        {
            clsTipoProducto _tipoProducto = new clsTipoProducto();
            return _tipoProducto.Consultar(Codigo);
        }
        public string Post([FromBody] TIpoPRoducto tipoProducto)
        {
            clsTipoProducto _tipoProducto = new clsTipoProducto();
            _tipoProducto.tipoProducto = tipoProducto;
            return _tipoProducto.Insertar();
        }
        public string Put([FromBody] TIpoPRoducto tipoProducto)
        {
            clsTipoProducto _tipoProducto = new clsTipoProducto();
            _tipoProducto.tipoProducto = tipoProducto;
            return _tipoProducto.Actualizar();
        }
        public string Delete(TIpoPRoducto tipoProducto)
        {
            clsTipoProducto _tipoProducto = new clsTipoProducto();
            _tipoProducto.tipoProducto = tipoProducto;
            return _tipoProducto.Eliminar();
        }
    }
}