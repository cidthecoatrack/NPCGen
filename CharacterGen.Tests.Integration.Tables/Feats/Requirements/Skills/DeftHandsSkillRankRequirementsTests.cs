﻿using CharacterGen.Domain.Tables;
using CharacterGen.Feats;
using CharacterGen.Skills;
using NUnit.Framework;

namespace CharacterGen.Tests.Integration.Tables.Feats.Requirements.Skills
{
    [TestFixture]
    public class DeftHandsSkillRankRequirementsTests : AdjustmentsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Formattable.Adjustments.FEATSkillRankRequirements, FeatConstants.DeftHands); }
        }

        [Test]
        public override void CollectionNames()
        {
            var skills = new[] { SkillConstants.SleightOfHand, SkillConstants.UseRope };
            AssertCollectionNames(skills);
        }

        [TestCase(SkillConstants.SleightOfHand, 0)]
        [TestCase(SkillConstants.UseRope, 0)]
        public override void Adjustment(string name, int adjustment)
        {
            base.Adjustment(name, adjustment);
        }
    }
}
