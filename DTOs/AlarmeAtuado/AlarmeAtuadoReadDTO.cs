using System;

namespace api.DTOs.AlarmeAtuado
{
    public class AlarmeAtuadoReadDTO
    {
        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        public bool Status { get; set; }

        public string DescricaoAlarme { get; set; }

        public string DescricaoEquipamento { get; set; }
    }
}