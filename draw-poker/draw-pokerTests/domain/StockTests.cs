using Microsoft.VisualStudio.TestTools.UnitTesting;
using draw_poker.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draw_poker.domain.Tests
{
    [TestClass()]
    public class StockTests
    {
        [TestMethod()]
        public void カードは全部で52枚()
        {
            Stock stock = new Stock();
            Assert.AreEqual(stock.Count, (13 * 4));
        }

        [TestMethod()]
        public void カードを5枚引く()
        {
            Stock stock = new Stock();
            var cards = stock.Draw(5);
            Assert.AreEqual(5, cards.Count());
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
