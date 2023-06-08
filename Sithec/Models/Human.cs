using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sithec.Models
{
    [Table("Human")]
    public class Human
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sexo { get; set; }
        public int Edad { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
    }
}