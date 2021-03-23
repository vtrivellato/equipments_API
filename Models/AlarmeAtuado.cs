using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class AlarmeAtuado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        [Required]
        public DateTime DataSaida { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public string DescricaoAlarme { get; set; }

        [Required]
        public string DescricaoEquipamento { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        public Equipamento Equipamento { get; set; }
        public Alarme Alarme { get; set; }
    }
}