using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios;





namespace CasosDeUso
{
    public class ManejadorClientes : IManejadorClientes
    {
        public IRepositorioClientes Repoclientes { get; set; }

        public ManejadorClientes(IRepositorioClientes repo)
        {
            Repoclientes = repo;
        }

        public bool AgregarNuevoCLiente(Cliente c)
        {
            // RepositorioClientesADO repoclis = new RepositorioClientesADO();

            return Repoclientes.Add(c);
        }

        public bool DarDeBajaCliente(int id)
        {
            return Repoclientes.Remove(id);
        }

        public IEnumerable<Cliente> TraerTodosLosClientes()
        {
            return Repoclientes.FindAll();
        }

        // resto de operaciones crud y funcionalides (casos de uso) de clientes 
    }
}
