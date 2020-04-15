using System;

namespace Datos.UsuarioDao
{
    public interface IDAOUsuario
    {
        UsuarioDTO AgregarUsuario(UsuarioDTO usuario);
        UsuarioDTO RecuperarUsuario(int id);
        int? BuscarUsuario(String Login, String Pass);
        int? BuscarUsuario(String Login);

    }
}
