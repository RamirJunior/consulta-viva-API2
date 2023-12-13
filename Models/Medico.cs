using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace consulta_viva_API2.Models {
    public class Medico {
        public int? MedicoId { get; set; }
        public string Nome { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
    }
}
