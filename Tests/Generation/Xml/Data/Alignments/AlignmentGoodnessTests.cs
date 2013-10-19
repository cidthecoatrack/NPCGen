﻿using NPCGen.Core.Data.Alignments;
using NUnit.Framework;

namespace NPCGen.Tests.Generation.Xml.Data.Alignments
{
    [TestFixture]
    public class AlignmentGoodnessTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "AlignmentGoodness";
        }

        [Test]
        public void GoodPercentile()
        {
            AssertContent(AlignmentConstants.Good.ToString(), 1, 20);
        }

        [Test]
        public void NeutralPercentile()
        {
            AssertContent(AlignmentConstants.Neutral.ToString(), 21, 50);
        }

        [Test]
        public void EvilPercentile()
        {
            AssertContent(AlignmentConstants.Evil.ToString(), 51, 100);
        }
    }
}