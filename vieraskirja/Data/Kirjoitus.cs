using System.ComponentModel.DataAnnotations;

namespace vieraskirja.Data
{
    public class Kirjoitus
    {
        public int Id { get; set; }
        [Required]
        public string Kirjoittaja { get; set; } = string.Empty;
        [Required]
        public string Viesti { get; set; } = string.Empty;
        public DateTime PVM { get; set; }
    }
}
