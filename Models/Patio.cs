using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MottuControlApi.Models
{
    [Table("Patios")]
    public class Patio
    {
        // Chave primária
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nome ou identificação do pátio
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        // Relacionamento: Um pátio pode ter várias motos
        public ICollection<Moto> Motos { get; set; } = new List<Moto>();

        // Relacionamento: Um pátio pode ter várias imagens
        public ICollection<ImagemPatio> Imagens { get; set; } = new List<ImagemPatio>();
    }
}
