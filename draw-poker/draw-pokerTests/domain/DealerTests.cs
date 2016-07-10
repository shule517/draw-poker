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
    public class DealerTests
    {
        [TestMethod()]
        public void 役判定_ワンペア()
        {
            Dealer dealer = new Dealer();

            var hand = new[]
            {
                new Card(Suit.Clubs,    CardNo.A),
                new Card(Suit.Diamonds, CardNo.A),
                new Card(Suit.Hearts,   CardNo.No2),
                new Card(Suit.Hearts,   CardNo.No3),
                new Card(Suit.Hearts,   CardNo.No4),
            };
            var rank = dealer.JudgeRank(hand);

            Assert.AreEqual(Rank.OnePair, rank);
        }

        [TestMethod()]
        public void 役判定_フルハウス()
        {
            Dealer dealer = new Dealer();

            var hand = new[]
            {
                new Card(Suit.Clubs,    CardNo.A),
                new Card(Suit.Diamonds, CardNo.A),
                new Card(Suit.Clubs,    CardNo.No2),
                new Card(Suit.Diamonds, CardNo.No2),
                new Card(Suit.Hearts,   CardNo.No2),
            };
            var rank = dealer.JudgeRank(hand);

            Assert.AreEqual(Rank.FullHouse, rank);
        }

        [TestMethod()]
        public void 役判定_ストレート1()
        {
            Dealer dealer = new Dealer();

            var hand = new[]
            {
                new Card(Suit.Clubs,    CardNo.No10),
                new Card(Suit.Diamonds, CardNo.J),
                new Card(Suit.Clubs,    CardNo.Q),
                new Card(Suit.Diamonds, CardNo.K),
                new Card(Suit.Hearts,   CardNo.A),
            };
            var rank = dealer.JudgeRank(hand);

            Assert.AreEqual(Rank.Straight, rank);
        }

        [TestMethod()]
        public void 役判定_ストレート2()
        {
            Dealer dealer = new Dealer();

            var hand = new[]
            {
                new Card(Suit.Clubs,    CardNo.No10),
                new Card(Suit.Diamonds, CardNo.No10),
                new Card(Suit.Clubs,    CardNo.Q),
                new Card(Suit.Diamonds, CardNo.K),
                new Card(Suit.Hearts,   CardNo.A),
            };
            var rank = dealer.JudgeRank(hand);

            Assert.AreNotEqual(Rank.Straight, rank);
        }

        [TestMethod()]
        public void 役判定_ストレートフラッシュ()
        {
            Dealer dealer = new Dealer();

            var hand = new[]
            {
                new Card(Suit.Hearts, CardNo.No10),
                new Card(Suit.Hearts, CardNo.J),
                new Card(Suit.Hearts, CardNo.Q),
                new Card(Suit.Hearts, CardNo.K),
                new Card(Suit.Hearts, CardNo.A),
            };
            var rank = dealer.JudgeRank(hand);

            Assert.AreEqual(Rank.StraightFlush, rank);
        }
    }
}