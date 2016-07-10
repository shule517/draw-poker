namespace draw_poker.domain
{
    public enum Rank
    {
        HighCards,      // ハイ・カード（いわゆるブタ）
        OnePair,        // ワンペア
        TwoPair,        // ツーペア
        ThreeOfAKind,   // スリーカード
        Straight,       // ストレート
        Flush,          // フラッシュ
        FullHouse,      // フルハウス
        FourOfAKind,    // フォーカード
        StraightFlush,  // ストレート・フラッシュ
    }
}
