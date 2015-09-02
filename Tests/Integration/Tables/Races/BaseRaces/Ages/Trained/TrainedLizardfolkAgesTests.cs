﻿using CharacterGen.Common.Races;
using CharacterGen.Tables;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Integration.Tables.Races.BaseRaces.Ages.Trained
{
    [TestFixture]
    public class TrainedLizardfolkAgesTests : AdjustmentsTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Adjustments.AGEGROUPRACEAges, GroupConstants.Trained, RaceConstants.BaseRaces.Lizardfolk); }
        }

        [Test]
        public override void CollectionNames()
        {
            var names = new[]
            {
                AdjustmentConstants.Adulthood,
                AdjustmentConstants.Quantity,
                AdjustmentConstants.Die,
                AdjustmentConstants.MiddleAge,
                AdjustmentConstants.Old,
                AdjustmentConstants.Venerable
            };

            AssertCollectionNames(names);
        }

        [TestCase(AdjustmentConstants.Adulthood, 10)]
        [TestCase(AdjustmentConstants.Quantity, 1)]
        [TestCase(AdjustmentConstants.Die, 10)]
        [TestCase(AdjustmentConstants.MiddleAge, 30)]
        [TestCase(AdjustmentConstants.Old, 50)]
        [TestCase(AdjustmentConstants.Venerable, 65)]
        public override void Adjustment(String name, Int32 adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
