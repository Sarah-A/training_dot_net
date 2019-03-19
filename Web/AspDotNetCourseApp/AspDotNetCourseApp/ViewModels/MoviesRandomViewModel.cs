﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDotNetCourseApp.Models;

namespace AspDotNetCourseApp.ViewModels
{
    public class MoviesRandomViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}