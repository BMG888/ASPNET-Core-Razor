using ASPNET_Core_Proyecto.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Proyecto.Controllers
{
    [Route("api/Libro")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ApplicationDBContext _db;

        public LibroController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string filtro = "borrado";
            var libros = _db.Libro.Where(u => u.DeletedDate == null).ToList();
            var libros2 = (from l in _db.Libro
                           where l.Nombre != filtro
                           select l.Id).ToList();
            return Json(new { data = libros}); // recupera el libro y lo pasa cada vez que se llame esta API
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var libroBD = await _db.Libro.FirstOrDefaultAsync(u=>u.Id == id);
            if(libroBD == null)
            {
                return Json(new { success = false, message = "Error al eliminar." });
            }
            libroBD.DeletedDate = DateTime.Now;
            _db.Libro.Update(libroBD);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado." });
        }
    }
}
