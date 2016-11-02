using ChainOfResponsibility.Cards;
using System.Collections.Generic;

namespace ChainOfResponsibility.Comparers
{
    class RankCardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return (x.Rank == y.Rank);
        }

        public int GetHashCode(Card obj)
        {
            return obj.Rank.GetHashCode();
        }
    }
}
