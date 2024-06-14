using System.ComponentModel.DataAnnotations.Schema;

namespace PPIChallengeAPI.Models.Entities
{
    public class Activo
    {
        public int id { get; set; }
        public string ticker { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public int tipoActivo { get; set; }
        [NotMapped]
        public string activoDescripcion { get; set; } = string.Empty;
        public decimal precioUnitario { get; set; }

    }
}
