using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesNegocio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioCategoriasADO : IRepositorioCategorias
    {
        public bool Add(Categoria obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> FindAll()
        {
            List<Categoria> categorias = new List<Categoria>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Categorias;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Categoria cat = new Categoria()
                    {
                       
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                        
                    };
                    categorias.Add(cat);
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

            return categorias;
        }

        public Categoria FindById(int id)
        {
            Categoria buscada = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Categorias WHERE Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    buscada = new Categoria()
                    {
                      
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                    };
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

            return buscada;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categoria obj)
        {
            throw new NotImplementedException();
        }
    }
}
