using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewsModel
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }

        [Display(Name = "Number Of Customers")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number that more than zero")]
        [Required(ErrorMessage = "Number Of Customers required")]
        public int NumberOfCustomers { get; set; }

        [Display(Name = "Price Per Person")]
        [Range(0d, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        [Required(ErrorMessage = "Price Per Person required")]
        public double PricePerPerson { get; set; }

        [Display(Name = "Coupon Code")]
        public string CouponCode { get; set; }
    }
}