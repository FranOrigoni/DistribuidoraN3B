using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorios
{
    public class Conexion
    {
        public static string StringConexion { get; set; } = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=N3BMarzo2022ADO; Integrated Security=SSPI;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(StringConexion);
        }

        public static void AbrirConexion(SqlConnection con)
        {
            if (con!=null && con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public static void CerrarYDisposeConexion(SqlConnection con)
        {
            CerrarConexion(con);
            con.Dispose();
        }

        public static void CerrarConexion(SqlConnection con)
        {
            if (con != null && con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}
