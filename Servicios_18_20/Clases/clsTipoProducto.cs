using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios_18_20.Models;

namespace Servicios_18_20.Clases
{
    public class clsTipoProducto
    {
        //La propiedad de la clase que tiene la información que voy a procesar en la base de datos, para el ejemplo: TipoProducto
        public TIpoPRoducto tipoProducto { get; set; }
        //Creo un objeto de DBSuperEntities, para procesar la información contra la base de datos
        private DBSuperEntities dbSuper = new DBSuperEntities();
        
        //Lista completa de los tipos de producto
        public List<TIpoPRoducto> ConsultarActivos()
        {
            return dbSuper.TIpoPRoductoes
                          .Where(t=> t.Activo == true)
                          .OrderBy(t=> t.Nombre)
                          .ToList();
        }
        //Método consultar
        public TIpoPRoducto Consultar(int Codigo)
        {
            return dbSuper.TIpoPRoductoes.FirstOrDefault(t => t.Codigo == Codigo);
        }
        //Método de insertar
        public string Insertar()
        {
            try
            {
                dbSuper.TIpoPRoductoes.Add(tipoProducto);
                dbSuper.SaveChanges();
                return "Se insertó el tipo de producto: " + tipoProducto.Nombre + " en la base de datos";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        //Método actualizar
        public string Actualizar()
        {
            try
            {
                //Se crea un objeto de tipoProducto y se consulta
                TIpoPRoducto _tipoProducto = dbSuper.TIpoPRoductoes.FirstOrDefault(t => t.Codigo == tipoProducto.Codigo);
                if (_tipoProducto == null)
                {
                    return "No se encontró el tipo de producto";
                }
                //TIpoPRoducto _tipoproducto = Consultar(tipoProducto.Codigo);
                //Asignar los valores a _tipoProducto del objeto que se pasó a la clase: tipoProducto
                _tipoProducto.Nombre = tipoProducto.Nombre;
                _tipoProducto.Activo = tipoProducto.Activo;
                //Guarda los datos en la base de datos
                dbSuper.SaveChanges();
                return "Se actualizó la información del tipo producto: " + tipoProducto.Codigo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                //Se consulta el objeto
                TIpoPRoducto _tipoProducto = dbSuper.TIpoPRoductoes.FirstOrDefault(t => t.Codigo == tipoProducto.Codigo);
                if (_tipoProducto == null)
                {
                    return "No se encontró el tipo de producto";
                }
                //Se elimina (Remueve) de la base de datos
                dbSuper.TIpoPRoductoes.Remove(_tipoProducto);
                dbSuper.SaveChanges();
                return "Se eliminó el tipo de producto: " + _tipoProducto.Nombre;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}