﻿using CharacterGen.Abilities;
using CharacterGen.Domain.Tables;
using CharacterGen.Races;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Races
{
    [TestFixture]
    public class VampireAbilityAdjustmentsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.RACEAbilityAdjustments, RaceConstants.Metaraces.Vampire); }
        }

        [Test]
        public override void CollectionNames()
        {
            var abilityGroups = CollectionsMapper.Map(TableNameConstants.Set.Collection.AbilityGroups);
            AssertCollectionNames(abilityGroups[GroupConstants.All]);
        }

        [TestCase(AbilityConstants.Charisma, 4)]
        [TestCase(AbilityConstants.Constitution, 0)]
        [TestCase(AbilityConstants.Dexterity, 4)]
        [TestCase(AbilityConstants.Intelligence, 2)]
        [TestCase(AbilityConstants.Strength, 6)]
        [TestCase(AbilityConstants.Wisdom, 2)]
        public void RacialAbilityAdjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
