using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;


namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioClientes : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> ClientesConPuntajeMayorA(int puntos);
        Cliente BuscarClientePorEmail(string email);
    }
}
