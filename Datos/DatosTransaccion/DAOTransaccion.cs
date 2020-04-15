using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DatosTransaccion
{
    public class DAOTransaccion
    {
        public Conexion conexion;
        public string error;

        public DAOTransaccion()
        {
            conexion = new Conexion();  //conectamos con base de datos
        }
        public DTOTransaccion AgregarTransaccionDAO(DTOTransaccion transaccion)
        {

            int idIngresado = 0;
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand(); //sentencia sql que se ejecutará
            comando.Connection = conexion;
            String consulta = "INSERT INTO Transaccion(Importe,FechaCreacion,TipoTransaccion,IdMonedero) OUTPUT INSERTED.IdTransaccion VALUES(" + transaccion.GetImporteDTO() + ", '" + transaccion.GetFechaCreacionDTO() + "', '" + transaccion.GetTipoTransaccionDTO() + "', " + transaccion.GetIdMonederoDTO() + ")";
            //Console.WriteLine("Consulta: "+consulta);
            // Console.ReadLine();
            comando.CommandText = consulta;

            try
            {
                SqlDataReader registro = comando.ExecuteReader();//Esto ejecuta la sentencia en la BBDD

                if (registro.Read())//si hizo la lectura
                {
                    idIngresado = registro.GetInt32(0);
                    //Console.WriteLine("He introducido el idTrans: " + idIngresado);
                    //  DTOTransaccion transDTOconID = new DTOTransaccion(idIngresado, transaccion.GetIdMonederoDTO(), transaccion.GetImporteDTO(), transaccion.GetFechaCreacionDTO(), transaccion.GetTipoTransaccionDTO());
                    transaccion.SetIdTransaccionDTO(idIngresado);
                    registro.Close();
                    conexion.Close();
                    return transaccion;
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

        public DTOTransaccion RecuperarTransaccionPorIdTransaccionDAO(int id)
        {
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand(); //sentencia sql que se ejecutará
            comando.Connection = conexion;//seleccionamos conexión                  

            comando.CommandText = "SELECT IdTransaccion,Importe,FechaCreacion,TipoTransaccion,IdMonedero FROM Transaccion WHERE idTransaccion = @idTransaccion";//asignamos sentencia 
            comando.Parameters.AddWithValue("@idTransaccion", id);//identificamos parametro consulta
            SqlDataReader registro = comando.ExecuteReader();//ejecuta la consultar y el resultado se guarda en "registo"
            if (registro.Read())//si hizo la lectura
            {
                DTOTransaccion nuevaTransaccion = new DTOTransaccion();
                nuevaTransaccion.SetIdTransaccionDTO(registro.GetInt32(0));
                float i = (float)registro.GetDouble(1);
                nuevaTransaccion.SetImporteDTO(i);
                nuevaTransaccion.SetFechaCreacionDTO(registro.GetDateTime(2));
                nuevaTransaccion.SetTipoTransaccionDTO(registro.GetString(3));
                nuevaTransaccion.SetIdMonederoDTO(registro.GetInt32(4));

                registro.Close();
                conexion.Close();
                return nuevaTransaccion;
            }
            else
            {
                registro.Close();
                conexion.Close();
                return null;
            }

        }
        public List<DTOTransaccion> RecuperarTransaccionPorIdMonederoDAO(int id)
        {
            List<DTOTransaccion> listaTransaccion = new List<DTOTransaccion>();
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand(); //sentencia sql que se ejecutará
            comando.Connection = conexion;

            comando.CommandText = "SELECT IdTransaccion,Importe,FechaCreacion,TipoTransaccion,IdMonedero FROM Transaccion WHERE IdMonedero=@idMonedero";
            comando.Parameters.AddWithValue("@idMonedero", id);

            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                DTOTransaccion nuevaTransaccion = new DTOTransaccion();
                nuevaTransaccion.SetIdTransaccionDTO(registro.GetInt32(0));
                float i = (float)registro.GetDouble(1);
                nuevaTransaccion.SetImporteDTO(i);
                nuevaTransaccion.SetFechaCreacionDTO(registro.GetDateTime(2));
                nuevaTransaccion.SetTipoTransaccionDTO(registro.GetString(3));
                nuevaTransaccion.SetIdMonederoDTO(registro.GetInt32(4));

                listaTransaccion.Add(nuevaTransaccion);

            }
            registro.Close();
            conexion.Close();
            return listaTransaccion;

        }
        public List<DTOTransaccion> RecuperarTransaccionPorIdUsuarioDAO(int id)
        {
            List<DTOTransaccion> listaTransaccion = new List<DTOTransaccion>();
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand(); //sentencia sql que se ejecutará
            comando.Connection = conexion;

            /*
             SELECT * FROM Transacion A JOIN Monedero B ON A.IdMonedero=B.IdMonedero JOIN Usuario C ON B.IdUsuario=C.IdUsuario 
WHERE C.IdUsuario=@idUsuario
             */

            comando.CommandText = "SELECT * FROM Transacion A JOIN Monedero B ON A.IdMonedero=B.IdMonedero JOIN Usuario C ON B.IdUsuario=C.IdUsuario WHERE C.IdUsuario = @idUsuario";
            comando.Parameters.AddWithValue("@idUsuario", id);

            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                DTOTransaccion nuevaTransaccion = new DTOTransaccion();
                nuevaTransaccion.SetIdTransaccionDTO(registro.GetInt32(0));
                nuevaTransaccion.SetImporteDTO(registro.GetFloat(1));
                nuevaTransaccion.SetFechaCreacionDTO(registro.GetDateTime(2));
                nuevaTransaccion.SetTipoTransaccionDTO(registro.GetString(3));
                nuevaTransaccion.SetIdMonederoDTO(registro.GetInt32(4));

                listaTransaccion.Add(nuevaTransaccion);

            }
            registro.Close();
            conexion.Close();
            return listaTransaccion;

        }

        /*public int RecuperarUltimoIdTransaccion()
        {
            //creamos un comando para realizar sentencia
            int ultimoId = 0;
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand(); //sentencia sql que se ejecutará
            comando.Connection = conexion;//seleccionamos conexión


            comando.CommandText = "SELECT MAX(idTransaccion) FROM Transaccion";//asignamos sentencia 
                                                                        //identificamos parametro consulta
            SqlDataReader registro = comando.ExecuteReader();//ejecuta la consultar y el resultado se guarda en "registo"
            if (registro.Read())//si hizo la lectura
            {

                ultimoId = registro.GetInt32(0);

                registro.Close();
                conexion.Close();
                return ultimoId;
            }
            else
            {
                registro.Close();
                conexion.Close();
                return ultimoId;
            }
            
        }*/

    }
}
