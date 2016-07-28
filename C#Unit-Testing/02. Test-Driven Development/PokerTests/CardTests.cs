namespace PokerTests
{
    using NUnit.Framework;

    using Poker;

    [TestFixture]
    public class CardTests
    {
        [Test]
        [TestCase(CardSuit.Hearts, CardFace.Ace, "A♥")]
        [TestCase(CardSuit.Diamonds, CardFace.Five, "5♦")]
        [TestCase(CardSuit.Spades, CardFace.Jack, "J♠")]
        [TestCase(CardSuit.Clubs, CardFace.Two, "2♣")]
        public void CardToString_ShouldWorkProperly(CardSuit suit, CardFace face, string expected)
        {
            var card = new Card(face, suit);

            Assert.AreEqual(expected, card.ToString());
        }
    }
}
