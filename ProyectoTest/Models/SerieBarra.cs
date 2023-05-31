using ProyectoTest.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Collections;

namespace ProyectoTest.Models
{
    public class SerieBarra
    {

        public SerieBarra() { 
        
        }


        public object[] GetDataDummy() {


            

            string connectionString = "Data Source=nombreServidor;Initial Catalog=nombreBaseDatos;Integrated Security=True";

            string query = "SELECT columna1, columna2 FROM tabla";

            object[] data = new object[5];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string columna1 = reader.GetString(0);
                    decimal columna2 = reader.GetDecimal(1);

                    // Agregar los valores a la lista
                    data.Add(new Tuple<string, decimal>(columna1, columna2));
                }

                reader.Close();
            }





















            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_productos_top", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        string names = dr["Nombre"].ToString();
                        decimal yes = Convert.ToDouble(dr["Precio"].ToString(), new CultureInfo("es-PE"));


                        
                    }
                    dr.Close();

                    return rptListaProducto;

                }
                catch (Exception ex)
                {
                    rptListaProducto = null;
                    return rptListaProducto;
                }
            }
        }


    }
}