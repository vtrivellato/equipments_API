using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Alarme
{
    public class AlarmeUpdateDTO
    {
        public string Descricao { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Classificacao field must have a value greater or equal than {1}")]
        public int Classificacao { get; set; }

        public string EquipamentoPK { get; set; }
    }
}