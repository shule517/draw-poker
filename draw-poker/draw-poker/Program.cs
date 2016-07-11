using draw_poker.domain;
using System;
using System.Text;

namespace draw_poker
{
    class Program
    {
        static void Main(string[] args)
        {
            // ♥の表示
            Console.OutputEncoding = new UTF8Encoding();


            /*
            cardList.Where(x => x.Suit == Suit.Clubs);
            var cardList = (Enum.GetValues(typeof(Suit))).Where(x => new Card(x, CardNo.No1));
            Enum.GetValues(typeof(Suit)).ForEach(x => { });
            */

            //var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList();
            //var no = Enum.GetValues(typeof(CardNo)).Cast<CardNo>().ToList();

            //var lists = suits.SelectMany(suit => no);

            //var cardList = suits.Select(suit => suits.Select(new Card(suit, CardNo.No1)));
            //var cardList = suits.Select(suit => Enum.GetValues(typeof(CardNo)).Cast<CardNo>().ToList().Select(no => new Card(suit, no)));

            //var cardList = suits.Select(suit => suit);
            //var cardList = suits.Select(suit => Enum.GetValues(typeof(CardNo)).Cast<CardNo>().ToList().ForEach(no => new Card(suit, no)));


            /*
            List<Card> cardList = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardNo no in Enum.GetValues(typeof(CardNo)))
                {
                    Card card = new Card(suit, no);
                    cardList.Add(card);
                }
            }

            foreach (Card card in cardList)
            {
                Console.WriteLine(card);
            }
            */

            Stock stock = new Stock();
            stock.Shuffle();

            for (int i = 0; i < 10; i++)
            {
                var hand = stock.Draw(5);

                PokerRule rule = new PokerRule();
                var rank = rule.JudgeRank(hand);

                foreach (var card in hand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine("=> rank:" + rank);
            }
        }
    }
}
