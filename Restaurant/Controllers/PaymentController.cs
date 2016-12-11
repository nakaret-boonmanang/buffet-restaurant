using Restaurant.Model;
using Restaurant.Service;
using Restaurant.ViewsModel;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment/Calculate
        public ActionResult Calculate()
        {
            return View();
        }

        // POST: Payment/Calculate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate([Bind(Include = "NumberOfCustomers, PricePerPerson, CouponCode")] PaymentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Payment Service 
                PaymentService paymentService = new PaymentService();

                // Validate default Coupon code
                viewModel.CouponCode = (!string.IsNullOrEmpty(viewModel.CouponCode) ? viewModel.CouponCode : "NONE");
                
                // Get discount rule
                PaymentRule rule = paymentService.GetPaymentRule(viewModel.NumberOfCustomers, viewModel.PricePerPerson, viewModel.CouponCode);
                
                // assign reults to ViewBag
                ViewBag.ActualPrice = string.Format("Actual Price: {0} {1}", rule.ActualPrice, "Bath");
                ViewBag.TotalPrice = string.Format("Total Price: {0} {1}", rule.TotalPrice, "Bath");
                ViewBag.Discount = string.Format("Discount: {0} {1}", rule.Discount, "Bath");
                ViewBag.Description = string.Format("Description: {0}", rule.Description);
            }
            return View(viewModel);
        }
    }
}
