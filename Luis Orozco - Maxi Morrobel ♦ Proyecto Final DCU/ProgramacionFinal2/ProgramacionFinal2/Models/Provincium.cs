using System;
using System.Collections.Generic;

namespace ProgramacionFinal2.Models
{
    public partial class Provincium
    {
        public Provincium()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int IdProvincia { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
