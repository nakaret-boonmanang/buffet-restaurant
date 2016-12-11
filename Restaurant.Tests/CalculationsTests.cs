using NUnit.Framework;
using Restaurant.Library;
using Restaurant.Model;

namespace Restaurant.Tests
{
    [TestFixture]
    public class CalculationsTests
    {
        [Test]
        public void Calculations_GetActualPrice_When_Customer_2_PricePerPerson_500_ActualPrice_1000()
        {
            // arrage
            int numCustomers = 2;
            int pricePerPerson = 500;

            // act
            double actualPrice = Calculations.GetActualPrice(numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(1000, actualPrice);
        }

        [Test]
        public void Calculations_GetDiscountByPercentage_When_ActualPrice_1000_Percentage_20_Discount_200()
        {
            // arrage
            double actualPrice = 1000;
            int percentage = 20;

            // act
            double discount = Calculations.GetDiscountByPercentage(actualPrice, percentage);

            // assert
            Assert.AreEqual(200, discount);
        }

        [Test]
        public void Calculations_GetTotalPrice_When_ActualPrice_1000_Discount_200_TotalPrice_800()
        {
            // arrage
            double actualPrice = 1000;
            double discount = 200;

            // act
            double totalPrice = Calculations.GetTotalPrice(actualPrice, discount);

            // assert
            Assert.AreEqual(800, totalPrice);
        }

        [Test]
        public void Calculations_GetDiscountByComePayPromotion_Come4_Pay3_When_Come4_Discount_Should_Correct()
        {
            // arrage
            ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 3 };
            int numCustomers = 4;
            double pricePerPerson = 500;

            // act
            double discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(500, discount);
        }

        [Test]
        public void Calculations_GetDiscountByComePayPromotion_Come4_Pay3_When_Come5_Discount_Should_Correct()
        {
            // arrage
            ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 3 };
            int numCustomers = 5;
            double pricePerPerson = 500;

            // act
            double discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(500, discount);
        }

        [Test]
        public void Calculations_GetDiscountByComePayPromotion_Come4_Pay3_When_Come8_Discount_Should_Correct()
        {
            // arrage
            ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 3 };
            int numCustomers = 8;
            double pricePerPerson = 500;

            // act
            double discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(1000, discount);
        }

        [Test]
        public void Calculations_GetDiscountByComePayPromotion_Come4_Pay2_When_Come4_Discount_Should_Correct()
        {
            // arrage
            ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 2 };
            int numCustomers = 4;
            double pricePerPerson = 500;

            // act
            double discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(1000, discount);
        }

        [Test]
        public void Calculations_GetDiscountByComePayPromotion_Come4_Pay2_When_Come5_Discount_Should_Correct()
        {
            // arrage
            ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 2 };
            int numCustomers = 5;
            double pricePerPerson = 500;

            // act
            double discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(1000, discount);
        }

        [Test]
        public void Calculations_GetDiscountByComePayPromotion_Come4_Pay2_When_Come8_Discount_Should_Correct()
        {
            // arrage
            ComePayPromotion promotion = new ComePayPromotion { Come = 4, Pay = 2 };
            int numCustomers = 8;
            double pricePerPerson = 500;

            // act
            double discount = Calculations.GetDiscountByComePayPromotion(promotion, numCustomers, pricePerPerson);

            // assert
            Assert.AreEqual(2000, discount);
        }
    }
}
