using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace Servicios_18_20.Clases
{
    public class clsTipoTelefono
    {
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public List<TIpoTElefono> ConsultarTodos()
        {
            return dbSuper.TIpoTElefonoes.ToList();
        }
    }
}