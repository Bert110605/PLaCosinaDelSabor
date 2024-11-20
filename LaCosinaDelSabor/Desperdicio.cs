namespace LaCosinaDelSabor.Models
{
    public class Desperdicio
    {
        public int IdDesperdicio { get; set; }
        public int IdPlato { get; set; }
        public decimal CantidadPlato { get; set; }
        public int IdIngrediente { get; set; }
        public decimal CantidadIngrediente { get; set; }
        public string Unidad { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
