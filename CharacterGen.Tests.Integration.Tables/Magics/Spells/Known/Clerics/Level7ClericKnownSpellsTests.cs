﻿using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Magics.Spells.Known.Clerics
{
    [TestFixture]
    public class Level7ClericKnownSpellsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.Formattable.Adjustments.LevelXCLASSKnownSpells, 7, CharacterClassConstants.Cleric);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = Enumerable.Range(0, 5).Select(i => i.ToString());
            AssertCollectionNames(names);
        }

        [TestCase(0, 6)]
        [TestCase(1, 4)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        [TestCase(4, 1)]
        public void Adjustment(int spellLevel, int quantity)
        {
            base.Adjustment(spellLevel.ToString(), quantity);
        }
    }
}
