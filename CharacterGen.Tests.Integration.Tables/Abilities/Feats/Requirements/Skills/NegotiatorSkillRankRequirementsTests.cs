﻿using CharacterGen.Abilities.Feats;
using CharacterGen.Abilities.Skills;
using CharacterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace CharacterGen.Tests.Integration.Tables.Abilities.Feats.Requirements.Skills
{
    [TestFixture]
    public class NegotiatorSkillRankRequirementsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.FEATSkillRankRequirements, FeatConstants.Negotiator); }
        }

        [Test]
        public override void CollectionNames()
        {
            var skills = new[] { SkillConstants.Diplomacy, SkillConstants.SenseMotive };
            AssertCollectionNames(skills);
        }

        [TestCase(SkillConstants.Diplomacy, 0)]
        [TestCase(SkillConstants.SenseMotive, 0)]
        public override void Adjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}