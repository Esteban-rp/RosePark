namespace RosePark.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Telefono { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}

