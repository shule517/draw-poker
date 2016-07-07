using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draw_poker.domain
{
    public class Stock
    {
        private Stack<Card> cardList = new Stack<Card>();
        public int Count { get { return cardList.Count; } }

        public Stock()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardNo no in Enum.GetValues(typeof(CardNo)))
                {
                    Card card = new Card(suit, no);
                    cardList.Push(card);
                }
            }
        }

        public Card Draw()
        {
            return cardList.Pop();
        }
    }
}
