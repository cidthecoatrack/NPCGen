﻿using CharacterGen.Races;
using CharacterGen.Domain.Tables;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Ages
{
    [TestFixture]
    public class MerrowAgesTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.RACEAges, RaceConstants.BaseRaces.Merrow); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                RaceConstants.Ages.Adulthood,
                RaceConstants.Ages.MiddleAge,
                RaceConstants.Ages.Old,
                RaceConstants.Ages.Venerable
            };

            AssertCollectionNames(names);
        }

        [TestCase(RaceConstants.Ages.Adulthood, 30)]
        [TestCase(RaceConstants.Ages.MiddleAge, 60)]
        [TestCase(RaceConstants.Ages.Old, 80)]
        [TestCase(RaceConstants.Ages.Venerable, 120)]
        public void Age(string ageDescription, int age)
        {
            base.Adjustment(ageDescription, age);
        }
    }
}
