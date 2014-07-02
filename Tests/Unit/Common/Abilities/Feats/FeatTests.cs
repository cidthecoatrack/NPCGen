﻿using NPCGen.Common.Feats;
using NUnit.Framework;

namespace NPCGen.Tests.Unit.Common.Feats
{
    [TestFixture]
    public class FeatTests
    {
        private Feat feat;

        [SetUp]
        public void Setup()
        {
            feat = new Feat();
        }

        [Test]
        public void FeatInitialized()
        {
            Assert.That(feat.Description, Is.Empty);
            Assert.That(feat.Name, Is.Empty);
        }
    }
}