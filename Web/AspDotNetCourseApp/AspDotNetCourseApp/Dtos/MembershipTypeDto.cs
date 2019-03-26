using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDotNetCourseApp.Models;

namespace AspDotNetCourseApp.Dtos
{
    public class MembershipTypeDto
    {
        public MembershipTypeIds Id { get; set; }
        public string Name { get; set; }
    }
}