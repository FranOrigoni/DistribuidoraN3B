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
                obj.Id = idProducto;
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
            List<Producto> productos = new List<Producto>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "select p.*, I.PaisOrigen, N.EcoAmbigable, c.Nombre,c.Descripcion, PR.rut, pr.RazonSocial " +
                  "from Productos as P left join Importados as I ON P.Id = I.Id " + 
                   "left join Nacionales as N on p.Id = N.Id " +
                   "left join Categorias as C on P.IdCategoria = c.Id " +
                   "left join Proveedores as PR on p.IdProveedor = pr.Id ";

            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = CrearProducto(reader);
                    p.Categoria = CrearCategoria(reader);
                    p.Proveedor = CrearProveedor(reader);
                    p.Valoraciones = CrearValoraciones(p.Id);

                    productos.Add(p);

                }

                Conexion.CerrarConexion(con);
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarConexion(con);
            }

            return productos;
        }

        private List<Valoracion> CrearValoraciones(int idProducto)
        {
            List<Valoracion> valoraciones = new List<Valoracion>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Valoraciones WHERE IdProducto=" + idProducto;
            SqlCommand com = new SqlCommand(sql, con);
           

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Valoracion v  = new Valoracion()
                    {
                        
                        Id = reader.GetInt32(0),
                        Puntaje = reader.GetInt32(1),
                        Alias = reader.GetString(2),
                        Comentario = reader.GetString(3)
                    };

                    valoraciones.Add(v);
                }

                Conexion.CerrarConexion(con);
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarConexion(con);
            }

            return valoraciones;
        }

        private  Proveedor CrearProveedor(SqlDataReader reader)
        {
            return new Proveedor()
            {
                Id = reader.GetInt32(7),
                RUT = reader.GetString(12),
                RazonSocial = reader.GetString(12)
            };
        }

        private Categoria CrearCategoria(SqlDataReader reader)
        {
            return new Categoria()
            {
                Id = reader.GetInt32(6),
                Nombre = reader.GetString(10),
                Descripcion = reader.GetString(11)
            };
        }

        private Producto CrearProducto(SqlDataReader reader)
        {
            Producto p = null;

            if (reader[9] is DBNull) // Es Importado
            {
                p = new Importado()
                {
                    PaisOrigen = reader.GetString(8)
                };
            }
            else // es nacional
            {
                p = new Nacional()
                {
                    EcoAmigable = reader.GetBoolean(9)
                };
            }

            p.Id = reader.GetInt32(0);
            p.Codigo = reader.GetInt32(1);
            p.Nombre = reader.GetString(2);
            p.Precio = reader.GetDecimal(3);
            p.Stock = reader.GetInt32(4);
            p.Foto = reader.GetString(5);

            return p;
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
