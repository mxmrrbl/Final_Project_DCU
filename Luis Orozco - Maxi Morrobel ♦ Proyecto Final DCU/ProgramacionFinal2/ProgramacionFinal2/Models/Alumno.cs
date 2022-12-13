using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionFinal2.Models
{
    public partial class Alumno
    {
        public int IdAlumno { get; set; }
        public string? Matricula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; } 
        public DateTime? Nacimiento { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincium? IdProvinciaNavigation { get; set; }
    }
}
