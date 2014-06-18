﻿using System;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Races.Metaraces.Neutral
{
    [TestFixture]
    public class NeutralMonkMetaracesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "NeutralMonkMetaraces"; }
        }

        [Test]
        public void NeutralMonkEmptyPercentile()
        {
            AssertPercentile(EmptyContent, 1, 100);
        }
    }
}