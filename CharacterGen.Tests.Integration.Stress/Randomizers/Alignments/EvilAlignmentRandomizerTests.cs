﻿using CharacterGen.Alignments;
using CharacterGen.Randomizers.Alignments;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Stress.Randomizers.Alignments
{
    [TestFixture]
    public class EvilAlignmentRandomizerTests : StressTests
    {
        [SetUp]
        public void Setup()
        {
            AlignmentRandomizer = GetNewInstanceOf<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Evil);
        }

        [Test]
        public void StressEvilAlignment()
        {
            stressor.Stress(AssertAlignment);
        }

        protected void AssertAlignment()
        {
            var alignment = AlignmentRandomizer.Randomize();
            Assert.That(alignment.Goodness, Is.EqualTo(AlignmentConstants.Evil));
            Assert.That(alignment.Lawfulness, Is.EqualTo(AlignmentConstants.Lawful)
                .Or.EqualTo(AlignmentConstants.Neutral)
                .Or.EqualTo(AlignmentConstants.Chaotic));
        }
    }
}