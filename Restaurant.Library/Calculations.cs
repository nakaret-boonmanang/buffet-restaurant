using Restaurant.Model;

namespace Restaurant.Library
{
    public class Calculations
    {
        /// <summary>
        /// Get Actual Price before calcualte with discount
        /// </summary>
        /// <param name="numCustomers"></param>
        /// <param name="pricePerPerson"></param>
        /// <returns></returns>
        public static double GetActualPrice(int numCustomers, double pricePerPerson)
        {
            return (pricePerPerson * numCustomers);
        }

        /// <summary>
        /// Get Discount rate from percentage
        /// </summary>
        /// <param name="actualPrice"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static double GetDiscountByPercentage(double actualPrice, double percentage)
        {
            return (actualPrice * (percentage / 100));
        }

        /// <summary>
        /// Get Discount rate for Come And Pay Promotion
        /// </summary>
        /// <param name="promotion"></param>
        /// <param name="actualCome"></param>
        /// <param name="pricePerPerson"></param>
        /// <returns></returns>
        public static double GetDiscountByComePayPromotion(ComePayPromotion promotion, int actualCome, double pricePerPerson)
        {
            int discountRatio = promotion.Come - promotion.Pay;
            double discount = ((actualCome / promotion.Come) * discountRatio) * pricePerPerson;
            return discount;
        }

        /// <summary>
        /// Get Total Price that discount calculated
        /// </summary>
        /// <param name="actualPrice"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public static double GetTotalPrice(double actualPrice, double discount)
        {
            return (actualPrice - discount);
        }
    }
}
