namespace DeckTests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void DeckTrumpCard_ShouldNotBeNull()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(20)]
        public void DeckGetNextCard_ShouldNOtReturnNull(int numberOfTests)
        {
            var deck = new Deck();
            for (int i = 0; i < numberOfTests; i++)
            {
                Assert.IsNotNull(deck.GetNextCard());
            }
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(20)]
        public void DeckGetNextCard_SoulhReturnDiferentCardsEveryTime(int nextCardTries)
        {
            var deck = new Deck();
            var returnedCards = new List<Card>();

            for (int i = 0; i < nextCardTries; i++)
            {
                returnedCards.Add(deck.GetNextCard());
            }

            for (int i = 0; i < returnedCards.Count - 1; i++)
            {
                var firstCard = returnedCards[i];
                for (int j = i + 1; j < returnedCards.Count; j++)
                {
                    if (firstCard.Equals(returnedCards[j]))
                    {
                        Assert.Fail("Deck.GetNextCard() returned same cards. Method should remove card when return it!");
                    }
                }
            }
        }

        [Test]
        public void Deck_shouldHave24Cards()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void Deck_ShouldThrowAnException_WhenCardsOver()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(20)]
        public void DeckCardsLeft_shouldDecreaseCount_WhenGetNextCard(int timesCall)
        {
            var deck = new Deck();

            for (int i = 0; i < timesCall; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(24 - timesCall, deck.CardsLeft);
        }

        // WARNING: test can return fake fail but change to happens depend of parameter
        // recommend parameter to be bigger then 3 (well if 3 times in a row made exac same decks probably something is wrong)
        // Another Warning: extremly high numberOfTimesChecked can slow dramatically the test
        [Test]
        [TestCase(4)]
        [TestCase(8)]
        public void DecksShouldBeShuffle(int numberOfTimesChecked)
        {
            bool IsSameDeck = true;


            for (int times = 0; times < numberOfTimesChecked; times++)
            {
                var deck1 = new Deck();
                var deck2 = new Deck();

                for (int i = 0; i < 24; i++)
                {
                    var card1 = deck1.GetNextCard();
                    var card2 = deck2.GetNextCard();
                    if (card1.Suit != card2.Suit || card1.Type != card2.Type)
                    {
                        IsSameDeck = false;
                    }
                }
            }

            Assert.IsFalse(IsSameDeck);
        }
    }
}
