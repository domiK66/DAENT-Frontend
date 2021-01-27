namespace TicketingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            ticket = new HashSet<ticket>();
            ticket_categories = new HashSet<ticket_categories>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        public byte ticket_queue { get; set; }

        public int finished_tickets { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_login { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        public byte failed_logins { get; set; }

        public int? address { get; set; }

        public byte salutation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? absence_begin { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? absence_end { get; set; }

        public virtual addresses addresses { get; set; }

        public virtual salutations salutations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> ticket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket_categories> ticket_categories { get; set; }
    }
}
