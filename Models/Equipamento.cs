using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Equipamento 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(32)]
        public string NumeroSerie { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        public IEnumerable<Alarme> Alarmes { get; set; }
    }

    public enum Tipo
    {
        Tensao = 1, 
        Corrente, 
        Oleo
    }
}