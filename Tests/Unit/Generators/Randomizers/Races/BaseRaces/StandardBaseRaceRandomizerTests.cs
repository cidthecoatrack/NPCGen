﻿using CharacterGen.Generators.Domain.Randomizers.Races.BaseRaces;
using CharacterGen.Selectors;
using CharacterGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CharacterGen.Tests.Unit.Generators.Randomizers.Races.BaseRaces
{
    [TestFixture]
    public class StandardBaseRaceRandomizerTests : BaseRaceRandomizerTests
    {
        protected override IEnumerable<String> baseRaces
        {
            get { return new[] { "standard base race" }; }
        }

        private Mock<ICollectionsSelector> mockCollectionsSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            randomizer = new StandardBaseRaceRandomizer(mockPercentileResultSelector.Object, mockAdjustmentsSelector.Object,
                mockCollectionsSelector.Object, generator);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.BaseRaceGroups, GroupConstants.Standard))
                .Returns(new[] { "standard base race" });
        }

        [TestCase("standard base race")]
        public void Allowed(String baseRace)
        {
            var baseRaces = randomizer.GetAllPossible(alignment, characterClass);
            Assert.That(baseRaces, Contains.Item(baseRace));
        }

        [TestCase("nonstandard base race")]
        public void NotAllowed(String baseRace)
        {
            var baseRaces = randomizer.GetAllPossible(alignment, characterClass);
            Assert.That(baseRaces, Is.All.Not.EqualTo(baseRace));
        }
    }
}