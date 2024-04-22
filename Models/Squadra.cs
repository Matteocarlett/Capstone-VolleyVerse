namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Squadra")]
    public partial class Squadra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Squadra()
        {
            Calendario = new HashSet<Calendario>();
            Calendario1 = new HashSet<Calendario>();
            Calendario2 = new HashSet<Calendario>();
            Giocatori = new HashSet<Giocatori>();
        }

        [Key]
        public int team_id { get; set; }

        [Required]
        [StringLength(100)]
        public string team_name { get; set; }

        public int coach_id { get; set; }

        public string photo { get; set; }

        public string logo_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calendario> Calendario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calendario> Calendario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calendario> Calendario2 { get; set; }

        public virtual Coach Coach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giocatori> Giocatori { get; set; }
    }
}
