using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MottuControlApi.Models
{
    [Table("Motos")]
    public class Moto
    {
        // Chave primária
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Modelo da moto (Ex: Honda Pop 110i)
        [Required]
        [MaxLength(100)]
        public string Modelo { get; set; } = string.Empty;

        // Placa da moto
        [Required]
        [MaxLength(10)]
        public string Placa { get; set; } = string.Empty;

        // Status atual da moto
        [Required]
        [MaxLength(30)]
        public string Status { get; set; } = string.Empty;

        // Chave estrangeira para o pátio
        public int PatioId { get; set; }

        // Navegação: Pátio onde a moto está
        public Patio Patio { get; set; } = null!;

        // Relacionamento: sensores IoT ligados a essa moto
        public ICollection<SensorIoT> Sensores { get; set; } = new List<SensorIoT>();

        // Relacionamento: histórico de status da moto
        public List<StatusMonitoramento> HistoricoStatus { get; set; } = new List<StatusMonitoramento>();
    }
}
