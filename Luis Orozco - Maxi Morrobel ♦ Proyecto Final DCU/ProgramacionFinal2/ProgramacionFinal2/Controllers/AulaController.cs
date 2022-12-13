using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProgramacionFinal2.Models;
using ProgramacionFinal2.Models.ViewModels;
using System.Diagnostics;

namespace ProgramacionFinal2.Controllers
{
    public class AulaController : Controller
    {
        private readonly ProyectoFinalP2Context _DBContext;

        public AulaController(ProyectoFinalP2Context context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Aula> lista = _DBContext.Aulas.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Aula_Detalle(int idAula)
        {
            AulaVM oAulaVM = new AulaVM()
            {
                oAula = new Aula(),
                oListaAula = _DBContext.Aulas.Select(Aula => new SelectListItem()
                {
                    Text = Aula.Nombre,
                    Value = Aula.IdAula.ToString()

                }).ToList()
            };

            if (idAula != 0)
            {

                oAulaVM.oAula = _DBContext.Aulas.Find(idAula);
            }


            return View(oAulaVM);
        }

        [HttpPost]
        public IActionResult Aula_Detalle(AulaVM oAulaVM)
        {
            if (oAulaVM.oAula.IdAula == 0)
            {
                _DBContext.Aulas.Add(oAulaVM.oAula);

            }
            else
            {
                _DBContext.Aulas.Update(oAulaVM.oAula);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Aula");
        }

        [HttpGet]
        public IActionResult Eliminar(int idAula)
        {
            //Aula oAula = _DBContext.Aulas.Include(t => t.IdAula).Where(y => y.IdAula == idAula).FirstOrDefault();

            return View(/*oAula*/);
        }

        [HttpPost]
        public IActionResult Eliminar(Aula oAula)
        {
            _DBContext.Aulas.Remove(oAula);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Aula");
        }
    }
}
