using NUnit.Framework;
using Restaurant.Model;
using Restaurant.Service;

namespace Restaurant.Tests
{
    [TestFixture]
    public class PaymentServiceTests
    {
        PaymentService service;
        [SetUp]
        public void TestInitialize()
        {
            service = new PaymentService();
        }

        [Test]
        public void Rules_When_CouponCode_Is_DIS10_Customers_1_Price_500_Discount_10_Percent()
        {
            // arange
            int numCustomers = 1;
            double pricePerPerson = 500;
            string couponCode = "DIS10";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(50, rule.Discount);
            Assert.AreEqual(450, rule.TotalPrice);
        }

        [Test]
        public void Rules_When_Price_Equal_Or_Morethan_2000_And_Lessthan_2500_Discount_10_Percent()
        {
            // arange
            double pricePerPerson = 400;
            int numCustomers = 6;
            string couponCode = "NONE";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(240, rule.Discount);
            Assert.AreEqual(2160, rule.TotalPrice);
        }

        [Test]
        public void Rules_When_CouponCode_Is_STARCARD_And_2Customers_Discount_30_Percent()
        {
            // arange
            int numCustomers = 2;
            double pricePerPerson = 500;
            string couponCode = "STARCARD";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(300, rule.Discount);
            Assert.AreEqual(700, rule.TotalPrice);
        }

        [Test]
        public void Rules_Come_4_PAY_3_With_Coupon_STARCARD_When_Come_4_Discount_Should_Correct([Values(4, 5, 6, 7, 8)] int numCustomers)
        {
            // arange
            double pricePerPerson = 300;
            string couponCode = "STARCARD";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            if (numCustomers >= 8)
                Assert.AreEqual(600, rule.Discount);
            else
                Assert.AreEqual(300, rule.Discount);

        }

        [Test]
        public void Rules_When_Price_Equal_2500_Discount_25_Percent()
        {
            // arange
            int numCustomers = 5;
            double pricePerPerson = 500;
            string couponCode = "NONE";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(625, rule.Discount);
        }

        [Test]
        public void Rules_When_Price_MoreThan_2500_Discount_25_Percent()
        {
            // arange
            int numCustomers = 6;
            double pricePerPerson = 500;
            string couponCode = "NONE";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(750, rule.Discount);
        }

        [Test]
        public void Rules_When_Price_Lessthan_2000_And_No_Coupon_Pay_Full()
        {
            // arange
            int numCustomers = 2;
            string couponCode = "NONE";
            double pricePerPerson = 500;

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(0, rule.Discount);
            Assert.AreEqual(1000, rule.TotalPrice);
        }

        [Test]
        public void Rules_When_Customer_2_Price_3000_Code_DIS10_Discount_25_Percent()
        {
            // arange
            int numCustomers = 2;
            double pricePerPerson = 1500;
            string couponCode = "DIS10";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(750, rule.Discount);
            Assert.AreEqual(2250, rule.TotalPrice);
        }

        [Test]
        public void Rules_When_Customer_5_Price_2500_Code_STARCARD_Discount_25_Percent_NOT_COME4_PAY3()
        {
            // arange
            int numCustomers = 5;
            double pricePerPerson = 500;
            string couponCode = "STARCARD";

            // act
            PaymentRule rule = service.GetPaymentRule(numCustomers, pricePerPerson, couponCode);

            // assert
            Assert.AreEqual(625, rule.Discount);
            Assert.AreEqual(1875, rule.TotalPrice);
        }
    }
}
