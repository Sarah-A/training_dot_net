using System;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreFromScratch.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required]
        public string OrderNumber { get; set; }
    }
}