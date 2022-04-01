using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;



namespace CasosDeUso
{
     public interface IManejadorClientes
    {

        bool AgregarNuevoCLiente(Cliente c);

        bool DarDeBajaCliente(int id);

    }
}
