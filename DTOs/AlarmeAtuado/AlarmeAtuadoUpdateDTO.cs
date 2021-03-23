using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AlarmeAtuado
{
    public class AlarmeAtuadoUpdateDTO
    {
        [Required]
        public bool Status { get; set; }
    }
}