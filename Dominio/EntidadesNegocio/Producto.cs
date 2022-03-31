using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesNegocio
{
    public abstract class Producto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Foto { get; set; }
        public Categoria Categoria { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<Valoracion> Valoraciones { get; set; }

        public bool Validar()
        {
            //PENDIENTE
            return true;
        }
        public abstract string Tipo();

    }
}
