using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(int idUsuario, string login, string pass, string estadoCuenta, DateTime fechaCreacion)
        {
            IdUsuario = idUsuario;
            Login = login;
            Pass = pass;
            EstadoCuenta = estadoCuenta;
            FechaCreacion = fechaCreacion;
        }

        private int IdUsuario;
        public int GetIdUsuario()
        {
            return this.IdUsuario;
        }
        public void SetIdUsuario(int id)
        {
            this.IdUsuario = id;
        }
        private String Login { get; set; }
        private String Pass { get; set; }
        private String EstadoCuenta { get; set; }
        private DateTime FechaCreacion { get; set; }
    }
}
