namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calendario")]
    public partial class Calendario
    {
        [Key]
        public int match_id { get; set; }

        public int team_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime match_date { get; set; }

        public TimeSpan match_time { get; set; }

        public int? away_team_id { get; set; }

        public int? home_team_score { get; set; }

        public int? away_team_score { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        public virtual Squadra Squadra { get; set; }

        public virtual Squadra Squadra1 { get; set; }

        public virtual Squadra Squadra2 { get; set; }
    }
}
