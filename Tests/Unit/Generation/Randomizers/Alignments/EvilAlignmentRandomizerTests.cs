﻿using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Providers.Interfaces;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class EvilAlignmentRandomizerTests
    {
        private IEnumerable<Alignment> alignments;

        [SetUp]
        public void Setup()
        {
            var mockDice = new Mock<IDice>();
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetAllResults(It.IsAny<String>())).Returns(AlignmentConstants.GetGoodnesses());

            var randomizer = new EvilAlignmentRandomizer(mockDice.Object, mockPercentileResultProvider.Object);

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
        public void LawfulNeutralIsNotAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Lawful && a.Goodness == AlignmentConstants.Neutral), Is.False);
        }

        [Test]
        public void TrueNeutralIsNotAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Neutral && a.Goodness == AlignmentConstants.Neutral), Is.False);
        }

        [Test]
        public void ChaoticNeutralIsNotAllowed()
        {
            Assert.That(alignments.Any(a => a.Lawfulness == AlignmentConstants.Chaotic && a.Goodness == AlignmentConstants.Neutral), Is.False);
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