using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesNegocio
{
    public class Valoracion
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }
        public string Comentario { get; set; }
        public string Alias { get; set; }
    }
}
