namespace VolleyVerse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        public int shop_id { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
