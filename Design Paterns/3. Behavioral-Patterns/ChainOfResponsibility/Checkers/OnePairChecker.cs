using ChainOfResponsibility.Cards;
using System;

namespace ChainOfResponsibility.Checkers
{
    public class OnePairChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.HasNOfAKind(hand, 2))
            {
                Console.WriteLine("One pair!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
