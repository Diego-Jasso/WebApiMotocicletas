namespace WebApiMotocicletas.Entidades
{
    public class motocicletas
    {
        public int Id { get; set; } 
        public int proveedorId { get; set; }
        public int modeloId { get; set; }
        public string color { get; set; }
        public string descripcion { get; set; }
    }
}
