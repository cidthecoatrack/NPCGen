﻿using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Magics.Spells.Known.Bards
{
    [TestFixture]
    public class Level20BardKnownSpellsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.Formattable.Adjustments.LevelXCLASSKnownSpells, 20, CharacterClassConstants.Bard);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = Enumerable.Range(0, 7).Select(i => i.ToString());
            AssertCollectionNames(names);
        }

        [TestCase(0, 6)]
        [TestCase(1, 5)]
        [TestCase(2, 5)]
        [TestCase(3, 5)]
        [TestCase(4, 5)]
        [TestCase(5, 5)]
        [TestCase(6, 4)]
        public void Adjustment(int spellLevel, int quantity)
        {
            base.Adjustment(spellLevel.ToString(), quantity);
        }
    }
}
