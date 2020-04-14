using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public string EstadoCuenta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime fecha { get; set; }

        public Usuario(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }

        public void CrearUsuario(string login , string pass, int IdUsuario)
        {
           
        }

    }
}
