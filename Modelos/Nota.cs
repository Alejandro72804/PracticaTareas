namespace PracticaTareas.Modelos
{
    public class Nota
    {
        public string Nombre { get; set; } = string.Empty;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descripcion { get; set; } = string.Empty;
        public bool Activa { get; set; } = false;
        public string img { get; set; } = string.Empty;
        public bool Archiva { get; set; } = false;
    }
}