using draw_poker.util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace draw_poker.domain
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public CardNo CardNo { get; private set; }

        public Card(Suit suit, CardNo cardNo)
        {
            this.Suit = suit;
            this.CardNo = cardNo;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.Suit.GetName(), this.CardNo.GetName());
        }

        public static IEnumerable<Card> Create(string hand)
        {
            return hand.Chunk(2).Select(card => ParseCard(card));
        }

        private static Card ParseCard(IEnumerable<char> card)
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
                    cardNo = CardNo._2;
                    break;
                case '3':
                    cardNo = CardNo._3;
                    break;
                case '4':
                    cardNo = CardNo._4;
                    break;
                case '5':
                    cardNo = CardNo._5;
                    break;
                case '6':
                    cardNo = CardNo._6;
                    break;
                case '7':
                    cardNo = CardNo._7;
                    break;
                case '8':
                    cardNo = CardNo._8;
                    break;
                case '9':
                    cardNo = CardNo._9;
                    break;
                case '0':
                    cardNo = CardNo._10;
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
