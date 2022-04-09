using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioProveedoresADO : IRepositorioProveedores
    {
        public bool Add(Proveedor obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> FindAll()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Proveedores;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Proveedor prov = new Proveedor()
                    {

                        Id = reader.GetInt32(0),
                        RUT = reader.GetString(1),
                        RazonSocial = reader.GetString(2)

                    };
                    proveedores.Add(prov);
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

            return proveedores;
        }

        public Proveedor FindById(int id)
        {
            Proveedor buscado = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Proveedores WHERE Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    buscado = new Proveedor()
                    {
                  
                        Id = reader.GetInt32(0),
                        RUT = reader.GetString(1),
                        RazonSocial = reader.GetString(2),
                        
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

            return buscado;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Proveedor obj)
        {
            throw new NotImplementedException();
        }
    }
}
