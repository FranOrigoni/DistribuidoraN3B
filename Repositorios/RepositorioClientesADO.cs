using System;
using System.Collections.Generic;
using System.Text;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesNegocio;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Repositorios
{
    public class RepositorioClientesADO : IRepositorioClientes
    {
        public bool Add(Cliente obj)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "INSERT INTO Clientes VALUES(@nom, @ape, @tel, @pass, @puntos, @email); SELECT CAST (SCOPE_IDENTITY() AS INT);";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@nom", obj.Nombre);
            com.Parameters.AddWithValue("@ape", obj.Apellido);
            com.Parameters.AddWithValue("@tel", obj.Telefono);
            com.Parameters.AddWithValue("@pass", obj.Contrasenia);
            com.Parameters.AddWithValue("@puntos", obj.Puntos);
            com.Parameters.AddWithValue("@email", obj.Email);

            try
            {
                Conexion.AbrirConexion(con);
                int idCliente  = (int)com.ExecuteScalar();
                obj.Id = idCliente;
                ok = true;
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

            return ok;
        }

        public Cliente BuscarClientePorEmail(string email)
        {
            Cliente buscado = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Clientes WHERE Email=@email;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@email", email);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    buscado = new Cliente()
                    {
                        //EJEMPLOS DE TODAS LAS FORMAS POSIBLES DE OBTENER LOS VALORES DE LOS CAMPOS
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(2),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader.GetString(6),
                        Contrasenia = reader.GetString(4),
                        Puntos = (int)reader["Puntos"]
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

        public IEnumerable<Cliente> ClientesConPuntajeMayorA(int puntos)
        {
            List<Cliente> clientes = new List<Cliente>();

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Clientes WHERE Puntos > @puntos;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@puntos", puntos);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente()
                    {
                        //EJEMPLOS DE TODAS LAS FORMAS POSIBLES DE OBTENER LOS VALORES DE LOS CAMPOS
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(2),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader.GetString(6),
                        Contrasenia = reader.GetString(4),
                        Puntos = (int)reader["Puntos"]
                    };
                    clientes.Add(cli);
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

            return clientes;
        }

        public IEnumerable<Cliente> FindAll()
        {
            List<Cliente> clientes = new List<Cliente>();            

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Clientes;";
            SqlCommand com = new SqlCommand(sql, con);           

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente()
                    {
                        //EJEMPLOS DE TODAS LAS FORMAS POSIBLES DE OBTENER LOS VALORES DE LOS CAMPOS
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(2),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader.GetString(6),
                        Contrasenia = reader.GetString(4),
                        Puntos = (int)reader["Puntos"]
                    };
                    clientes.Add(cli);
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

            return clientes;
        }

        public Cliente FindById(int id)
        {
            Cliente buscado = null;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Clientes WHERE Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    buscado = new Cliente()
                    {
                        //EJEMPLOS DE TODAS LAS FORMAS POSIBLES DE OBTENER LOS VALORES DE LOS CAMPOS
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(2),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader.GetString(6),
                        Contrasenia = reader.GetString(4),
                        Puntos = (int)reader["Puntos"]
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
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            string sql = "DELETE FROM Clientes WHERE Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id);

            try
            {
                Conexion.AbrirConexion(con);
                int filasAfectadas = com.ExecuteNonQuery();
                ok = filasAfectadas == 1;
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

            return ok;
        }

        public bool Update(Cliente obj)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            Cliente conMail = BuscarClientePorEmail(obj.Email);

            if (conMail == null || conMail.Id == obj.Id)
            {
                string sql = "UPDATE Clientes SET Nombre=@nom, Apellido=@ape, Email=@email, Telefono=@tel, Puntos=@puntos, Contrasenia=@pass WHERE Id=@id;";
                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@id", obj.Id);
                com.Parameters.AddWithValue("@nom", obj.Nombre);
                com.Parameters.AddWithValue("@ape", obj.Apellido);
                com.Parameters.AddWithValue("@tel", obj.Telefono);
                com.Parameters.AddWithValue("@pass", obj.Contrasenia);
                com.Parameters.AddWithValue("@puntos", obj.Puntos);
                com.Parameters.AddWithValue("@email", obj.Email);

                try
                {
                    Conexion.AbrirConexion(con);
                    int filasAfectadas = com.ExecuteNonQuery();
                    ok = filasAfectadas == 1;
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
            }            

            return ok;
        }
    }
}
