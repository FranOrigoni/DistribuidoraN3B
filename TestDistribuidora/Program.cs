using System;
using System.Collections.Generic;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios;
using CasosDeUso;

namespace TestDistribuidora
{
    class Program
    {
        static void Main(string[] args)
        {
            IManejadorClientes manejadorClis = FabricaDeManejadores.ObtenerManejadorDeClientes();



            Cliente cli = new Cliente()
            {
                //Id = 4,
                Nombre = "Alta Manejador 2",
                Apellido = "Manejador 2",
                Telefono = "123123123",
                Email = "mail@manejador2.com",
                Puntos = 150,
                Contrasenia = "clavemanejador"
            };

            bool ok = manejadorClis.AgregarNuevoCLiente(cli);
            Console.WriteLine(ok);


            //Producto p = new Nacional()
            //{
            //    Nombre = "Nacional 1",
            //    Precio = 100,
            //    Codigo = 111,
            //    Stock = 200,
            //    Foto = "fotoNac1.jpg",
            //    Categoria = new Categoria() { Id = 1 },
            //    Proveedor = new Proveedor() { Id = 2 }
            //};

            //bool ok = repoProds.Add(p);
           

            //bool ok = repoClis.Remove(3);
            //Console.WriteLine(ok);

            //Cliente cli = new Cliente()
            //{
            //    Id = 4,
            //    Nombre = "Jorgito",
            //    Apellido = "Rodriguez",
            //    Telefono = "123123123",
            //    Email = "mail@gomez.com",
            //    Puntos = 100,
            //    Contrasenia = "clavejorge"
            //};

            //bool ok = repoClis.Update(cli);
            //Console.WriteLine(ok);

            //bool ok = repoClis.Add(nuevo);

            //IEnumerable<Cliente> clientes = repoClis.ClientesConPuntajeMayorA(100);

            //foreach (Cliente c in clientes)
            //{
            //    Console.WriteLine(c.ToString());
            //}
        }
    }
}
