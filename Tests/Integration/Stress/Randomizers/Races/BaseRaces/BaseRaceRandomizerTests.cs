﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress.Randomizers.Races.BaseRaces
{
    [TestFixture]
    public abstract class BaseRaceRandomizerTests : StressTests
    {
        protected abstract IEnumerable<String> allowedBaseRaces { get; }

        private IEnumerable<String> baseRaces;

        [SetUp]
        public void Setup()
        {
            baseRaces = allowedBaseRaces;
        }

        protected override void MakeAssertions()
        {
            var alignment = GetNewAlignment();
            var prototype = GetNewCharacterClassPrototype(alignment);

            var baseRace = BaseRaceRandomizer.Randomize(alignment.Goodness, prototype);
            Assert.That(baseRaces, Contains.Item(baseRace));
        }
    }
}