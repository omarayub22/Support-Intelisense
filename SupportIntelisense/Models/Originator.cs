using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportIntelisense.Models
{
    public class Originator
    {
        public Guid OriginatorId { get; set; }

        [Display(Name = "Rised By")]
        [Required]
        [StringLength(100)]
        public string Originator_Name { get; set; }

        [Display(Name = "Company")]
        [Required]
        [StringLength(100)]
        public string Originator_Company { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Display(Name = "Remote Connection")]
        [Required]
        [StringLength(100)]
        public string Remote_Number { get; set; }
    }
}
