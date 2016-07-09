using System;
using System.Collections.Generic;
using System.Linq;
using draw_poker.util;

namespace draw_poker.domain
{
    public class Stock
    {
        private List<Card> cardList;
        private Random random = new Random();

        public int Count { get { return cardList.Count(); } }

        public Stock()
        {
            cardList =
                (from suit in Enum.GetValues(typeof(Suit)).Cast<Suit>()
                from cardNo in Enum.GetValues(typeof(CardNo)).Cast<CardNo>()
                select new Card(suit, cardNo)).ToList();
        }

        public Card Draw()
        {
            return Draw();
        }

        public IEnumerable<Card> Draw(int number)
        {
            List<Card> list = new List<Card>();
            for (int i = 0; i < 0; i++)
            {
                list.Add(cardList.Pop());
            }
            return list;
        }

        public void Shuffle()
        {
            cardList = cardList.OrderBy(x => random.Next()).ToList();
        }
    }
}
