﻿using System;
using NPCGen.Common.Races;
using NPCGen.Tables.Interfaces;
using NUnit.Framework;

namespace NPCGen.Tests.Integration.Tables.Abilities.Skills.RacialAdjustments
{
    [TestFixture]
    public class OrcSkillAdjustmentsTests : AdjustmentsTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Formattable.Adjustments.BASERACESkillAdjustments, RaceConstants.BaseRaces.OrcId); }
        }

        [Test]
        public override void NoAdjustments()
        {
            base.NoAdjustments();
        }
    }
}