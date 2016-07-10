using System;
using System.Collections.Generic;
using System.Linq;

namespace draw_poker.domain
{
    public class Dealer
    {
        public Rank JudgeRank(IEnumerable<Card> hand)
        {
            bool isFlush = IsFlush(hand);
            IEnumerable<int> equalCount = EqualCount(hand);
            int pairCount = PairCount(hand);
            bool isStraight = IsStraight(hand);

            Dictionary<Rank, Func<bool>> dic = new Dictionary<Rank, Func<bool>>()
            {
                { Rank.StraightFlush, () => isStraight && isFlush                                      },
                { Rank.FourOfAKind,   () => equalCount.Any(x => x == 4)                                },
                { Rank.FullHouse,     () => equalCount.Any(x => x == 3) && equalCount.Any(x => x == 2) },
                { Rank.Flush,         () => isFlush                                                    },
                { Rank.Straight,      () => isStraight                                                 },
                { Rank.ThreeOfAKind,  () => equalCount.Any(x => x == 3)                                },
                { Rank.TwoPair,       () => pairCount == 2                                             },
                { Rank.OnePair,       () => pairCount == 1                                             },
            };

            foreach (var rank in dic)
            {
                if (rank.Value())
                {
                    return rank.Key;
                }
            }

            return Rank.HighCards;
        }

        private bool IsStraight(IEnumerable<Card> hand)
        {
            var allKindsCardNo =
                from card in hand
                group card by card.CardNo
                into cardGroup
                select cardGroup.Key;

            int min = allKindsCardNo.Min(cardNo => cardNo).GetValue();
            int max = allKindsCardNo.Max(cardNo => cardNo).GetValue();

            return (allKindsCardNo.Count() == hand.Count()) &&  // カード番号の重複なし
                   (max - min) == (hand.Count() - 1);           // カード番号が連続している
        }

        private bool IsFlush(IEnumerable<Card> hand)
        {
            return (from card in hand
                    group card by card.Suit
                into cardGroup
                    where cardGroup.Count() == hand.Count()
                    select cardGroup)
                .Count() > 0;
        }

        private int PairCount(IEnumerable<Card> hand)
        {
            var pair =
                from card in hand
                group card by card.CardNo
                into cardGroup
                where cardGroup.Count() == 2
                select cardGroup;

            return pair.Count();
        }

        private IEnumerable<int> EqualCount(IEnumerable<Card> hand)
        {
            var pairCount =
                from card in hand
                group card by card.CardNo
                into cardGroup
                where cardGroup.Count() > 1
                orderby cardGroup.Count() descending
                select cardGroup.Count();

            return pairCount;
        }
    }
}
