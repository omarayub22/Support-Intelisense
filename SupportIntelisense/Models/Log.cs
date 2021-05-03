using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportIntelisense.Models
{
    public class Log
    {
        public Guid LogId { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Display(Name = "Sr No")]
        [Required]
        [StringLength(100)]
        public string SrNo { get; set; }

        [Display(Name = "TiTle/ TFS")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Log Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Log_Date { get; set; }

        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }

        public Guid OriginatorId { get; set; }
        public Originator Originator { get; set; }

        [Display(Name = "Details")]
        [Required]
        [StringLength(100)]
        public string Details { get; set; }

        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        public Guid AssociateId { get; set; }
        public Associate Associate { get; set; }

        [Display(Name = "Close Date")]
        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; }


        [Display(Name = "Comments / Resolution")]
        public string Comments { get; set; }

    }
    public class Issue
    {
        public Guid IssueId { get; set; }

        [Display(Name = "Issue Type")]
        [Required]
        [StringLength(100)]
        public string Issue_Name { get; set; }
    }

    public class Priority
    {
        public Guid PriorityId { get; set; }

        [Display(Name = "Priority")]
        [Required]
        [StringLength(100)]
        public string Priority_Name{ get; set; }
    }

    public class Status
    {
        public Guid StatusId { get; set; }

        [Display(Name = "Status")]
        [Required]
        [StringLength(100)]
        public string Status_Name { get; set; }
    }

}
