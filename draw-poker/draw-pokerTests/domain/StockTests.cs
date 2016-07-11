using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace draw_poker.domain.Tests
{
    [TestClass()]
    public class StockTests
    {
        [TestMethod()]
        public void カードは全部で52枚()
        {
            Stock stock = new Stock();
            Assert.AreEqual((13 * 4), stock.Count);
        }

        [TestMethod()]
        public void カードを5枚引く()
        {
            Stock stock = new Stock();
            var cardsA = stock.Draw(5);
            var cardsB = stock.Draw(5);

            // 受け取った枚数は５枚
            Assert.AreEqual(5, cardsA.Count());
            // 次の５枚は違うカード
            bool equalSuit = cardsA.ElementAt(0).Suit == (cardsB).ElementAt(0).Suit;
            bool equalCardNo = cardsA.ElementAt(0).CardNo == (cardsB).ElementAt(0).CardNo;
            Assert.IsFalse(equalSuit && equalCardNo);
        }

        [TestMethod()]
        public void 引いたカードは全て違うカード()
        {
            Stock stock = new Stock();
            var cards = stock.Draw(5);
            var result =
                cards.Skip(1)
                .Select(card => cards.First() != card)
                .All(x => x == true);
            Assert.IsTrue(result);
        }

        //[TestMethod()]
        //public void カードがシャッフルされること()
        //{
        //    Stock stockA = new Stock();
        //    var cardsA = stockA.Draw(5);

        //    Stock stockB = new Stock();
        //    stockB.Shuffle();
        //    var cardsB = stockB.Draw(5);

        //    var results = Enumerable.Range(0, 5)
        //        .Select(x => cardsA.ElementAt(x).CardNo != cardsB.ElementAt(x).CardNo);
        //    var result = results.All(x => x == true);

        //    Assert.IsTrue(result);
        //}
    }
}
