using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProgramacionFinal2.Models;
using ProgramacionFinal2.Models.ViewModels;
using System.Diagnostics;

namespace ProgramacionFinal2.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ProyectoFinalP2Context _DBContext;

        public EmpleadoController(ProyectoFinalP2Context context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Empleado> lista = _DBContext.Empleados.Include(d => d.IdDepartamentoNavigation).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Empleado_Detalle(int idEmpleado)
        {
            EmpleadoVM oEmpleadoVM = new EmpleadoVM()
            {
                oEmpleado = new Empleado(),
                oListaDepartamento = _DBContext.Departamentos.Select(Departamento => new SelectListItem()
                {
                    Text = Departamento.Descripcion,
                    Value = Departamento.IdDepartamento.ToString()

                }).ToList()
            };

            if (idEmpleado != 0)
            {

                oEmpleadoVM.oEmpleado = _DBContext.Empleados.Find(idEmpleado);
            }


            return View(oEmpleadoVM);

        }

        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM)
        {
            if (oEmpleadoVM.oEmpleado.IdEmpleado == 0)
            {
                _DBContext.Empleados.Add(oEmpleadoVM.oEmpleado);

            }
            else
            {
                _DBContext.Empleados.Update(oEmpleadoVM.oEmpleado);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Empleado");
        }

        [HttpGet]
        public IActionResult Eliminar(int idEmpleado)
        {
            Empleado oEmpleado = _DBContext.Empleados.Include(d => d.IdDepartamentoNavigation).Where(r => r.IdEmpleado == idEmpleado).FirstOrDefault();

            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Eliminar(Empleado oEmpleado)
        {
            _DBContext.Empleados.Remove(oEmpleado);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Empleado");
        }
    }
}
