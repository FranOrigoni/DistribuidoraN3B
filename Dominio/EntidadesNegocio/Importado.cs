using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesNegocio
{
    public class Importado : Producto
    {
        public sbyte PaisOrigen { get; set; }
        public static decimal ImpuestoImportacion { get; set; }

        public override string Tipo()
        {
            return "Importado";
        }
    }
}
