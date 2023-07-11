using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_Proyecto.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_Core_Proyecto.Pages.ListaLibros
{
    public class EditarModel : PageModel
    {
        private ApplicationDBContext _db;

        public EditarModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Libro Libro { get; set; }

        public async Task OnGet(int id)
        {
            Libro = await _db.Libro.FindAsync(id); //busca de acuerdo al id
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var librodb = await _db.Libro.FindAsync(Libro.Id);
                librodb.Nombre = Libro.Nombre;
                librodb.Autor = Libro.Autor;
                librodb.ISBM = Libro.ISBM;
                await _db.SaveChangesAsync(); // guarda los datos en la base de datos
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
