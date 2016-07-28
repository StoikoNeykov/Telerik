namespace PokerTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Telerik.JustMock;

    using Poker;

    [TestFixture]
    public class HandTests
    {
        [Test]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(50)]
        public void HandToString_ShouldCallToStringofEveryOfCards(int numberOfCards)
        {
            int calls = 0;
            var collection = new List<ICard>();

            for (int i = 0; i < numberOfCards; i++)
            {
                var currentCard = Mock.Create<ICard>();
                Mock.Arrange(() => currentCard.ToString()).DoInstead(() => calls++);
                collection.Add(currentCard);
            }

            var hand = new Hand(collection);

            hand.ToString();

            Assert.AreEqual(numberOfCards, calls);
        }

        [Test]
        public void HandToString_ShouldReturnStringEmpty_WhenCollectionIsEmpty()
        {
            var collection = new List<ICard>();

            var hand = new Hand(collection);

            Assert.AreEqual(string.Empty, hand.ToString());
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void HandToString_ShouldReturnProperlySingleCardCollection(int numberOfCardsCheck)
        {
            var rng = new Random();
            var faces = Enum.GetValues(typeof(CardFace));
            var suits = Enum.GetValues(typeof(CardSuit));

            for (int i = 0; i < numberOfCardsCheck; i++)
            {
                var card = new Card((CardFace)faces.GetValue(rng.Next(faces.Length)),
                                        (CardSuit)suits.GetValue(rng.Next(suits.Length)));

                var collectiomn = new List<ICard> { card };
                var hand = new Hand(collectiomn);

                if (!card.ToString().Equals(hand.ToString()))
                {
                    Assert.Fail("Card hand do not display properly collection of single card!");
                }
            }
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(15)]
        public void HandToString_ShouldReturnProperlyMoreThenOneCardCOllection(int numberOfCards)
        {
            var rng = new Random();
            var faces = Enum.GetValues(typeof(CardFace));
            var suits = Enum.GetValues(typeof(CardSuit));

            string expectedResult = string.Empty;
            var collection = new List<ICard>();

            for (int i = 0; i < numberOfCards; i++)
            {
                var card = new Card((CardFace)faces.GetValue(rng.Next(faces.Length)),
                                        (CardSuit)suits.GetValue(rng.Next(suits.Length)));
                collection.Add(card);
                expectedResult += card.ToString() + ' ';
            }

            var hand = new Hand(collection);

            Assert.AreEqual(expectedResult.Trim(), hand.ToString());
        }
    }
}