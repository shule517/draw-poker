using System;
using System.Collections.Generic;
using System.Linq;
using draw_poker.util;

namespace draw_poker.domain
{
    public class Stock
    {
        private List<Card> cards;
        private Random random = new Random();

        public int Count { get { return cards.Count(); } }

        public Stock()
        {
            cards =
                (from suit in Enum.GetValues(typeof(Suit)).Cast<Suit>()
                from cardNo in Enum.GetValues(typeof(CardNo)).Cast<CardNo>()
                select new Card(suit, cardNo)).ToList();
        }

        public Card Draw()
        {
            return Draw(1).Single();
        }

        public IEnumerable<Card> Draw(int number)
        {
            return Enumerable.Range(0, number)
                .Select(x => cards.Pop())
                .ToList();
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(x => random.Next()).ToList();
        }
    }
}
