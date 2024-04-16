namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendite")]
    public partial class Vendite
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Proprietario { get; set; }

        [Required]
        [StringLength(16)]
        public string CodFiscale { get; set; }

        [Required]
        [StringLength(100)]
        public string NumRicetta { get; set; }

        public DateTime DataVendita { get; set; }
    }
}
