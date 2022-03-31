using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;

namespace Repositorios
{
    public class RepositorioClientesMemoria : IRepositorioClientes
    {
        private static int ultId = 1;

        private List<Cliente> clientes = new List<Cliente>();

        #region IREPOSITORIO

        public bool Add(Cliente obj)
        {
            bool ok = false;

            if (obj.SoyValido() == true && BuscarClientePorEmail(obj.Email) == null)
            {
                obj.Id = ultId++;
                clientes.Add(obj);
                ok = true;
            }
            
            return ok;
        }

        public Cliente BuscarClientePorEmail(string email)
        {
            Cliente buscado = null;

            int indice = 0;
            while (buscado == null && indice < clientes.Count)
            {
                Cliente cli = clientes[indice];
                if (cli.Email == email) buscado = cli;                
                indice++;
            }

            return buscado;
        }

        public IEnumerable<Cliente> FindAll()
        {
            return clientes;
        }

        public Cliente FindById(int id)
        {
            Cliente buscado = null;

            int indice = 0;
            while (buscado == null && indice < clientes.Count)
            {
                Cliente cli = clientes[indice];
                if (cli.Id == id) buscado = cli;
                indice++;
            }

            return buscado;
        }

        public bool Remove(int id)
        {
            bool ok = false;

            Cliente aBorrar = FindById(id);
            if (aBorrar != null) ok = clientes.Remove(aBorrar);

            return ok;
        }

        public bool Update(Cliente obj)
        {
            bool ok = false;            

            if (obj.SoyValido())
            {
                Cliente aModificar = FindById(obj.Id);
                if (aModificar != null)
                {
                    if (aModificar.Email == obj.Email || BuscarClientePorEmail(obj.Email) == null)
                    {
                        aModificar.Nombre = obj.Nombre;
                        aModificar.Apellido = obj.Apellido;
                        aModificar.Telefono = obj.Telefono;
                        aModificar.Email = obj.Email;
                        aModificar.Contrasenia = obj.Contrasenia;
                        aModificar.Puntos = obj.Puntos;
                        
                        ok = true;
                    }                    
                }
            }

            return ok;
        }

        #endregion

        #region IREPOSITORIOCLIENTE
        public IEnumerable<Cliente> ClientesConPuntajeMayorA(int puntos)
        {
            List<Cliente> clientesAux = new List<Cliente>();

            foreach(Cliente cli in clientes)
            {
                if (cli.Puntos > puntos) clientesAux.Add(cli);
            }

            return clientesAux;
        }

        #endregion

    }
}
