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
            Assert.AreEqual(stock.Count, (13*4));
        }
    }
}
