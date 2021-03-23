using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Alarme
{
    public class AlarmeCreateDTO
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Classificacao field must have a value greater or equal than {1}")]
        public int Classificacao { get; set; }

        [Required]

        public string EquipamentoPK { get; set; }
    }
}