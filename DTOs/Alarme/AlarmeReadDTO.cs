using System;

namespace api.DTOs.Alarme
{
    public class AlarmeReadDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int Classificacao { get; set; }

        public string EquipamentoPK { get; set; }
    }
}