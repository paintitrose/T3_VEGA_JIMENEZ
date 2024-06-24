using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using T3_Jimenez_Diego.Datos;
using T3_Jimenez_Diego.Models;

namespace T3_Jimenez_Diego.Controllers
{
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LibroController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _db.Libros;
            return View(listaLibros);
        }

        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }

        //Crear Libro
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libros.Add(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(libro);
        }

        [Authorize]
        //Get Editar
        public IActionResult Editar(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _db.Libros.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Editar
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libros.Update(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        [Authorize]
        //Get Eliminar
        public IActionResult Eliminar(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _db.Libros.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Eliminar(Libro libro)
        {
            if (libro == null)
            {
                return NotFound();
            }
            _db.Libros.Remove(libro);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        //Libros de Arquitectura de Software
        public IActionResult arquitectura()
        {
            return View();
        }
        //Libros de Diseño de Software
        public IActionResult diseño()
        {
            return View();
        }
    }
}
