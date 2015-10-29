﻿using CharacterGen.Common.Abilities.Stats;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Tables;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Stats
{
    [TestFixture]
    public class StatGroupsTests : CollectionTests
    {
        protected override String tableName
        {
            get
            {
                return TableNameConstants.Set.Collection.StatGroups;
            }
        }

        public override void CollectionNames()
        {
            var names = new[]
            {
                CharacterClassConstants.Bard + GroupConstants.Spellcasters,
                CharacterClassConstants.Cleric + GroupConstants.Spellcasters,
                CharacterClassConstants.Druid + GroupConstants.Spellcasters,
                CharacterClassConstants.Paladin + GroupConstants.Spellcasters,
                CharacterClassConstants.Ranger + GroupConstants.Spellcasters,
                CharacterClassConstants.Sorcerer + GroupConstants.Spellcasters,
                CharacterClassConstants.Wizard + GroupConstants.Spellcasters
            };

            AssertCollectionNames(names);
        }

        [TestCase(CharacterClassConstants.Bard + GroupConstants.Spellcasters, StatConstants.Charisma)]
        [TestCase(CharacterClassConstants.Cleric + GroupConstants.Spellcasters, StatConstants.Wisdom)]
        [TestCase(CharacterClassConstants.Druid + GroupConstants.Spellcasters, StatConstants.Wisdom)]
        [TestCase(CharacterClassConstants.Paladin + GroupConstants.Spellcasters, StatConstants.Wisdom)]
        [TestCase(CharacterClassConstants.Ranger + GroupConstants.Spellcasters, StatConstants.Wisdom)]
        [TestCase(CharacterClassConstants.Sorcerer + GroupConstants.Spellcasters, StatConstants.Charisma)]
        [TestCase(CharacterClassConstants.Wizard + GroupConstants.Spellcasters, StatConstants.Intelligence)]
        public override void DistinctCollection(String name, params String[] collection)
        {
            base.Collection(name, collection);
        }
    }
}