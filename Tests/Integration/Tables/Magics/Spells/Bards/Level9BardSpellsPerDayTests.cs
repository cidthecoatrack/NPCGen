﻿using CharacterGen.Common.CharacterClasses;
using CharacterGen.Tables;
using NUnit.Framework;
using System;
using System.Linq;

namespace CharacterGen.Tests.Integration.Tables.Magics.Spells.Bards
{
    [TestFixture]
    public class Level9BardSpellsPerDayTests : AdjustmentsTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.Formattable.Adjustments.LevelXCLASSSpellsPerDay, 9, CharacterClassConstants.Bard);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = Enumerable.Range(0, 4).Select(i => i.ToString());
            AssertCollectionNames(names);
        }

        [TestCase(0, 3)]
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        public void Adjustment(Int32 spellLevel, Int32 quantity)
        {
            base.Adjustment(spellLevel.ToString(), quantity);
        }
    }
}