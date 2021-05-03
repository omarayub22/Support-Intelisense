using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SupportIntelisense.Areas.Identity
{
    public class ApplicationUser : IdentityUser

        // add profile data for application users by adding properties to the ApplicationUser class
    {
        [PersonalData]
        [StringLength(100)]
        [Display(Name = "Profile Picture")]
        public string FullName { get; set; }

        [PersonalData]
        [StringLength(250)]
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; } = "/images/empty-profile.png";

        public bool IsSuperAdmin { get; set; } = false;

        public bool IsAssociate { get; set; } = false;

    }
}
