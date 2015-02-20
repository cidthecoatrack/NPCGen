﻿using System;
using System.Collections.Generic;
using Ninject;
using NPCGen.Common.Alignments;
using NPCGen.Generators.Interfaces.Randomizers.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Stress.Randomizers.Alignments
{
    [TestFixture]
    public class NonGoodAlignmentRandomizerTests : StressTests
    {
        [Inject, Named(AlignmentRandomizerTypeConstants.NonGood)]
        public override IAlignmentRandomizer AlignmentRandomizer { get; set; }

        private IEnumerable<String> goodnesses;
        private IEnumerable<String> lawfulnesses;

        [SetUp]
        public void Setup()
        {
            goodnesses = AlignmentConstants.GetGoodnesses();
            lawfulnesses = AlignmentConstants.GetLawfulnesses();
        }

        [TestCase("NonGoodAlignmentRandomizer")]
        public override void Stress(String stressSubject)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var alignment = AlignmentRandomizer.Randomize();
            Assert.That(goodnesses, Contains.Item(alignment.Goodness));
            Assert.That(lawfulnesses, Contains.Item(alignment.Lawfulness));
            Assert.That(alignment.Goodness, Is.Not.EqualTo(AlignmentConstants.Good));
        }
    }
}