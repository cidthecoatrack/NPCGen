﻿using System;
using Ninject;
using NPCGen.Common.Races;
using NPCGen.Generators.Interfaces.Randomizers.Races;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class NoMetaraceRandomizerTests : StressTests
    {
        [Inject, Named(MetaraceRandomizerTypeConstants.None)]
        public override IMetaraceRandomizer MetaraceRandomizer { get; set; }

        [TestCase("NoMetaraceRandomizer")]
        public override void Stress(String stressSubject)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var alignment = GetNewAlignment();
            var characterClass = GetNewCharacterClass(alignment);

            var metarace = MetaraceRandomizer.Randomize(alignment.Goodness, characterClass);
            Assert.That(metarace.Id, Is.EqualTo(RaceConstants.Metaraces.NoneId));
        }
    }
}