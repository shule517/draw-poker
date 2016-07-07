using System;

namespace draw_poker.domain
{
    public enum Suit : int
    {
        Hearts,
        Diamonds,
        Clubs,
        Spade
    }

    static class SuitExtension
    {
        public static string GetName(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts:
                    return "♥";
                case Suit.Diamonds:
                    return "♦";
                case Suit.Clubs:
                    return "♣";
                default:
                    return "♠";
            }
        }

        public static int GetValue(this Suit suit)
        {
            return (int)suit;
        }
    }
}
