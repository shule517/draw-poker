using System;
using System.Collections.Generic;
using System.Linq;

namespace draw_poker.domain
{
    public class Stock
    {
        private IEnumerable<Card> cards;
        private Random random = new Random();
        public int Count { get { return cards.Count(); } }

        public Stock()
        {
            cards =
                from suit in Enum.GetValues(typeof(Suit)).Cast<Suit>()
                from cardNo in Enum.GetValues(typeof(CardNo)).Cast<CardNo>()
                    select new Card(suit, cardNo);
        }

        public Card Draw()
        {
            return Draw(1).Single();
        }

        public IEnumerable<Card> Draw(int count)
        {
            return Pop(count);
        }

        private IEnumerable<Card> Pop(int count)
        {
            var result = cards.Take(count);
            cards = cards.Skip(count).ToList();
            return result;
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(x => random.Next()).ToList();
        }
    }
}
