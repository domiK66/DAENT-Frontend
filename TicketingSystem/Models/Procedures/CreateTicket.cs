using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    // klasse für den aufruf der prozedur
    public class CreateTicket
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Range (1,100)]
        public int category { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        [Range(1, 100)]
        public int customer { get; set; }
    }
}
