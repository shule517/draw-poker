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
            return string.Format("[{0}{1:D2}]", this.Suit.GetName(), this.CardNo.GetValue());
        }
    }
}

class One
{
    public int Value { get { return 1; }  }
}
