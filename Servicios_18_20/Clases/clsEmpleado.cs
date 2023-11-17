using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios_18_20.Models;

namespace Servicios_18_20.Clases
{
    public class clsEmpleado
    {
        public EMPLeado empleado { get; set; }
        private DBSuperEntities dbSuper = new DBSuperEntities();
        /*
        private void CalcularBono()
        {
            if (empleado.experiencia < 5)
            {
                empleado.bono = 0;
            }
            else
            {
                empleado.bono = 10;
            }
        }
        */
        public IQueryable LlenarComboEmpleado()
        {
            return from E in dbSuper.Set<EMPLeado>()
                   join EC in dbSuper.Set<EMpleadoCArgo>()
                   on E.Documento equals EC.Documento
                   where EC.CodigoCargo == 1
                   select new
                   {
                       Codigo = EC.Codigo,
                       Nombre = E.Nombre + " " + E.PrimerApellido + " " + E.SegundoApellido
                   };
        }
        public EMPLeado Consultar(string documento)
        {
            return dbSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == documento);
        }
        public string Insertar()
        {
            //CalcularBono();
            try
            {
                dbSuper.EMPLeadoes.Add(empleado);
                dbSuper.SaveChanges();
                return "Se grabó el empleado con el documento: " + empleado.Documento;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            //CalcularBono();
            try
            {
                //dbSuper.EMPLeadoes.AddOrInsert(empleado);
                EMPLeado _empleado = Consultar(empleado.Documento);
                if (_empleado == null)
                {
                    return "El empleado con documento: " + empleado.Documento + ", no existe en la base de datos";
                }
                _empleado.Nombre = empleado.Nombre;
                _empleado.PrimerApellido = empleado.PrimerApellido;
                _empleado.SegundoApellido = empleado.SegundoApellido;
                _empleado.Telefono = empleado.Telefono;
                _empleado.FechaNacimiento = empleado.FechaNacimiento;
                _empleado.Direccion = empleado.Direccion;
                dbSuper.SaveChanges();
                return "Se actualizó el empleado con el documento: " + empleado.Documento;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                EMPLeado _empleado = Consultar(empleado.Documento);
                if (_empleado == null)
                {
                    return "El empleado con documento: " + empleado.Documento + ", no existe en la base de datos";
                }
                dbSuper.EMPLeadoes.Remove(_empleado);
                dbSuper.SaveChanges();
                return "Se eliminó el empleado de la base de datos, documento: " + empleado.Documento;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}