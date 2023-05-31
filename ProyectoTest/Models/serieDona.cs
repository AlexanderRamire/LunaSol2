using ProyectoTest.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Globalization;

namespace ProyectoTest.Models
{

    
    public class serieDona
    {
        public string name { get; set; }
        public double y { get; set; }
        public bool sliced { get; set; }
        public bool selected { get; set; }



        public serieDona()
        {

        }

        public serieDona(string name, double y, bool sliced = false, bool selected = false)
        {
            this.name = name;
            this.y = y;
            this.sliced = sliced;
            this.selected = selected;

        }
       
        public List<serieDona> GetDataDummy()
        {
            List<serieDona> rptListaProducto = new List<serieDona>();
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
                        rptListaProducto.Add(new serieDona()
                        {
                            name = dr["Nombre"].ToString(),
                            y = Convert.ToDouble(dr["Precio"].ToString(), new CultureInfo("es-PE"))


                        });
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