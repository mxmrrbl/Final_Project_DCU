using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgramacionFinal2.Models.ViewModels
{
    public class EmpleadoVM
    {
        public Empleado oEmpleado { get; set; }
        public List<SelectListItem> oListaDepartamento { get; set; }
    }
}
