namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Abbonati")]
    public partial class Abbonati
    {
        [Key]
        public int subscriber_id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string subscription_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime subscription_start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime subscription_end_date { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
