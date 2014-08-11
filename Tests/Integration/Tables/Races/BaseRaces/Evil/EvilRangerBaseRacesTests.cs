﻿using System;
using NPCGen.Common.Races;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Races.BaseRaces.Evil
{
    [TestFixture]
    public class EvilRangerBaseRacesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "EvilRangerBaseRaces"; }
        }

        [TestCase(RaceConstants.BaseRaces.HighElf, 1)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, 29)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, 30)]
        [TestCase(RaceConstants.BaseRaces.Hobgoblin, 72)]
        [TestCase(RaceConstants.BaseRaces.Troglodyte, 93)]
        [TestCase(RaceConstants.BaseRaces.Bugbear, 94)]
        [TestCase(RaceConstants.BaseRaces.Ogre, 95)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }

        [TestCase(RaceConstants.BaseRaces.WoodElf, 2, 11)]
        [TestCase(RaceConstants.BaseRaces.HalfElf, 12, 28)]
        [TestCase(RaceConstants.BaseRaces.HalfOrc, 31, 39)]
        [TestCase(RaceConstants.BaseRaces.Human, 40, 69)]
        [TestCase(RaceConstants.BaseRaces.Lizardfolk, 70, 71)]
        [TestCase(RaceConstants.BaseRaces.Gnoll, 73, 92)]
        [TestCase(EmptyContent, 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}