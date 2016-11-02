using System;
using System.Linq;

using Sepcification.Cards;
using Sepcification.ConcreteSpecifications;
using Sepcification.LogicSpecifications;

namespace Sepcification
{
    public class Startup
    {
        public static void Main()
        {
            var isAce = new AceCardSpecification();
            var isHighCard = new HighCardSpecification();
            var isRedCard = new RedSuitSpecification();
            
            var blackRoyalFlushesCards = isHighCard.Or(isAce).And(isRedCard.Not());

            var royalFlushes = new Deck().Cards
                .Where(card => blackRoyalFlushesCards.IsSatisfiedBy(card))
                .GroupBy(card => card.Suit)
                .Select((royalFlush) => string.Join(", ", royalFlush));

            Console.WriteLine(string.Join(Environment.NewLine, royalFlushes));
        }
    }
}
