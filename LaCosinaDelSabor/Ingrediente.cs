namespace LaCosinaDelSabor.Models
{
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Origen { get; set; }
        public bool Sostenibilidad { get; set; }
        public int IdProveedor { get; set; }
    }
}
