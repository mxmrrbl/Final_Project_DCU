using System;
using System.Collections.Generic;

namespace ProgramacionFinal2.Models
{
    public partial class Area
    {
        public Area()
        {
            Profesors = new HashSet<Profesor>();
        }

        public int IdArea { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Profesor> Profesors { get; set; }
    }
}
