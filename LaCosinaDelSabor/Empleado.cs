namespace LaCosinaDelSabor.Models
{
    public class Empleado
    {
        public int Id { get; set; }  // Este será el id_empleado
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int SalarioMXN { get; set; }  // Cambiado a int
        public DateTime FechaContratacion { get; set; }
        public int IdPuesto { get; set; }
    }
}
