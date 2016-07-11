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

            Stock stock = new Stock();
            stock.Shuffle();

            for (int i = 0; i < 10; i++)
            {
                var hand = stock.Draw(5);
                PokerRule rule = new PokerRule();
                var rank = rule.JudgeRank(hand);

                foreach (var card in hand)
                {
                    Console.Write(card);
                }
                Console.WriteLine(" => rank:" + rank);
            }
        }
    }
}
