using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgramacionFinal2.Models.ViewModels
{
    public class AulaVM
    {
        public Aula oAula { get; set; }
        public List<SelectListItem> oListaAula { get; set; }
    }
}
