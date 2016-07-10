using System;

namespace draw_poker.domain
{
    public enum CardNo
    {
        No2 = 2,
        No3 = 3,
        No4 = 4,
        No5 = 5,
        No6 = 6,
        No7 = 7,
        No8 = 8,
        No9 = 9,
        No10 = 10,
        J = 11,
        Q = 12,
        K = 13,
        A = 14,
    }

    static class CardNoExtension
    {
        public static string GetName(this CardNo cardNo)
        {
            return GetValue(cardNo).ToString();
        }

        public static int GetValue(this CardNo cardNo)
        {
            return (int)cardNo;
        }
    }
}
