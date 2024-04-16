namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notizie")]
    public partial class Notizie
    {
        [Key]
        public int news_id { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; }

        [Required]
        public string content { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_published { get; set; }

        [StringLength(255)]
        public string image_url { get; set; }

        [StringLength(255)]
        public string video_url { get; set; }

        [Required]
        [StringLength(50)]
        public string category { get; set; }
    }
}
