﻿using System;
using NPCGen.Common.Alignments;
using NPCGen.Common.CharacterClasses;
using NPCGen.Common.Races;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Races.BaseRaces.Evil
{
    [TestFixture]
    public class EvilDruidBaseRacesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Percentile.GOODNESSCLASSBaseRaces, AlignmentConstants.Evil, CharacterClassConstants.Druid); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(RaceConstants.BaseRaces.WoodElfId, 1, 2)]
        [TestCase(RaceConstants.BaseRaces.HalfOrcId, 5, 6)]
        [TestCase(RaceConstants.BaseRaces.HumanId, 7, 56)]
        [TestCase(RaceConstants.BaseRaces.LizardfolkId, 57, 71)]
        [TestCase(RaceConstants.BaseRaces.GnollId, 76, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(RaceConstants.BaseRaces.HalfElfId, 3)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalflingId, 4)]
        [TestCase(RaceConstants.BaseRaces.GoblinId, 72)]
        [TestCase(RaceConstants.BaseRaces.HobgoblinId, 73)]
        [TestCase(RaceConstants.BaseRaces.KoboldId, 74)]
        [TestCase(RaceConstants.BaseRaces.OrcId, 75)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}