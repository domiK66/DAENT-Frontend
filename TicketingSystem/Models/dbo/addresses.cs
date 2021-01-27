namespace TicketingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class addresses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public addresses()
        {
            customer_addresses = new HashSet<customer_addresses>();
            staff = new HashSet<staff>();
        }

        public int id { get; set; }

        [StringLength(80)]
        public string streetname { get; set; }

        public int? postalcode { get; set; }

        [StringLength(80)]
        public string cityname { get; set; }

        [StringLength(2)]
        public string country { get; set; }

        public virtual countries countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_addresses> customer_addresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staff { get; set; }
    }
}
