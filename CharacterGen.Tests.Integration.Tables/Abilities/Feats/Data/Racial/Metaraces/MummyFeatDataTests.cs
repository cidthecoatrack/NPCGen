﻿using CharacterGen.Abilities.Feats;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Data.Racial.Metaraces
{
    [TestFixture]
    public class MummyFeatDataTests : RacialFeatDataTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.Formattable.Collection.RACEFeatData, RaceConstants.Metaraces.Mummy);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                FeatConstants.NaturalArmor,
                FeatConstants.Despair,
                FeatConstants.MummyRot,
                FeatConstants.DamageReduction,
                FeatConstants.Darkvision,
                FeatConstants.VulnerabilityToEffect,
            };

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.NaturalArmor,
            FeatConstants.NaturalArmor,
            "",
            0,
            "",
            0,
            "",
            10, 0, 0)]
        [TestCase(FeatConstants.Despair,
            FeatConstants.Despair,
            "Save DC is 14 + CHA",
            0,
            "",
            0,
            "",
            0, 0, 0)]
        [TestCase(FeatConstants.MummyRot,
            FeatConstants.MummyRot,
            "Save DC is 14 + CHA",
            0,
            "",
            0,
            "",
            0, 0, 0)]
        [TestCase(FeatConstants.DamageReduction,
            FeatConstants.DamageReduction,
            "Nothing overcomes",
            1,
            FeatConstants.Frequencies.Hit,
            0,
            "",
            5, 0, 0)]
        [TestCase(FeatConstants.Darkvision,
            FeatConstants.Darkvision,
            "",
            0,
            "",
            0,
            "",
            60, 0, 0)]
        [TestCase(FeatConstants.VulnerabilityToEffect,
            FeatConstants.VulnerabilityToEffect,
            FeatConstants.Foci.Fire,
            0,
            "",
            0,
            "",
            0, 0, 0)]
        public override void RacialFeatData(string name, string feat, string focus, int frequencyQuantity, string frequencyTimePeriod, int minimumHitDiceRequirement, string sizeRequirement, int power, int maximumHitDiceRequirement, int requiredStatMinimumValue, params string[] minimumStats)
        {
            base.RacialFeatData(name, feat, focus, frequencyQuantity, frequencyTimePeriod, minimumHitDiceRequirement, sizeRequirement, power, maximumHitDiceRequirement, requiredStatMinimumValue, minimumStats);
        }
    }
}
