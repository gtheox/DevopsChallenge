using System.Collections.Generic;

namespace MottuControlApi.Dtos
{
    public class MotoDto
    {
        public int Id { get; set; }

        // Modelo da moto (ex: "Honda Biz")
        public string Modelo { get; set; } = string.Empty;

        // Placa da moto
        public string Placa { get; set; } = string.Empty;

        // Status atual da moto (ex: "Disponível", "Alugada", "Manutenção")
        public string Status { get; set; } = string.Empty;

        // ID do pátio onde a moto está alocada
        public int PatioId { get; set; }

        // Nome do pátio (propriedade adicional para visualização)
        public string? NomePatio { get; set; }

        // Lista de sensores IoT associados à moto
        public List<SensorDto>? Sensores { get; set; }

        // Histórico de status da moto
        public List<StatusDto>? StatusMonitoramentos { get; set; }
    }
}
