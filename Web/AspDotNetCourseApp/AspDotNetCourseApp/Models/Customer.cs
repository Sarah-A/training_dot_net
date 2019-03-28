using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCourseApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255,MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }
        
        [Display(Name="Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name="Membership Type")]
        [CustomValidation_Min18YearsForMembership]
        public MembershipTypeIds MembershipTypeId { get; set; }
    }
}