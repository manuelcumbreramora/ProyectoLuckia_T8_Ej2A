using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.UsuarioDao
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
        }

        public UsuarioDTO(string login, string pass)
        {
            Login = login;
            Pass = pass;
            EstadoCuenta = "";
            FechaCreacion = DateTime.Now;
        }

        public int? IdUsuario { get; set; }
        public String Login { get; set; }
        public String Pass { get; set; }
        public String EstadoCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
