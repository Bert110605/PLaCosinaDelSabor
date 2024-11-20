namespace LaCosinaDelSabor.Models
{
    public class Plato
    {
        public int IdPlato { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string ValorNutricional { get; set; }
        public int IdCategoria { get; set; }
    }
}
