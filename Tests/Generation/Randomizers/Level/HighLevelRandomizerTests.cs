﻿using D20Dice.Dice;
using Moq;
using NPCGen.Core.Generation.Randomizers.Level;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Level
{
    [TestFixture]
    public class HighLevelRandomizerTests
    {
        [Test]
        public void AddTenToRoll()
        {
            var mockDice = new Mock<IDice>();
            var randomizer = new HighLevelRandomizer(mockDice.Object);

            mockDice.Setup(d => d.d6(1, 0)).Returns(1);
            var level = randomizer.Randomize();
            Assert.That(level, Is.EqualTo(11));
        }
    }
}