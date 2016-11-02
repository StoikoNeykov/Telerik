using ChainOfResponsibility.Cards;

namespace ChainOfResponsibility.Checkers
{
    public abstract class PokerCombinationChecker
    {
        protected PokerCombinationChecker() { }

        public PokerCombinationChecker SuccessiveHand(PokerCombinationChecker pokerCombination)
        {
            this.SuccessiveCombinationChecker = pokerCombination;

            return this;
        }

        protected PokerCombinationChecker SuccessiveCombinationChecker { get; set; }

        public abstract void Check(CheckerHelper helper, Hand hand);
    }
}
