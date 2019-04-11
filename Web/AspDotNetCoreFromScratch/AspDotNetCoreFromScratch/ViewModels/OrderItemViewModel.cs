using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreFromScratch.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        //public ProductViewModel Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

    }
}