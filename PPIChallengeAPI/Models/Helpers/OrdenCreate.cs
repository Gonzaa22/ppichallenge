namespace PPIChallengeAPI.Models.Helpers
{
    public class OrdenCreate
    {
        public int cuentaId { get; set; }
        public string activoNombre { get; set; } = string.Empty;
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public char operacion { get; set; }
    }
}
