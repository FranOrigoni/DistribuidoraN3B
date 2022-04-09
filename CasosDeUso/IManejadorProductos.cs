using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesNegocio;

namespace CasosDeUso
{
    public interface IManejadorProductos
    {
        public IEnumerable<Producto> TraerTodosLosProductos();

        public bool AgregarNuevoProducto(Producto prod, int idCategoria, int idProveedor);

        IEnumerable<Categoria> TraerTodasLasCategorias();
        IEnumerable<Proveedor> TraerTodosLosProveedores();

    }
}
