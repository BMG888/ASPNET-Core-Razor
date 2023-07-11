using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Proyecto.Model
{
    public class ApplicationDBContext : DbContext //este ultimo es del entityframework para la base de datos
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opciones) : base(opciones) // base depende de este constructor (constructor para dependencyinjection)
        {

        }

        public DbSet<Libro> Libro { get; set; }
    }
}
