using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Alarme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Descricao { get; set; }

        [Required]
        public Classificacao Classificacao { get; set; }

        [Required]
        public string EquipamentoPK { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        public Equipamento Equipamento { get; set; }
    }

    public enum Classificacao
    {
        Baixo = 1,
        Medio,
        Alto
    }
}