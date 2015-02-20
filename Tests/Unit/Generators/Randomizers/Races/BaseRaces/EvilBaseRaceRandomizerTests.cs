﻿using System;
using System.Collections.Generic;
using Moq;
using NPCGen.Common.Alignments;
using NPCGen.Generators.Randomizers.Races.BaseRaces;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.Races.BaseRaces
{
    [TestFixture]
    public class EvilBaseRaceRandomizerTests : BaseRaceRandomizerTests
    {
        protected override IEnumerable<String> baseRaces
        {
            get
            {
                return new[]
                {
                    "base race",
                    "good base race",
                    "neutral base race",
                    "evil base race",
                    "not good base race",
                    "not neutral base race",
                    "not evil base race"
                };
            }
        }

        private Mock<ICollectionsSelector> mockCollectionsSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            randomizer = new EvilBaseRaceRandomizer(mockPercentileResultSelector.Object, mockAdjustmentsSelector.Object,
                mockCollectionsSelector.Object);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.BaseRaceGroups, AlignmentConstants.Good)).Returns(new[] { "good base race", "base race", "not neutral base race", "not evil base race" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.BaseRaceGroups, AlignmentConstants.Evil)).Returns(new[] { "evil base race", "base race", "not good base race", "not neutral base race" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.BaseRaceGroups, AlignmentConstants.Neutral)).Returns(new[] { "neutral base race", "base race", "not evil base race", "not good base race" });
        }

        [TestCase("base race")]
        [TestCase("evil base race")]
        [TestCase("not neutral base race")]
        [TestCase("not good base race")]
        public void Allowed(String baseRace)
        {
            var baseRaces = randomizer.GetAllPossibleResults(String.Empty, characterClass);
            Assert.That(baseRaces, Contains.Item(baseRace));
        }

        [TestCase("good base race")]
        [TestCase("neutral base race")]
        [TestCase("not evil base race")]
        public void NotAllowed(String baseRace)
        {
            var baseRaces = randomizer.GetAllPossibleResults(String.Empty, characterClass);
            Assert.That(baseRaces, Is.Not.Contains(baseRace));
        }
    }
}