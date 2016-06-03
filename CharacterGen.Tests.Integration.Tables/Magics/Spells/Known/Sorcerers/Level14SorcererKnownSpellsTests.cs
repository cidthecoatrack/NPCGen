﻿using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Magics.Spells.Known.Sorcerers
{
    [TestFixture]
    public class Level14SorcererKnownSpellsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.Formattable.Adjustments.LevelXCLASSKnownSpells, 14, CharacterClassConstants.Sorcerer);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = Enumerable.Range(0, 8).Select(i => i.ToString());
            AssertCollectionNames(names);
        }

        [TestCase(0, 9)]
        [TestCase(1, 5)]
        [TestCase(2, 5)]
        [TestCase(3, 4)]
        [TestCase(4, 4)]
        [TestCase(5, 3)]
        [TestCase(6, 2)]
        [TestCase(7, 1)]
        public void Adjustment(int spellLevel, int quantity)
        {
            base.Adjustment(spellLevel.ToString(), quantity);
        }
    }
}
