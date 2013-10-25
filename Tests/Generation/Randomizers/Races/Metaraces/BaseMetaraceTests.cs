﻿using System;
using System.Linq;
using Moq;
using NPCGen.Core.Data.CharacterClasses;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Randomizers.Races.Metaraces;
using NPCGen.Core.Generation.Verifiers.Exceptions;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Races.Metaraces
{
    [TestFixture]
    public class BaseMetaraceTests
    {
        private TestMetaraceRandomizer randomizer;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;

        private String firstMetarace = "first metarace";
        private String secondMetarace = "second metarace";

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(new[] { firstMetarace, secondMetarace, String.Empty });
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns(firstMetarace);

            randomizer = new TestMetaraceRandomizer(mockPercentileResultProvider.Object);
        }

        [Test]
        public void RandomizeGetsAllPossibleResultsFromGetAllPossibleResults()
        {
            randomizer.Randomize(String.Empty, new CharacterClass());
            mockPercentileResultProvider.Verify(p => p.GetAllResults(It.IsAny<String>()), Times.Once);
        }

        [Test, ExpectedException(typeof(IncompatibleRandomizersException))]
        public void RandomizeThrowsErrorIfNoPossibleResults()
        {
            mockPercentileResultProvider.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(Enumerable.Empty<String>());
            randomizer.Randomize(String.Empty, new CharacterClass());
        }

        [Test]
        public void RandomizeReturnsBaseRaceFromPercentileResultProvider()
        {
            var result = randomizer.Randomize(String.Empty, new CharacterClass());
            Assert.That(result, Is.EqualTo(firstMetarace));
        }

        [Test]
        public void RandomizeAccessesTableAlignmentGoodnessClassNameBaseRaces()
        {
            randomizer.Randomize("goodness", new CharacterClass() { ClassName = "className" });
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("goodnessclassNameMetaraces"), Times.Once);
        }

        [Test]
        public void RandomizeLoopsUntilAllowedBaseRaceIsRolled()
        {
            mockPercentileResultProvider.SetupSequence(p => p.GetPercentileResult(It.IsAny<String>())).Returns("invalid metarace")
                .Returns(firstMetarace);

            randomizer.Randomize(String.Empty, new CharacterClass());
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult(It.IsAny<String>()), Times.Exactly(2));
        }

        [Test]
        public void GetAllPossibleResultsGetsResultsFromProvider()
        {
            randomizer.GetAllPossibleResults(String.Empty, new CharacterClass());
            mockPercentileResultProvider.Verify(p => p.GetAllResults(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void GetAllPossibleResultsGetsNonEmptyResults()
        {
            var classNames = randomizer.GetAllPossibleResults(String.Empty, new CharacterClass());

            Assert.That(classNames.Contains(firstMetarace), Is.True);
            Assert.That(classNames.Contains(secondMetarace), Is.True);
        }

        [Test]
        public void GetAllPossibleResultsAccessesTableAlignmentGoodnessClassNameBaseRaces()
        {
            randomizer.GetAllPossibleResults("goodness", new CharacterClass() { ClassName = "className" });
            mockPercentileResultProvider.Verify(p => p.GetAllResults("goodnessclassNameMetaraces"), Times.Once);
        }

        [Test]
        public void GetAllPossibleResultsFiltersOutUnallowedBaseRaces()
        {
            randomizer.NotAllowedMetarace = firstMetarace;
            var results = randomizer.GetAllPossibleResults(String.Empty, new CharacterClass());

            Assert.That(results.Contains(secondMetarace), Is.True);
        }

        [Test]
        public void IfAllowNoMetaraceIsTrueThenEmptyMetaraceIsAllowed()
        {
            randomizer.AllowNoMetarace = true;

            var results = randomizer.GetAllPossibleResults(String.Empty, new CharacterClass());
            Assert.That(results.Contains(String.Empty), Is.True);
        }

        [Test]
        public void IfAllowNoMetaraceIsFalseThenEmptyMetaraceIsNotAllowed()
        {
            randomizer.AllowNoMetarace = false;

            var results = randomizer.GetAllPossibleResults(String.Empty, new CharacterClass());
            Assert.That(results.Contains(String.Empty), Is.False);
        }

        private class TestMetaraceRandomizer : BaseMetarace
        {
            public String NotAllowedMetarace { get; set; }

            public TestMetaraceRandomizer(IPercentileResultProvider percentileResultProvider)
                : base(percentileResultProvider) { }

            protected override Boolean MetaraceIsAllowed(String metarace)
            {
                return metarace != NotAllowedMetarace;
            }
        }
    }
}