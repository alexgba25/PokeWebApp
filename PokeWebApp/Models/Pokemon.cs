namespace PokeWebApp.Models
{
    public class Pokemon
    {
        // Paso 3: Modelo
        public int Id { get; set; }
        public string? Name { get; set; }
        public string[]? Types { get; set; }
        public string? ImageUrl { get; set; }
    }
}
