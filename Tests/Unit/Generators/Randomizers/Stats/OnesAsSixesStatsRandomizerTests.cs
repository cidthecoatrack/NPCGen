﻿using CharacterGen.Generators.Domain.Randomizers.Stats;
using CharacterGen.Generators.Randomizers.Stats;
using Moq;
using NUnit.Framework;
using RollGen;
using System.Linq;

namespace CharacterGen.Tests.Unit.Generators.Randomizers.Stats
{
    [TestFixture]
    public class OnesAsSixesStatsRandomizerTests
    {
        private IStatsRandomizer randomizer;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<Dice>();
            var generator = new ConfigurableIterationGenerator(2);
            randomizer = new OnesAsSixesStatsRandomizer(mockDice.Object, generator);

            mockDice.Setup(d => d.Roll(1).d6()).Returns(1);
        }

        [Test]
        public void OnesAsSixesStatsCalls1d6ThreeTimesPerStat()
        {
            var stats = randomizer.Randomize();
            mockDice.Verify(d => d.Roll(1).d6(), Times.Exactly(stats.Count * 3));
        }

        [Test]
        public void OnesAsSixesTreatsOnesAsSixes()
        {
            mockDice.SetupSequence(d => d.Roll(1).d6()).Returns(1).Returns(2).Returns(3);

            var stats = randomizer.Randomize();
            var stat = stats.Values.First();
            Assert.That(stat.Value, Is.EqualTo(11));
        }
    }
}