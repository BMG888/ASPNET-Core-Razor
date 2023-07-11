using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Proyecto.Model
{
    public class Libro
    {
        [Key] // agrega automaticamente un id
        public int Id { get; set; }

        [Required] // esto hace que el campo no pueda ser nulo
        public string Nombre { get; set; }

        public string Autor { get; set; }

        public string ISBM { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
