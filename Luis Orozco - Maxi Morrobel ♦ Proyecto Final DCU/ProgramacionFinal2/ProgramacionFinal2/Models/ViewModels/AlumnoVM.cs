using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgramacionFinal2.Models.ViewModels
{
    public class AlumnoVM
    {
        public Alumno oAlumno { get; set; }
        public List<SelectListItem> oListaProvincia { get; set; }
    }
}
