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
        public SqlTransaction transaccion;
        public string error;

        public DAOTransaccion()
        {
            conexion = new Conexion();  //conectamos con base de datos
        }
        public bool AgregarTransaccion(DTOTransaccion transaccion)
        {
            bool agrega = false;
            SqlConnection conexion;
            conexion = new SqlConnection(this.conexion.GetNombreConexion());
            conexion.Open();
            SqlCommand comando = new SqlCommand(); //sentencia sql que se ejecutará
            comando.Connection = conexion;
            /*
             * private int IdTransaccion;
        private float Importe;
        private DateTime FechaCreacion;
        private String TipoTransaccion;
        private int IdMonedero; 
             * */
            String fechaAux = transaccion.GetFechaCreacionDTO().ToString("yyyy-MM-dd");

            comando.CommandText = "INSERT INTO Transaccion VALUES(@idTransaccion, @importe, @fechaCreacion,@tipoTransaccion, @idMonedero)";
            comando.Parameters.AddWithValue("@idTransaccion", transaccion.GetIdTransaccionDTO()); // variable que identificara el valor que se introducira en la sentencia
            comando.Parameters.AddWithValue("@idMonedero", transaccion.GetIdMonederoDTO());
            comando.Parameters.AddWithValue("@importe", transaccion.GetImporteDTO());
            comando.Parameters.AddWithValue("@tipoTransaccion", transaccion.GetTipoTransaccionDTO());
            comando.Parameters.AddWithValue("@fechaCreacion", fechaAux);

            try
            {
                comando.ExecuteNonQuery();//Esto ejecuta la sentencia en la BBDD
                agrega = true;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }

            conexion.Close();
            return agrega;
        }
    }
}
