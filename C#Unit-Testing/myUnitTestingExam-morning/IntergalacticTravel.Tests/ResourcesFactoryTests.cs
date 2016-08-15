namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;

    using IntergalacticTravel;

    [TestFixture]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(25) silver(35) bronze(45)")]
        [TestCase("create resources gold(25) bronze(45) silver(35)")]
        [TestCase("create resources silver(35) bronze(45) gold(25)")]
        [TestCase("create resources silver(35) gold(25) bronze(45)")]
        [TestCase("create resources bronze(45) gold(25) silver(35)")]
        [TestCase("create resources bronze(45) silver(35) gold(25)")]
        public void GetResources_ShouldReturnInstanceOfResurceWithProperlySetProperties_IfPassedInCreationStringIsValidNoMatterOfOrder(string validCreationString)
        {
            var factory = new ResourcesFactory();

            var result = factory.GetResources(validCreationString);

            Assert.IsInstanceOf<Resources>(result);
            Assert.AreEqual(25, result.GoldCoins);
            Assert.AreEqual(35, result.SilverCoins);
            Assert.AreEqual(45, result.BronzeCoins);
        }

        [TestCase("can you imagine that string to pass that method and actually create anything?")]
        [TestCase("create cookies for Xmas")]
        public void GetResources_ShouldThrowInvalidOperationException_WhenCalledWithInvalidCommand(string invalidString)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<InvalidOperationException>(() => factory.GetResources(invalidString));
        }

        [TestCase("create resources bronze(45) silver(3533333333333333333331232132132131231) gold(25)")]
        [TestCase("create resources gold(292379283321321315) bronze(45) silver(329837129732932132183072983015)")]
        public void GetResources_ShouldThrowOverflowException_WhenInputIsInValidFormatButContainsValiesBiggerThenUIntMaxValue(string stringWithBigNumbers)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => factory.GetResources(stringWithBigNumbers));
        }
    }
}