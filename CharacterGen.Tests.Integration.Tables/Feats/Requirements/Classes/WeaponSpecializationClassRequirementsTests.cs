﻿using CharacterGen.CharacterClasses;
using CharacterGen.Domain.Tables;
using CharacterGen.Feats;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Feats.Requirements.Classes
{
    [TestFixture]
    public class WeaponSpecializationClassRequirementsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.Formattable.Adjustments.FEATClassRequirements, FeatConstants.WeaponSpecialization);
            }
        }

        [Test]
        public override void CollectionNames()
        {
            var classes = new[] { CharacterClassConstants.Fighter };
            AssertCollectionNames(classes);
        }

        [TestCase(CharacterClassConstants.Fighter, 4)]
        public override void Adjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
