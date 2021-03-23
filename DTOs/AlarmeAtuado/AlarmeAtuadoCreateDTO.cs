using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AlarmeAtuado
{
    public class AlarmeAtuadoCreateDTO
    {
        [Required]
        public DateTime DataEntrada { get; set; }

        [Required]
        public string DescricaoAlarme { get; set; }

        [Required]
        public string DescricaoEquipamento { get; set; }
    }
}