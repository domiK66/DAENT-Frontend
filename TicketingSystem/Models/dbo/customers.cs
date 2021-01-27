namespace TicketingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customers()
        {
            customer_addresses = new HashSet<customer_addresses>();
            ticket = new HashSet<ticket>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }


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

        public bool locked { get; set; }

        public byte salutation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_addresses> customer_addresses { get; set; }

        public virtual salutations salutations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> ticket { get; set; }
    }
}
