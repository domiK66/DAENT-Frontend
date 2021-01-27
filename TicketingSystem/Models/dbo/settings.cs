namespace TicketingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class settings
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string value { get; set; }

        [StringLength(100)]
        public string description { get; set; }
    }
}
