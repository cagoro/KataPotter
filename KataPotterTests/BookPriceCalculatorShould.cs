using System.Collections.Generic;
using KataPotter;
using NUnit.Framework;

namespace KataPotterTests
{
    [TestFixture]
    public class BookPriceCalculatorShould
    {
        private BookPriceCalculator _bookPriceCalculator;

        [SetUp]
        public void Setup()
        {
            _bookPriceCalculator = new BookPriceCalculator();
        }

        [Test]
        public void return_non_discounted_price_for_a_single_book()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> { 1 });

            Assert.AreEqual(8m, price);
        }

        [Test]
        public void return_sum_of_prices_for_same_book()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> { 2 });

            Assert.AreEqual(16m, price);
        }

        [Test]
        public void return_five_percent_discount_for_two_different_books()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> {1, 1});

            Assert.AreEqual(15.2m, price);
        }

        [Test]
        public void return_ten_percent_discount_for_three_different_books()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> { 1, 1, 1 });

            Assert.AreEqual(21.6m, price);
        }

        [Test]
        public void return_twenty_percent_discount_for_four_different_books()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> { 1, 1, 1, 1 });

            Assert.AreEqual(32d - 6.4d, price);
        }


        [Test]
        public void not_discount_prices_on_two_duplicated_book()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> { 3, 4});

            Assert.AreEqual(53.6m, price);
        }

        [Test]
        public void not_discount_prices_on_three_duplicated_book()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> {3, 4, 3});
            Assert.AreEqual(72.8m, price);
        }



        [Test]
        public void discount_multiple_sets()
        {
            var price = _bookPriceCalculator.GetBookPrices(new List<int> { 3, 4, 5 });
            Assert.AreEqual(72.8m, price);
        }
    }
}
