using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Equipamento
{
    public class EquipamentoUpdateDTO
    {
        public string Nome { get; set; }

        public string NumeroSerie { get; set; }
    }
}