using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesNegocio;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioProductosADO : IRepositorioProductos
    {
        public bool Add(Producto obj)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            string sqlProducto = "INSERT INTO Productos VALUES(@codigo, @nom, @precio, @stock, @foto, @cat, @prov);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            string sqlNacional = "INSERT INTO Nacionales VALUES(@id, @eco);";
            string sqlImportado = "INSERT INTO Importados VALUES(@id, @pais);";


            SqlCommand com = new SqlCommand(sqlProducto, con);

            com.Parameters.AddWithValue("@nom", obj.Nombre);
            com.Parameters.AddWithValue("@precio", obj.Precio);
            com.Parameters.AddWithValue("@foto", obj.Foto);
            com.Parameters.AddWithValue("@codigo", obj.Codigo);
            com.Parameters.AddWithValue("@stock", obj.Stock);
            com.Parameters.AddWithValue("@cat", obj.Categoria.Id);
            com.Parameters.AddWithValue("@prov", obj.Proveedor.Id);


            SqlTransaction tran = null;


            try
            {
                Conexion.AbrirConexion(con);
                tran = con.BeginTransaction();
                com.Transaction = tran;

                int idProducto = (int)com.ExecuteScalar();

                com.Parameters.Clear();
                com.Parameters.AddWithValue("@id", idProducto);
                


                if (obj.Tipo() == "Nacional")
                {
                    Nacional nac = obj as Nacional;
                    com.Parameters.AddWithValue("@eco", nac.EcoAmigable);
                    com.CommandText = sqlNacional;
                }
                else if (obj.Tipo() == "Importado")
                {
                   Importado impo = obj as Importado;
                    com.Parameters.AddWithValue("@eco", impo.PaisOrigen);
                    com.CommandText = sqlImportado;

                }

                com.ExecuteNonQuery();
                tran.Commit();
                ok = true;
               
            }
            catch
            {
                if (tran != null) tran.Rollback();
                throw;
            }
            finally
            {
                Conexion.CerrarYDisposeConexion(con);
            }

            return ok;
        }

        public IEnumerable<Producto> FindAll()
        {
            throw new NotImplementedException();
        }

        public Producto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> ProductosEnRangoDePrecio(decimal desde, decimal hasta)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Producto obj)
        {
            throw new NotImplementedException();
        }
    }
}
