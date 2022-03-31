using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesNegocio
{
    public class Nacional : Producto
    {
        public bool EcoAmigable { get; set; }
        public static decimal TasaBonificacion { get; set; }

        public override string Tipo()
        {
            return "Nacional";
        }
    }
}
