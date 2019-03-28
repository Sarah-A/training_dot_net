using System.Collections.Generic;

namespace AspDotNetCourseApp.Controllers.Api
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}