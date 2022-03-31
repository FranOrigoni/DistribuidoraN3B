using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioProductos : IRepositorio<Producto>
    {

        IEnumerable<Producto> ProductosEnRangoDePrecio(decimal desde, decimal hasta);
    }
}
