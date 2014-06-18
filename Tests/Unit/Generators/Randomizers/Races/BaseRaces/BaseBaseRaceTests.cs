﻿using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NPCGen.Common.CharacterClasses;
using NPCGen.Generators.Interfaces.Verifiers.Exceptions;
using NPCGen.Generators.Randomizers.Races.BaseRaces;
using NPCGen.Selectors.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generators.Randomizers.Races.BaseRaces
{
    [TestFixture]
    public class BaseBaseRaceTests
    {
        private TestBaseRaceRandomizer randomizer;
        private Mock<IPercentileSelector> mockPercentileResultSelector;
        private Mock<ILevelAdjustmentsSelector> mockLevelAdjustmentsSelector;

        private String firstBaseRace = "first base race";
        private String secondBaseRace = "second base race";
        private CharacterClassPrototype prototype;
        private Dictionary<String, Int32> adjustments;

        [SetUp]
        public void Setup()
        {
            var baseRaces = new[] { firstBaseRace, secondBaseRace, String.Empty };
            mockPercentileResultSelector = new Mock<IPercentileSelector>();
            mockPercentileResultSelector.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(baseRaces);
            mockPercentileResultSelector.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns(firstBaseRace);

            adjustments = new Dictionary<String, Int32>();
            foreach(var baseRace in baseRaces)
                adjustments.Add(baseRace, 0);

            mockLevelAdjustmentsSelector = new Mock<ILevelAdjustmentsSelector>();
            mockLevelAdjustmentsSelector.Setup(p => p.GetLevelAdjustments()).Returns(adjustments);

            prototype = new CharacterClassPrototype();
            prototype.Level = 1;

            randomizer = new TestBaseRaceRandomizer(mockPercentileResultSelector.Object, mockLevelAdjustmentsSelector.Object);
        }

        [Test]
        public void RandomizeGetsAllPossibleResultsFromGetAllPossibleResults()
        {
            randomizer.Randomize(String.Empty, prototype);
            mockPercentileResultSelector.Verify(p => p.GetAllResults(It.IsAny<String>()), Times.Once);
        }

        [Test, ExpectedException(typeof(IncompatibleRandomizersException))]
        public void RandomizeThrowsErrorIfNoPossibleResults()
        {
            mockPercentileResultSelector.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(Enumerable.Empty<String>());
            randomizer.Randomize(String.Empty, prototype);
        }

        [Test]
        public void RandomizeReturnsBaseRaceFromPercentileResultSelector()
        {
            var result = randomizer.Randomize(String.Empty, prototype);
            Assert.That(result, Is.EqualTo(firstBaseRace));
        }

        [Test]
        public void RandomizeAccessesTableAlignmentGoodnessClassNameBaseRaces()
        {
            prototype.ClassName = "className";
            randomizer.Randomize("goodness", prototype);
            mockPercentileResultSelector.Verify(p => p.GetPercentileResult("goodnessclassNameBaseRaces"), Times.Once);
        }

        [Test]
        public void RandomizeLoopsUntilAllowedBaseRaceIsRolled()
        {
            mockPercentileResultSelector.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>())).Returns("invalid base race")
                .Returns(firstBaseRace);

            randomizer.Randomize(String.Empty, prototype);
            mockPercentileResultSelector.Verify(p => p.GetPercentileResult(It.IsAny<String>()), Times.Exactly(2));
        }

        [Test]
        public void GetAllPossibleResultsGetsResultsFromSelector()
        {
            randomizer.GetAllPossibleResults(String.Empty, prototype);
            mockPercentileResultSelector.Verify(p => p.GetAllResults(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void GetAllPossibleResultsFiltersOutEmptyStrings()
        {
            var classNames = randomizer.GetAllPossibleResults(String.Empty, prototype);
            Assert.That(classNames.Contains(firstBaseRace), Is.True);
            Assert.That(classNames.Contains(secondBaseRace), Is.True);
            Assert.That(classNames.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetAllPossibleResultsAccessesTableAlignmentGoodnessClassNameBaseRaces()
        {
            prototype.ClassName = "className";
            randomizer.GetAllPossibleResults("goodness", prototype);
            mockPercentileResultSelector.Verify(p => p.GetAllResults("goodnessclassNameBaseRaces"), Times.Once);
        }

        [Test]
        public void GetAllPossibleResultsFiltersOutUnallowedBaseRaces()
        {
            randomizer.NotAllowedBaseRace = firstBaseRace;

            var results = randomizer.GetAllPossibleResults(String.Empty, prototype);
            Assert.That(results.Contains(secondBaseRace), Is.True);
            Assert.That(results.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAllPossibleResultsFiltersOutBaseRacesWithTooHighLevelAdjustments()
        {
            adjustments[firstBaseRace] = 1;

            var results = randomizer.GetAllPossibleResults(String.Empty, prototype);
            Assert.That(results.Contains(secondBaseRace), Is.True);
            Assert.That(results.Count(), Is.EqualTo(1));
        }

        private class TestBaseRaceRandomizer : BaseBaseRace
        {
            public String NotAllowedBaseRace { get; set; }

            public TestBaseRaceRandomizer(IPercentileSelector percentileResultSelector, ILevelAdjustmentsSelector levelAdjustmentSelector)
                : base(percentileResultSelector, levelAdjustmentSelector) { }

            protected override Boolean BaseRaceIsAllowed(String baseRace)
            {
                return baseRace != NotAllowedBaseRace;
            }
        }
    }
}