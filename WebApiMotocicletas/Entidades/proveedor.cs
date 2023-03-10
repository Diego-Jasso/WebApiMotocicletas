namespace WebApiMotocicletas.Entidades
{
    public class proveedor
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string RFC { get; set; }
        public int motos_disponibles { get; set; }
        public int MotocicletasId { get; set; }
        public motocicletas motocicletas { get; set; }
    }
}
