using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Equipamento
{
    public class EquipamentoCreateDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string NumeroSerie { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Tipo field must have a value greater or equal than {1}")]
        public int Tipo { get; set; }
    }
}