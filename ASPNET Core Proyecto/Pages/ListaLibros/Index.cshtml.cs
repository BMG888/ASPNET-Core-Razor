using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_Proyecto.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_Core_Proyecto.Pages.ListaLibros
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IndexModel(ApplicationDBContext db) //utiliza lo que esta en la dependencyinjection container y lo inhecta en esta pagina
        {
            _db = db;
        }

        public IEnumerable<Libro> Libros { get; set; }

        public async Task OnGet() // los libros se ven a traves de este handler
        {
            Libros = await _db.Libro.ToListAsync(); // va a la base de datos y recupera los datos para guardarlos y utilizarlos en el Ienumerable
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var libro = await _db.Libro.FindAsync(id);
            if (libro == null) // si no existe
            {
                return NotFound();
            }
            _db.Libro.Remove(libro); // caso contrario se elimina el libro con el id asignado
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
