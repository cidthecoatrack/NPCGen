﻿using CharacterGen.Abilities;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Races
{
    [TestFixture]
    public class MindFlayerAbilityAdjustmentsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.RACEAbilityAdjustments, RaceConstants.BaseRaces.MindFlayer); }
        }

        [Test]
        public override void CollectionNames()
        {
            var abilityGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.AbilityGroups);
            AssertCollectionNames(abilityGroups[GroupConstants.All]);
        }

        [TestCase(AbilityConstants.Charisma, 6)]
        [TestCase(AbilityConstants.Constitution, 2)]
        [TestCase(AbilityConstants.Dexterity, 4)]
        [TestCase(AbilityConstants.Intelligence, 8)]
        [TestCase(AbilityConstants.Strength, 2)]
        [TestCase(AbilityConstants.Wisdom, 6)]
        public void RacialAbilityAdjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
