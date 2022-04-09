using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;

namespace WebMVC.Models
{
    public class ViewModelNacional : ViewModelProducto
    {
        public Nacional Producto { get; set; }
    }
}
