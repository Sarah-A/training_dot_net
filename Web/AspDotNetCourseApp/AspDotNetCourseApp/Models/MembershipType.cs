﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetCourseApp.Models
{
    public enum MembershipTypeIds : byte
    {
        Unknown = 0,
        PayAsYouGo,
        Monthly,
        Quarterly,
        Yearly
    };

    public class MembershipType
    {
        public MembershipTypeIds Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

    }
}