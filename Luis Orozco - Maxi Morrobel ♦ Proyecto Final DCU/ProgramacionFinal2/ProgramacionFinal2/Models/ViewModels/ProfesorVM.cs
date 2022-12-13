using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgramacionFinal2.Models.ViewModels
{
    public class ProfesorVM
    {
        public  Profesor oProfesor { get; set; }
        public List<SelectListItem> oListaArea { get; set; }
    }
}
