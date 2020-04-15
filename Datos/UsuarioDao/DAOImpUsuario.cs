using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.UsuarioDao
{
    public class DAOImpUsuario : IDAOUsuario
    {
        public Conexion conexion;
        public SqlTransaction sqlTransaction;

        public DAOImpUsuario()
        {
            conexion = new Conexion();
        }
        public int AgregarUsuario(UsuarioDTO usuario)
        {
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Usuario(Login,Password,FechaCreacion,EstadoCuenta) OUTPUT INSERTED.IdUsuario VALUES(@Login, @Password,@FechaCreacion,@EstadoCuenta)";
            cmd.Parameters.AddWithValue("@Login", usuario.Login);
            cmd.Parameters.AddWithValue("@Password", usuario.Pass);
            cmd.Parameters.AddWithValue("@FechaCreacion", usuario.FechaCreacion);
            cmd.Parameters.AddWithValue("@EstadoCuenta", usuario.EstadoCuenta);

            try
            {
                int result = (int)cmd.ExecuteScalar();
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

        }

        public UsuarioDTO RecuperarUsuario(int id)
        {
            UsuarioDTO usuario = new UsuarioDTO();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT Login, Password, FechaCreacion, EstadoCuenta FROM Usuario WHERE IdUsuario=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario.Login = reader.GetString(0);
                        usuario.Pass= reader.GetString(1);
                        usuario.FechaCreacion = reader.GetDateTime(2);
                        usuario.EstadoCuenta = reader.GetString(3);
                        usuario.IdUsuario = id;
                    }
                }
                reader.Close();
                connection.Close();
                return usuario;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

        }

        public int? BuscarUsuario(String Login, String Pass)
        {
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT IdUsuario FROM Usuario WHERE Login LIKE @Login AND Password LIKE @Password";
            cmd.Parameters.AddWithValue("@Login", Login);
            cmd.Parameters.AddWithValue("@Password", Pass);

            try
            {
                int? result = (int?)cmd.ExecuteScalar();
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                connection.Close();

                throw;
            }
        }

        public int? CrearUsuario(string Login, string Pass)
        {
            UsuarioDTO usuario = new UsuarioDTO(Login, Pass);
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Usuario(Login,Password,FechaCreacion,EstadoCuenta) OUTPUT INSERTED.IdUsuario VALUES(@Login, @Password,@FechaCreacion,@EstadoCuenta)";
            cmd.Parameters.AddWithValue("@Login", usuario.Login);
            cmd.Parameters.AddWithValue("@Password", usuario.Pass);
            cmd.Parameters.AddWithValue("@FechaCreacion", usuario.FechaCreacion);
            cmd.Parameters.AddWithValue("@EstadoCuenta", usuario.EstadoCuenta);

            try
            {
                int? result = (int?)cmd.ExecuteScalar();
                usuario.IdUsuario = result;
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
