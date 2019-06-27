using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_RafaelAbreu.Entidades
{
    public class InscripcionDetalle
    {
        [Key]
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public int AsignaturaId { get; set; }
        public decimal SubTotal { get; set; }

        public InscripcionDetalle()
        {
            Id = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            SubTotal = 0;
        }
    }
}
