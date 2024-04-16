namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giocatori")]
    public partial class Giocatori
    {
        [Key]
        public int player_id { get; set; }

        public int team_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        public decimal Altezza { get; set; }

        public bool Capitano { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_di_nascita { get; set; }

        public int Numero { get; set; }

        public virtual Squadra Squadra { get; set; }
    }
}
