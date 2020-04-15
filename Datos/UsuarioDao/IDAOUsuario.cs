using System;

namespace Datos.UsuarioDao
{
    public interface IDAOUsuario
    {
        int? CrearUsuario(String Login, String Pass);
        int AgregarUsuario(UsuarioDTO usuario);
        UsuarioDTO RecuperarUsuario(int id);
        int? BuscarUsuario(String Login, String Pass);

    }
}
