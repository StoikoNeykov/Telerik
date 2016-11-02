using ChainOfResponsibility.Cards;
using System;

namespace ChainOfResponsibility.Checkers
{
    public class HighCardChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            Console.WriteLine("High card!");
        }
    }
}
