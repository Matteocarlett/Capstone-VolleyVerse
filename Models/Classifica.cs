namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classifica")]
    public partial class Classifica
    {
        [Key]
        public int classifica_id { get; set; }

        public int team_id { get; set; }

        public int points { get; set; }

        public int games_played { get; set; }

        public int wins { get; set; }

        public int losses { get; set; }

        public virtual Squadra Squadra { get; set; }
    }
}
