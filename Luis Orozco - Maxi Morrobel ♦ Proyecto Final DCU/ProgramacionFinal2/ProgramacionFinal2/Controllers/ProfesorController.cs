using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProgramacionFinal2.Models;
using ProgramacionFinal2.Models.ViewModels;
using System.Diagnostics;

namespace ProgramacionFinal2.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly ProyectoFinalP2Context _DBContext;

        public ProfesorController(ProyectoFinalP2Context context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Profesor> lista = _DBContext.Profesors.Include(a=> a.IdAreaNavigation).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Profesor_Detalle(int idProfesor)
        {
            ProfesorVM oProfesorVM = new ProfesorVM()
            {
                oProfesor = new Profesor(),
                oListaArea = _DBContext.Areas.Select(Area => new SelectListItem()
                {
                    Text = Area.Descripcion,
                    Value = Area.IdArea.ToString()

                }).ToList()
            };

            if (idProfesor != 0)
            {

                oProfesorVM.oProfesor = _DBContext.Profesors.Find(idProfesor);
            }


            return View(oProfesorVM);
        }

        [HttpPost]
        public IActionResult Profesor_Detalle(ProfesorVM oProfesorVM)
        {
            if (oProfesorVM.oProfesor.IdProfesor == 0)
            {
                _DBContext.Profesors.Add(oProfesorVM.oProfesor);

            }
            else
            {
                _DBContext.Profesors.Update(oProfesorVM.oProfesor);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Profesor");
        }

        [HttpGet]
        public IActionResult Eliminar(int idProfesor)
        {
            Profesor oProfesor = _DBContext.Profesors.Include(a => a.IdAreaNavigation).Where(u => u.IdProfesor == idProfesor).FirstOrDefault();

            return View(oProfesor);
        }

        [HttpPost]
        public IActionResult Eliminar(Profesor oProfesor)
        {
            _DBContext.Profesors.Remove(oProfesor);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Profesor");
        }
    }
}
