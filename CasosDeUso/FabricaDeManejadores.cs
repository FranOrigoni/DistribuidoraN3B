using System;
using System.Collections.Generic;
using System.Text;
using Repositorios;
using Microsoft.Extensions.Configuration;
using Dominio.InterfacesRepositorio;

namespace CasosDeUso
{
    public class FabricaDeManejadores
    {
        public static IManejadorClientes ObtenerManejadorDeClientes()
        {
            ManejadorClientes man = null;
            string tipoRepo = "";
            IRepositorioClientes  repo;
           

            ConfigurationBuilder cb = new ConfigurationBuilder();
            cb.AddJsonFile("appsettings.json");
            IConfiguration configuracion = cb.Build();

            tipoRepo = configuracion.GetSection("TipoRepos").Value;

            if (tipoRepo == "ADO")
            {
                repo = new RepositorioClientesADO();
            }
            else if (tipoRepo == "MEMORIA")
            {
                repo = new RepositorioClientesMemoria();
            }
            else
            {
                throw new Exception("NO EXISTE EL TIPO DE REPOSITORIO O NO FUE ESPECIFICADO EN EL ARCHIVO DE CONFIG");
            }

            man = new ManejadorClientes(repo);

             return man;
        }
    }
}
