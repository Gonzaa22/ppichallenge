namespace PPIChallengeAPI.Models.Entities
{
    public class Orden
    {
        public int id { get; set; }
        public int cuentaID { get; set; }
        public string activoNombre { get; set; } = string.Empty;
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public char operacion { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; } = string.Empty;
        public decimal montoTotal { get; set; }
    }
}
