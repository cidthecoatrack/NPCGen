﻿using System.Linq;
using Ninject;
using NPCGen.Core.Data.Alignments;
using NPCGen.Core.Generation.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Generation.Randomizers.Alignments
{
    [TestFixture]
    public class LawfulAlignmentRandomizerTests : IntegrationTest
    {
        [Inject]
        public LawfulAlignmentRandomizer AlignmentRandomizer { get; set; }

        [Test]
        public void LawfulAlignmentRandomizerReturnsAlignment()
        {
            for (var i = 0; i < ConfidenceLevel; i++)
            {
                var alignment = AlignmentRandomizer.Randomize();
                Assert.That(alignment, Is.Not.Null);
            }
        }

        [Test]
        public void LawfulAlignmentRandomizerReturnsAlignmentWithGoodness()
        {
            var goodnesses = AlignmentConstants.GetGoodnesses();

            for (var i = 0; i < ConfidenceLevel; i++)
            {
                var alignment = AlignmentRandomizer.Randomize();
                Assert.That(goodnesses.Contains(alignment.Goodness), Is.True);
            }
        }

        [Test]
        public void LawfulAlignmentRandomizerReturnsAlignmentWithLawfulness()
        {
            var lawfulnesses = AlignmentConstants.GetLawfulnesses();

            for (var i = 0; i < ConfidenceLevel; i++)
            {
                var alignment = AlignmentRandomizer.Randomize();
                Assert.That(lawfulnesses.Contains(alignment.Lawfulness), Is.True);
            }
        }

        [Test]
        public void LawfulAlignmentRandomizerAlwaysReturnsLawfulAlignment()
        {
            for (var i = 0; i < ConfidenceLevel; i++)
            {
                var alignment = AlignmentRandomizer.Randomize();
                Assert.That(alignment.IsLawful(), Is.True);
            }
        }
    }
}