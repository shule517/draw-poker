using draw_poker.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace draw_poker.domain.Tests
{
    [TestClass()]
    public class DealerTests
    {
        [TestMethod()]
        public void 役判定_ブタ()
        {
            AreEqual("♢A♧J♤0♤7♤2", Rank.HighCards);
        }

        [TestMethod()]
        public void 役判定_ワンペア()
        {
            AreEqual("♧A♢A♡2♡3♡4", Rank.OnePair);
        }

        [TestMethod()]
        public void 役判定_ツーペア()
        {
            AreEqual("♢A♧A♡2♢2♧9", Rank.TwoPair);
        }

        [TestMethod()]
        public void 役判定_スリーカード()
        {
            AreEqual("♡K♢K♧K♡J♤7", Rank.ThreeOfAKind);
        }

        [TestMethod()]
        public void 役判定_ストレート()
        {
            AreEqual("♧0♢J♧Q♢K♡A", Rank.Straight);
            AreNotEqual("♧0♢0♧Q♢K♡A", Rank.Straight);

            AreEqual("♡0♢J♧Q♢K♧A", Rank.Straight);
            AreEqual("♡A♢2♧3♢4♧5", Rank.Straight);
            AreNotEqual("♧K♢A♧2♢3♡4", Rank.Straight);
            AreNotEqual("♧Q♢K♧A♢2♡3", Rank.Straight);
            AreNotEqual("♧J♢Q♧K♢A♡2", Rank.Straight);
        }

        [TestMethod()]
        public void 役判定_フラッシュ()
        {
            AreEqual("♧Q♧J♧8♧6♧5", Rank.Flush);
        }

        [TestMethod()]
        public void 役判定_フルハウス()
        {
            AreEqual("♧A♢A♧2♢2♡2", Rank.FullHouse);
        }

        [TestMethod()]
        public void 役判定_フォーカード()
        {
            AreEqual("♤6♡6♢6♧6♢K", Rank.FourOfAKind);
        }

        [TestMethod()]
        public void 役判定_ストレートフラッシュ()
        {
            AreEqual("♡0♡J♡Q♡K♡A", Rank.StraightFlush);
        }

        private void AreEqual(string hand, Rank rank)
        {
            AreEqual(hand, rank, Assert.AreEqual);
        }

        private void AreNotEqual(string hand, Rank rank)
        {
            AreEqual(hand, rank, Assert.AreNotEqual);
        }

        private void AreEqual(string hand, Rank rank, Action<Rank, Rank> areEqual)
        {
            var hands = hand.Chunk(2).Select(card => parseCard(card));

            Dealer dealer = new Dealer();
            var resultRank = dealer.JudgeRank(hands);
            areEqual(rank, resultRank);
        }

        private Card parseCard(IEnumerable<char> card)
        {
            Suit suit;
            switch (card.ElementAt(0))
            {
                case '♡':
                    suit = Suit.Hearts;
                    break;
                case '♢':
                    suit = Suit.Diamonds;
                    break;
                case '♧':
                    suit = Suit.Clubs;
                    break;
                case '♤':
                    suit = Suit.Spade;
                    break;
                default:
                    throw new ArgumentException();
            }
            CardNo cardNo;
            switch (card.ElementAt(1))
            {
                case 'A':
                    cardNo = CardNo.A;
                    break;
                case '2':
                    cardNo = CardNo.No2;
                    break;
                case '3':
                    cardNo = CardNo.No3;
                    break;
                case '4':
                    cardNo = CardNo.No4;
                    break;
                case '5':
                    cardNo = CardNo.No5;
                    break;
                case '6':
                    cardNo = CardNo.No6;
                    break;
                case '7':
                    cardNo = CardNo.No7;
                    break;
                case '8':
                    cardNo = CardNo.No8;
                    break;
                case '9':
                    cardNo = CardNo.No9;
                    break;
                case '0':
                    cardNo = CardNo.No10;
                    break;
                case 'J':
                    cardNo = CardNo.J;
                    break;
                case 'Q':
                    cardNo = CardNo.Q;
                    break;
                case 'K':
                    cardNo = CardNo.K;
                    break;
                default:
                    throw new ArgumentException();
            }
            return new Card(suit, cardNo);
        }
    }
}
