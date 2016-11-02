using Sepcification.Cards;

namespace Sepcification.ConcreteSpecifications
{
    public class RedSuitSpecification : ISpecification<Card>
    {
        public bool IsSatisfiedBy(Card card)
        {
            return (card.Suit == Suit.Hearts || card.Suit == Suit.Diamonds);
        }
    }
}
