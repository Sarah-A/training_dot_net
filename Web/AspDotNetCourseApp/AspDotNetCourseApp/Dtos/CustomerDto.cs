using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AspDotNetCourseApp.Models;


namespace AspDotNetCourseApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        [Display(Name = "Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        // Note: Since MembersipType is a Model Object, we should NEVER include it in a DTO.
        //       if we still need to use it, we should define MembershipTypeDto and use it instead.
        //       in this instance, we can just remove it from the DTO:
        //public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        //[CustomValidation_Min18YearsForMembership]
        public MembershipTypeIds MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}