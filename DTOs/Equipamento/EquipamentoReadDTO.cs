using System;

namespace api.DTOs.Equipamento
{
    public class EquipamentoReadDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public string NumeroSerie { get; set; }

        public string Tipo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}