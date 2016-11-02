using Sepcification.Cards;

namespace Sepcification.ConcreteSpecifications
{
    public class HighCardSpecification: ISpecification<Card>
    {
        public bool IsSatisfiedBy(Card card)
        {
            return ((int)card.Rank >= 10);
        }
    }
}
