using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MottuControlApi.Models
{
    [Table("ImagensPatio")]
    public class ImagemPatio
    {
        // Chave primária
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Caminho da imagem (URL ou caminho local)
        [Required]
        [MaxLength(255)]
        public string CaminhoImagem { get; set; } = string.Empty;

        // Data e hora da captura da imagem
        public DateTime DataCaptura { get; set; }

        // Chave estrangeira para o pátio
        public int PatioId { get; set; }

        // Navegação: referência ao pátio da imagem
        public Patio Patio { get; set; } = null!;
    }
}
