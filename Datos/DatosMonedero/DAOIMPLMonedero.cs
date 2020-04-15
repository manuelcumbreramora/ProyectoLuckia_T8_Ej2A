using System;

public class DAOIMPLMonedero : IDAOMonedero
{
    public Conexion conexion;
    public SqlTransaction monedero;
    public string error;

    public DAOIMPLMonedero()
    {
        conexion = new Conexion();
    }


    void IDAOMonedero.CrearMonedero(DTOMonedero monedero)
    {
        bool agrega = false;
        SqlConnection conexion;
        conexion = new SqlConnection(this.conexion.GetNombreConexion());
        conexion.Open();
        SqlCommand comando = new SqlCommand();
        comando.Connection = conexion;
        comando.CommandText = "INSERT INTO Monedero VALUES(@idMonedero, @Saldo, @Tipo,@Divisa)";
        comando.Parameters.AddWithValue("@Saldo", monedero.Saldo);
        comando.Parameters.AddWithValue("@Divisa", monedero.IdMonedero);
        comando.Parameters.AddWithValue("@Tipo", monedero.Tipo);

        try
        {
            comando.ExecuteScalar();//Esto ejecuta la sentencia en la BBDD
            agrega = true;
        }
        catch (SqlException ex)
        {
            this.error = ex.Message;
        }

        conexion.Close();

    }


    int IDAOMonedero.RecuperarMonedero(int id)
    {
        DTOMonedero monedero = new DTOMonedero();
        SqlConnection connection = new SqlConnection(this.conexion.GetNombreConexion());
        connection.Open();
        SqlCommand comando = new SqlCommand();
        comando.Connection = connection;
        comando.CommandText = "SELECT @Saldo, @Divisa, @Tipo FROM Monedero WHERE @idMonedero=@idMonedero";
        comando.Parameters.AddWithValue("@idMonedero", id);

        try
        {
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    monedero.Saldo = reader.GetFloat(0);
                    monedero.Divisa = reader.GetString(1);
                    monedero.Tipo = reader.GetString(2);


                }
            }
            reader.Close();
            connection.Close();
            return id;
        }
        catch (Exception)
        {
            connection.Close();
            throw;
        }
    }
}
}
