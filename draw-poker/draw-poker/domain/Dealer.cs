using System;
using System.Collections.Generic;
using System.Linq;

namespace draw_poker.domain
{
    class Dealer
    {
        public Rank JudgeRank(IEnumerable<Card> hand)
        {
            // 全て同じスート
            bool isFlush =
                (from card in hand
                group card by card.Suit
                into cardGroup
                where cardGroup.Count() == hand.Count()
                select cardGroup)
                .Count() > 0;

            int equalCount = EqualCount(hand);
            int pairCount = PairCount(hand);
            bool isStraight = true;
            bool isFullHouse = true; // ２枚、３枚 -> 今はPairCoutを最大のものしか返してないが、全て返すようにする

            Dictionary<Rank, Func<bool>> dic = new Dictionary<Rank, Func<bool>>()
            {
                { Rank.StraightFlush,   () => (isStraight && isFlush)   },
                { Rank.FourOfAKind,     () => (equalCount == 4)         },
                { Rank.FullHouse,       () => isFullHouse               },
                { Rank.Flush,           () => isFlush                   },
                { Rank.Straight,        () => isStraight                },
                { Rank.ThreeOfAKind,    () => (equalCount == 3)         },
                { Rank.TwoPair,         () => (pairCount == 2)          },
                { Rank.OnePair,         () => (pairCount == 1)          },
            };

            foreach (var rank in dic)
            {
                if (rank.Value())
                {
                    return rank.Key;
                }
            }

            return Rank.HighCards;

            /*
            // 同じ番号の組み合わせ

            // 連続する番号の組み合わせ

            // ペアの組み合わせ

            switch (equalCount)
            {
                case 4: return Rank.FourOfAKind;
                case 3: return Rank.ThreeOfAKind;
            }

            switch (pairCount)
            {
                case 1: return Rank.OnePair;
                case 2: return Rank.TwoPair;
            }

                        //bool isStraightFlush = (isStraight && isFlush);
            //bool isFourCard = (equalCount == 4);
            //bool isFlush
            //bool isStraight
            //bool isThreeCard = (equalCount == 3);
            //bool isTwoPair = (pairCount == 2);
            //bool isOnePair = (pairCount == 1);

            //Dictionary<Rank, bool> dic = new Dictionary<Rank, bool>()
            //{
            //    { Rank.StraightFlush,   isStraightFlush },
            //    { Rank.FourOfAKind,     isFourCard      },
            //    { Rank.FullHouse,       isFullHouse     },
            //    { Rank.Flush,           isFlush         },
            //    { Rank.Straight,        isStraight      },
            //    { Rank.ThreeOfAKind,    isThreeCard     },
            //    { Rank.TwoPair,         isTwoPair       },
            //    { Rank.OnePair,         isOnePair       },
            //};

            //foreach (var rank in dic)
            //{
            //    if (rank.Value)
            //    {
            //        return rank.Key;
            //    }
            //}

            return Rank.HighCards;
            */
        }

        private static int PairCount(IEnumerable<Card> hand)
        {
            var pair =
                from card in hand
                group card by card.CardNo
                into cardGroup
                where cardGroup.Count() == 2
                select cardGroup;

            return pair.Count();
        }

        private int EqualCount(IEnumerable<Card> hand)
        {
            var pairCount =
                from card in hand
                group card by card.CardNo
                into cardGroup
                where cardGroup.Count() > 1
                orderby cardGroup.Count() descending
                select cardGroup;

            return pairCount.First().Count();
        }
    }
}
