using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesNegocio
{
    public class Cliente : IValidable
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int Puntos { get; set; }

        public bool SoyValido()
        {
            //PENDIENTE IMPLEMENTARLO
            return true;
        }
        public override string ToString()
        {
            return Id + " " + Nombre + " " + Apellido + " " + Email;
        }
    }
}
