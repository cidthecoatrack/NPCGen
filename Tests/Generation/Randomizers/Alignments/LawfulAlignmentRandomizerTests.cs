﻿using D20Dice.Dice;
using Moq;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class LawfulAlignmentRandomizerTests
    {
        private IAlignmentRandomizer alignmentRandomizer;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            alignmentRandomizer = new GoodAlignmentRandomizer(mockDice.Object);
        }

        [Test]
        public void ForcedLawful()
        {
            var alignment = alignmentRandomizer.Randomize();
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Lawful));
        }
    }
}