﻿using System;
using NPCGen.Common.Abilities.Feats;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Feats
{
    [TestFixture]
    public class RequiredFeatsTests : CollectionTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Set.Collection.RequiredFeats; }
        }

        [TestCase(FeatConstants.ImprovedCombatStyleId,
            FeatConstants.CombatStyleId)]
        [TestCase(FeatConstants.CombatStyleMasteryId,
            FeatConstants.ImprovedCombatStyleId)]
        public override void DistinctCollection(String name, params String[] collection)
        {
            base.DistinctCollection(name, collection);
        }
    }
}
