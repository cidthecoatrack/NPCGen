﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class NonGoodAlignmentRandomizerTests
    {
        private IEnumerable<Alignment> alignments;

        [SetUp]
        public void Setup()
        {
            var mockDice = new Mock<IDice>();
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(AlignmentConstants.GetGoodnesses());

            var randomizer = new NonGoodAlignmentRandomizer(mockDice.Object, mockPercentileResultProvider.Object);

            alignments = randomizer.GetAllPossibleResults();
        }

        [Test]
        public void LawfulGoodIsNotAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Lawful && a.Goodness == AlignmentConstants.Good), Is.False);
        }

        [Test]
        public void NeutralGoodIsNotAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Neutral && a.Goodness == AlignmentConstants.Good), Is.False);
        }

        [Test]
        public void ChaoticGoodIsNotAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Chaotic && a.Goodness == AlignmentConstants.Good), Is.False);
        }

        [Test]
        public void LawfulNeutralIsAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Lawful && a.Goodness == AlignmentConstants.Neutral), Is.True);
        }

        [Test]
        public void TrueNeutralIsAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Neutral && a.Goodness == AlignmentConstants.Neutral), Is.True);
        }

        [Test]
        public void ChaoticNeutralIsAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Chaotic && a.Goodness == AlignmentConstants.Neutral), Is.True);
        }

        [Test]
        public void LawfulEvilIsAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Lawful && a.Goodness == AlignmentConstants.Evil), Is.True);
        }

        [Test]
        public void NeutralEvilIsAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Neutral && a.Goodness == AlignmentConstants.Evil), Is.True);
        }

        [Test]
        public void ChaoticEvilIsAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Chaotic && a.Goodness == AlignmentConstants.Evil), Is.True);
        }
    }
}