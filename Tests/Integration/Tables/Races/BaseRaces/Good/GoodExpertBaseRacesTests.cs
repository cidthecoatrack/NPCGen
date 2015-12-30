﻿using CharacterGen.Common.Alignments;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Common.Races;
using CharacterGen.Tables;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Good
{
    [TestFixture]
    public class GoodExpertBaseRacesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Percentile.GOODNESSCLASSBaseRaces, AlignmentConstants.Good, CharacterClassConstants.Expert); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(RaceConstants.BaseRaces.Aasimar, 1)]
        [TestCase(RaceConstants.BaseRaces.WildElf, 37)]
        [TestCase(RaceConstants.BaseRaces.WoodElf, 38)]
        [TestCase(RaceConstants.BaseRaces.ForestGnome, 39)]
        [TestCase(RaceConstants.BaseRaces.LightfootHalfling, 54)]
        [TestCase(RaceConstants.BaseRaces.DeepHalfling, 55)]
        [TestCase(RaceConstants.BaseRaces.Svirfneblin, 98)]
        public override void Percentile(string content, int roll)
        {
            base.Percentile(content, roll);
        }

        [TestCase(RaceConstants.BaseRaces.HillDwarf, 2, 6)]
        [TestCase(RaceConstants.BaseRaces.GrayElf, 7, 11)]
        [TestCase(RaceConstants.BaseRaces.HighElf, 12, 36)]
        [TestCase(RaceConstants.BaseRaces.RockGnome, 40, 44)]
        [TestCase(RaceConstants.BaseRaces.HalfElf, 45, 53)]
        [TestCase(RaceConstants.BaseRaces.TallfellowHalfling, 56, 57)]
        [TestCase(RaceConstants.BaseRaces.Human, 58, 97)]
        [TestCase(EmptyContent, 99, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}