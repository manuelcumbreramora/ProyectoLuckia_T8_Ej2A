using System;
using System.Data.SqlClient;


namespace Datos { 
public class DAOIMPLMonedero : IDAOMonedero
{
        public Conexion conexion;
        public string error;

        public DAOIMPLMonedero()
        {
            conexion = new Conexion();
        }


        public DTOMonedero CrearMonederoDAO(DTOMonedero monederoDTO)
        {
            int idIngresado = 0;
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            String consulta = "INSERT INTO Monedero(IdUsuario,Saldo,Divisa) OUTPUT INSERTED.IdMonedero VALUES(" + monederoDTO.GetIdUsuarioDTO() + ", " + monederoDTO.GetSaldoDTO() + ", '" + monederoDTO.GetDivisaDTO() + "')";
            comando.CommandText = consulta;

            try
            {
                SqlDataReader registro = comando.ExecuteReader();//Esto ejecuta la sentencia en la BBDD

                if (registro.Read())//si hizo la lectura
                {
                    idIngresado = registro.GetInt32(0);
                    monederoDTO.SetIdMonederoDTO(idIngresado);
                    registro.Close();
                    conexion.Close();
                    return monederoDTO;
                }
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
                Console.WriteLine("Error " + this.error);
                Console.ReadLine();
            }

            conexion.Close();
            return null;

        }



        public DTOMonedero RecuperarMonederoPorIdMonederoDAO(int id)
        {
            DTOMonedero monedero = new DTOMonedero();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = connection;
            String consulta = "SELECT IdMonedero,IdUsuario,Divisa,Saldo FROM Monedero WHERE IdMonedero=" + id + ";";
            comando.CommandText = consulta;
            // comando.Parameters.AddWithValue("@idMonedero", id);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())//si hizo la lectura
            {
                DTOMonedero nuevoMonedero = new DTOMonedero();
                nuevoMonedero.SetIdMonederoDTO(registro.GetInt32(0));
                nuevoMonedero.SetIdUsuarioDTO(registro.GetInt32(1));
                nuevoMonedero.SetDivisaDTO(registro.GetString(2));
                float i = (float)registro.GetDouble(3);
                nuevoMonedero.SetSaldoDTO(i);

                registro.Close();
                connection.Close();
                return nuevoMonedero;
            }
            else
            {
                registro.Close();
                connection.Close();
                return null;
            }

        }

        public bool ModificarSaldoMonederoDTO(int idMonederoAmodificar, float saldoNuevo)
        {
            bool exitoModificar = false;
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = connection;
            //UPDATE Monedero SET Saldo=@saldo where IdMonedero=idMonedero
            String consulta = "UPDATE Monedero SET Saldo=" + saldoNuevo + " where IdMonedero=" + idMonederoAmodificar;
            comando.CommandText = consulta;

            try
            {
                comando.ExecuteNonQuery();//Esto ejecuta la sentencia en la BBDD
                exitoModificar = true;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return exitoModificar;
        }
        public DTOMonedero RecuperarMonederoPorIdUsuarioDAO(int idUsuario)
        {
            DTOMonedero monedero = new DTOMonedero();
            SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
            connection.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = connection;
            String consulta = "SELECT IdMonedero,IdUsuario,Divisa,Saldo FROM Monedero WHERE IdUsuario=" + idUsuario + ";";
            comando.CommandText = consulta;
            // comando.Parameters.AddWithValue("@idMonedero", id);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())//si hizo la lectura
            {
                DTOMonedero nuevoMonedero = new DTOMonedero();
                nuevoMonedero.SetIdMonederoDTO(registro.GetInt32(0));
                nuevoMonedero.SetIdUsuarioDTO(registro.GetInt32(1));
                nuevoMonedero.SetDivisaDTO(registro.GetString(2));
                float i = (float)registro.GetDouble(3);
                nuevoMonedero.SetSaldoDTO(i);

                registro.Close();
                connection.Close();
                return nuevoMonedero;
            }
            else
            {
                registro.Close();
                connection.Close();
                return null;
            }
        }
    }
}
