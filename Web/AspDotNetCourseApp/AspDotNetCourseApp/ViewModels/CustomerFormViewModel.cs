using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDotNetCourseApp.Models;

namespace AspDotNetCourseApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public  Customer Customer { get; set; }
        public  IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}