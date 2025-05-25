using System;

namespace MottuControlApi.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }

        // Status da moto (ex: "Disponível", "Alugada")
        public string Status { get; set; } = string.Empty;

        // Data e hora em que o status foi registrado
        public DateTime DataHora { get; set; }

        // ID da moto associada a este status
        public int MotoId { get; set; }

        // Placa da moto (opcional)
        public string? PlacaMoto { get; set; }
    }
}
