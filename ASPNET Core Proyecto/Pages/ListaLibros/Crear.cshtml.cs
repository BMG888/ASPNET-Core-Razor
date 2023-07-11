using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_Proyecto.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_Core_Proyecto.Pages.ListaLibros
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public CrearModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Libro Libro { get; set;}

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Libro.AddAsync(Libro);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
