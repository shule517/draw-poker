using System;
using System.Collections.Generic;
using System.Linq;

namespace draw_poker.domain
{
    public class Dealer
    {
        public Rank JudgeRank(IEnumerable<Card> hand)
        {
            bool isStraight = IsStraight(hand);
            bool isFlush = IsFlush(hand);
            int pairCount = PairCount(hand);
            IEnumerable<int> equalCount = EqualCount(hand);

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
            var sequence = new CardNo[]
            {
                CardNo.A,
                CardNo.No2,
                CardNo.No3,
                CardNo.No4,
                CardNo.No5,
                CardNo.No6,
                CardNo.No7,
                CardNo.No8,
                CardNo.No9,
                CardNo.No10,
                CardNo.J,
                CardNo.Q,
                CardNo.K,
                CardNo.A,
            };
            var allSequence = Enumerable.Range(0, 10).Select(e => sequence.Skip(e).Take(5));

            var allKindsCardNo =
                from card in hand
                group card by card.CardNo
                    into cardGroup
                    select cardGroup.Key;

            return allSequence.Any(e => e.SequenceEqual(allKindsCardNo));
        }

        private bool IsFlush(IEnumerable<Card> hand)
        {
            return
                (from card in hand
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
