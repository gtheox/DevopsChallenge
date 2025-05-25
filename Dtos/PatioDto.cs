using System.Collections.Generic;

namespace MottuControlApi.Dtos
{
    public class PatioDto
    {
        public int Id { get; set; }

        // Nome do pátio (ex: "Pátio Central")
        public string Nome { get; set; } = string.Empty;

        // Lista de motos alocadas neste pátio
        public List<MotoDto>? Motos { get; set; }

        // Lista de imagens associadas ao pátio
        public List<ImagemDto>? Imagens { get; set; }
    }
}
