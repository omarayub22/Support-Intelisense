using SupportIntelisense.Areas.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportIntelisense.Models
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        [Display(Name = "Sr No")]
        [Required]
        [StringLength(100)]
        public string SrNo { get; set; }
        [Display(Name = "Org / Project Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Discription")]
        [Required]
        [StringLength(100)]
        public string Discription { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime MentionDate { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Log> Log { get; set; }

        //public ICollection<Associate> Associate { get; set; }

        //public ICollection<Originator> Originator { get; set; }


    }
}
