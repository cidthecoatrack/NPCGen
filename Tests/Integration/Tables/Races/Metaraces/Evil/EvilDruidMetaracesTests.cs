﻿using System;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Races.Metaraces.Evil
{
    [TestFixture]
    public class EvilDruidMetaracesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "EvilDruidMetaraces"; }
        }

        [Test]
        public void EvilDruidEmptyPercentile()
        {
            AssertPercentile(EmptyContent, 1, 100);
        }
    }
}