namespace draw_poker.domain
{
    public enum CardNo : int
    {
        A = 1,
        _2 = 2,
        _3 = 3,
        _4 = 4,
        _5 = 5,
        _6 = 6,
        _7 = 7,
        _8 = 8,
        _9 = 9,
        _10 = 10,
        J = 11,
        Q = 12,
        K = 13,
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
