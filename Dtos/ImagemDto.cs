using System;

namespace MottuControlApi.Dtos
{
    public class ImagemDto
    {
        public int Id { get; set; }

        // Caminho da imagem (local ou URL)
        public string CaminhoImagem { get; set; } = string.Empty;

        // Data/hora da captura da imagem
        public DateTime DataCaptura { get; set; }

        // ID do pátio associado à imagem
        public int PatioId { get; set; }

        // Nome do pátio (opcional)
        public string? NomePatio { get; set; }
    }
}
