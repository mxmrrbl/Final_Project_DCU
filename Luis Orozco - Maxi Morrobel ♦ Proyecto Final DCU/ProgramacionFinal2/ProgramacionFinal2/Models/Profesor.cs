using System;
using System.Collections.Generic;

namespace ProgramacionFinal2.Models
{
    public partial class Profesor
    {
        public int IdProfesor { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? Nacimiento { get; set; }
        public int? IdArea { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
    }
}
