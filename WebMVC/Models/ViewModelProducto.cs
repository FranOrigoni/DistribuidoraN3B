using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;

namespace WebMVC.Models
{
    public class ViewModelProducto
    {
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Proveedor> Proveedores { get; set; }

        public IFormFile Imagen { get; set; }

        public int IdCategoriaSeleccionada { get; set; }
        public int IdProveedorSeleccionado { get; set; }

    }
}
