using ChainOfResponsibility.Cards;
using System;

namespace ChainOfResponsibility.Checkers
{
    public class FlushChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.IsFlush(hand))
            {
                Console.WriteLine("Flush!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
