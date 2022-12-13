using System;
using System.Collections.Generic;

namespace ProgramacionFinal2.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? Nacimiento { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Departamento? IdDepartamentoNavigation { get; set; }
    }
}
