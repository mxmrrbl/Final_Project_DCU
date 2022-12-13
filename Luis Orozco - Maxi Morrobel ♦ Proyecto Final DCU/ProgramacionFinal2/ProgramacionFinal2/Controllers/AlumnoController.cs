using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProgramacionFinal2.Models;
using ProgramacionFinal2.Models.ViewModels;
using System.Diagnostics;

namespace ProgramacionFinal2.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ProyectoFinalP2Context _DBContext;

        public AlumnoController(ProyectoFinalP2Context context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Alumno> lista = _DBContext.Alumnos.Include(p => p.IdProvinciaNavigation).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Alumno_Detalle(int idAlumno)
        {
            AlumnoVM oAlumnoVM = new AlumnoVM()
            {
                oAlumno = new Alumno(),
                oListaProvincia = _DBContext.Provincia.Select(Provincium => new SelectListItem()
                {
                    Text = Provincium.Descripcion,
                    Value = Provincium.IdProvincia.ToString()

                }).ToList()
            };

            if (idAlumno != 0) {

                oAlumnoVM.oAlumno = _DBContext.Alumnos.Find(idAlumno);
            }


            return View(oAlumnoVM);
        }

        [HttpPost]
        public IActionResult Alumno_Detalle(AlumnoVM oAlumnoVM)
        {
            if (oAlumnoVM.oAlumno.IdAlumno == 0)
            {
                _DBContext.Alumnos.Add(oAlumnoVM.oAlumno);

            }
            else {
                _DBContext.Alumnos.Update(oAlumnoVM.oAlumno);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Alumno");
        }

        [HttpGet]
        public IActionResult Eliminar(int idAlumno)
        {
            Alumno oAlumno = _DBContext.Alumnos.Include(p => p.IdProvinciaNavigation).Where(r => r.IdAlumno == idAlumno).FirstOrDefault();

            return View(oAlumno);
        }

        [HttpPost]
        public IActionResult Eliminar(Alumno oAlumno)
        {
            _DBContext.Alumnos.Remove(oAlumno);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Alumno");
        }
    }
}
