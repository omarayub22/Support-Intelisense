using SupportIntelisense.Areas.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportIntelisense.Models
{
    public class Associate
    {
        [Key]
        public Guid AssciateId { get; set; }

        [Display(Name = "Associate Name")]
        [Required]
        [StringLength(100)]
        public string Associate_Name { get; set; }

        [Display(Name = "Designation")]
        [Required]
        [StringLength(100)]
        public string Designation { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}
