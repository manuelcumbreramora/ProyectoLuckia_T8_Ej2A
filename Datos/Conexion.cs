using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private String NombreConexion;

        public Conexion()
        {
            NombreConexion = "Data Source=PLX300000000420\\SQLEXPRESS;Initial Catalog=PartidosDB;Integrated Security=True";
        }

        public string GetNombreConexion()
        {
            return this.NombreConexion;
        }
    }
}
