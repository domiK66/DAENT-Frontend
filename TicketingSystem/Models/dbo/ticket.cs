namespace TicketingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ticket")]
    public partial class ticket
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string subject { get; set; }

        [StringLength(255)]
        public string ticket_content { get; set; }

        public int? customer_number { get; set; }

        public int? agent { get; set; }

        public int? status { get; set; }

        public byte? category { get; set; }

        public byte? priority { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_at { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? completed_at { get; set; }

        public virtual customers customers { get; set; }

        public virtual staff staff { get; set; }

        public virtual ticket_categories ticket_categories { get; set; }

        public virtual ticket_priorities ticket_priorities { get; set; }

        public virtual ticket_statuses ticket_statuses { get; set; }
    }
}
