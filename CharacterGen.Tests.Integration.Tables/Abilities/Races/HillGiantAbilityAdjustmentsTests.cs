﻿using CharacterGen.Abilities;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Races
{
    [TestFixture]
    public class HillGiantAbilityAdjustmentsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.RACEAbilityAdjustments, RaceConstants.BaseRaces.HillGiant); }
        }

        [Test]
        public override void CollectionNames()
        {
            var abilityGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.AbilityGroups);
            AssertCollectionNames(abilityGroups[GroupConstants.All]);
        }

        [TestCase(AbilityConstants.Charisma, -4)]
        [TestCase(AbilityConstants.Constitution, 8)]
        [TestCase(AbilityConstants.Dexterity, -2)]
        [TestCase(AbilityConstants.Intelligence, -4)]
        [TestCase(AbilityConstants.Strength, 14)]
        [TestCase(AbilityConstants.Wisdom, -4)]
        public void RacialAbilityAdjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
