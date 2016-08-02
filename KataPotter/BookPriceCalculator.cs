using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BookPriceCalculator
    {
        private const decimal SINGLE_BOOK_PRICE = 8;

        private readonly Dictionary<int,decimal> _setDiscount = new Dictionary<int, decimal>()
        {
            {1, 1}, {2, 0.95m}, {3, 0.90m}, {4, 0.80m}, {5, 0.75m}
        }; 

        public decimal GetBookPrices(List<int> books)
        {
            int distincBookCount = books.Count;

            decimal discount = _setDiscount[distincBookCount];

            int setCount = books.Min();

            decimal price = setCount * distincBookCount * SINGLE_BOOK_PRICE * discount;

            int remainingBooks = books.Sum() - distincBookCount * setCount;

            return price + remainingBooks * SINGLE_BOOK_PRICE;
        }
    }
}
