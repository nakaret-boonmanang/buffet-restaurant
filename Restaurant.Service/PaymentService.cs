using Restaurant.Library;
using Restaurant.Model;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Service
{
    public class PaymentService
    {
        /// <summary>
        /// A GetPaymentRule method will return the payment information that matched with the best condition
        /// </summary>
        /// <param name="numCustomers"></param>
        /// <param name="pricePerPerson"></param>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        public PaymentRule GetPaymentRule(int numCustomers, double pricePerPerson, string couponCode)
        {
            List<DiscountInfo> rules = GetDiscountRules(numCustomers, pricePerPerson, couponCode);
            DiscountInfo rule = rules[0]; // best condition
            // get actual price
            double actualPrice = Calculations.GetActualPrice(numCustomers, pricePerPerson);
            // get total price 
            double totalPrice = Calculations.GetTotalPrice(actualPrice, rule.Discount);

            return new PaymentRule
            {
                ActualPrice = actualPrice,
                TotalPrice = totalPrice,
                Discount = rule.Discount,
                Description = rule.Description,
            };
        }

        /// <summary>
        /// A GetDiscountRules method will return the multiple discount rules that matched with the conditions
        /// </summary>
        /// <param name="numCustomers"></param>
        /// <param name="pricePerPerson"></param>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        private List<DiscountInfo> GetDiscountRules(int numCustomers, double pricePerPerson, string couponCode)
        {
            List<DiscountInfo> matchedRule = new List<DiscountInfo>();
            double actualPrice = numCustomers * pricePerPerson;
            double discount = 0;
            double discountPercent = 0;

            if (numCustomers == 2 && couponCode.ToUpper() == "STARCARD")
            {
                // Discount 30%
                discountPercent = 30;
                matchedRule.Add(new DiscountInfo
                {
                    Discount = Calculations.GetDiscountByPercentage(actualPrice, discountPercent),
                    Description = string.Format("Come {0} with STARCARD coupon get {1}% discount", numCustomers, discountPercent)
                });
            }

            if (numCustomers >= 4 && couponCode.ToUpper() == "STARCARD")
            {
                // Come 4 pay 3
                ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 3 };
                discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

                matchedRule.Add(new DiscountInfo
                {
                    Discount = discount,
                    Description = string.Format("Come {0} with STARCARD coupon pay {1}", promotion.Come, promotion.Pay)
                });
            }

            if (actualPrice >= 2500)
            {
                // discount 25%
                discountPercent = 25;
                matchedRule.Add(new DiscountInfo
                {
                    Discount = Calculations.GetDiscountByPercentage(actualPrice, discountPercent),
                    Description = string.Format("Actual Price equal/more than 2500 get {0}% discount", discountPercent)
                });
            }

            if (actualPrice >= 2000 || couponCode.ToUpper() == "DIS10")
            {
                // discount 10%;
                discountPercent = 10;
                matchedRule.Add(new DiscountInfo
                {
                    Discount = Calculations.GetDiscountByPercentage(actualPrice, discountPercent),
                    Description = string.Format("Actual Price equal/more than 2000 or use DIS10 coupon get {0}% discount", discountPercent)
                });
            }

            if (matchedRule.Count() == 0)
            {
                // if there is no matched rule set default rule as NONE
                matchedRule.Add(new DiscountInfo
                {
                    Discount = 0,
                    Description = "No discount"
                });
            }

            return matchedRule.OrderByDescending(q => q.Discount).ToList();
        }
    }
}
