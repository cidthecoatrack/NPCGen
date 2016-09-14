﻿using CharacterGen.Abilities.Stats;
using CharacterGen.Randomizers.Stats;
using Ninject;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.Stats
{
    [TestFixture]
    public class OnesAsSixesStatsRandomizerTests : StressTests
    {
        [Inject, Named(StatsRandomizerTypeConstants.OnesAsSixes)]
        public IStatsRandomizer OnesAsSixesStatsRandomizer { get; set; }

        [Test]
        public void Stress()
        {
            Stress(AssertStats);
        }

        protected void AssertStats()
        {
            var stats = OnesAsSixesStatsRandomizer.Randomize();

            Assert.That(stats.Count, Is.EqualTo(6));
            Assert.That(stats.Keys, Contains.Item(StatConstants.Charisma));
            Assert.That(stats.Keys, Contains.Item(StatConstants.Constitution));
            Assert.That(stats.Keys, Contains.Item(StatConstants.Dexterity));
            Assert.That(stats.Keys, Contains.Item(StatConstants.Intelligence));
            Assert.That(stats.Keys, Contains.Item(StatConstants.Strength));
            Assert.That(stats.Keys, Contains.Item(StatConstants.Wisdom));
            Assert.That(stats[StatConstants.Charisma].Value, Is.InRange(6, 18));
            Assert.That(stats[StatConstants.Constitution].Value, Is.InRange(6, 18));
            Assert.That(stats[StatConstants.Dexterity].Value, Is.InRange(6, 18));
            Assert.That(stats[StatConstants.Intelligence].Value, Is.InRange(6, 18));
            Assert.That(stats[StatConstants.Strength].Value, Is.InRange(6, 18));
            Assert.That(stats[StatConstants.Wisdom].Value, Is.InRange(6, 18));

            Assert.That(stats.Count, Is.EqualTo(6));
        }

        [Test]
        public void NonDefaultStatsOccur()
        {
            var stats = GenerateOrFail(OnesAsSixesStatsRandomizer.Randomize, ss => ss.Values.Any(s => s.Value != 10));
            var allStatsAreDefault = stats.Values.All(s => s.Value == 10);
            Assert.That(allStatsAreDefault, Is.False);
        }
    }
}