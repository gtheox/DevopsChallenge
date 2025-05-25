namespace MottuControlApi.Dtos
{
    public class SensorDto
    {
        public int Id { get; set; }

        // Nome do sensor (ex: "Sensor GPS A")
        public string Nome { get; set; } = string.Empty;

        // Tipo do sensor (ex: GPS, RFID, etc.)
        public string Tipo { get; set; } = string.Empty;

        // ID da moto à qual o sensor está vinculado
        public int MotoId { get; set; }

        // Placa da moto associada (opcional)
        public string? PlacaMoto { get; set; }
    }
}
