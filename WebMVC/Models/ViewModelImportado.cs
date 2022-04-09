using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;

namespace WebMVC.Models
{
    public class ViewModelImportado : ViewModelProducto
    {
        public Importado Producto  { get; set; }

    }
}
