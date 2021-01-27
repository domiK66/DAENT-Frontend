namespace TicketingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

        public partial class Suche

        {
            [Key]
            [StringLength(20)]
            public string suchbegriff { get; set; }

        }
}