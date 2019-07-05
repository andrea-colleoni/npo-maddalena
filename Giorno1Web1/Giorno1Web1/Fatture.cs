namespace Giorno1Web1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fatture")]
    public partial class Fatture
    {
        public int id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        public DateTime? data { get; set; }

        public int? numero { get; set; }
    }
}
