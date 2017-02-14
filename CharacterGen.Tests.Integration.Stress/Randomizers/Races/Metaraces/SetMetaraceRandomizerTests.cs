﻿using CharacterGen.Randomizers.Races;
using Ninject;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class SetMetaraceRandomizerTests : StressTests
    {
        [Inject]
        public ISetMetaraceRandomizer SetMetaraceRandomizer { get; set; }

        [SetUp]
        public void Setup()
        {
            var forcableMetaraceRandomizer = MetaraceRandomizer as IForcableMetaraceRandomizer;
            forcableMetaraceRandomizer.ForceMetarace = true;
        }

        [TearDown]
        public void TearDown()
        {
            MetaraceRandomizer = GetNewInstanceOf<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
        }

        [Test]
        public void StressSetMetarace()
        {
            Stress(AssertMetarace);
        }

        protected void AssertMetarace()
        {
            var alignment = GetNewAlignment();
            var characterClass = GetNewCharacterClass(alignment);
            SetMetaraceRandomizer.SetMetarace = MetaraceRandomizer.Randomize(alignment, characterClass);

            var metarace = SetMetaraceRandomizer.Randomize(alignment, characterClass);
            Assert.That(metarace, Is.EqualTo(SetMetaraceRandomizer.SetMetarace));
        }
    }
}