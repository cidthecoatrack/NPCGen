﻿using System;
using System.Collections.Generic;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Tests.Integration.Tables.Abilities.Feats.Data.Racial
{
    public abstract class RacialFeatDataTests : DataTests
    {
        protected override void PopulateIndices(IEnumerable<String> collection)
        {
            indices[DataIndexConstants.RacialFeatData.FeatIdIndex] = "FeatId";
            indices[DataIndexConstants.RacialFeatData.FocusIndex] = "FocusType";
            indices[DataIndexConstants.RacialFeatData.FrequencyQuantityIndex] = "FrequencyQuantity";
            indices[DataIndexConstants.RacialFeatData.FrequencyTimePeriodIndex] = "FrequencyTimePeriod";
            indices[DataIndexConstants.RacialFeatData.MinimumHitDiceRequirementIndex] = "MinHitDiceRequirement";
            indices[DataIndexConstants.RacialFeatData.SizeRequirementIndex] = "SizeRequirement";
            indices[DataIndexConstants.RacialFeatData.StrengthIndex] = "Strength";
        }

        public virtual void Data(String name, String featId, String focus, Int32 frequencyQuantity, String frequencyTimePeriod, Int32 minimumHitDiceRequirement, String sizeRequirement, Int32 strength)
        {
            var data = new List<String>();
            for (var i = 0; i < 7; i++)
                data.Add(String.Empty);

            data[DataIndexConstants.RacialFeatData.FeatIdIndex] = featId;
            data[DataIndexConstants.RacialFeatData.FocusIndex] = focus;
            data[DataIndexConstants.RacialFeatData.FrequencyQuantityIndex] = Convert.ToString(frequencyQuantity);
            data[DataIndexConstants.RacialFeatData.MinimumHitDiceRequirementIndex] = Convert.ToString(minimumHitDiceRequirement);
            data[DataIndexConstants.RacialFeatData.FrequencyTimePeriodIndex] = frequencyTimePeriod;
            data[DataIndexConstants.RacialFeatData.SizeRequirementIndex] = sizeRequirement;
            data[DataIndexConstants.RacialFeatData.StrengthIndex] = Convert.ToString(strength);

            Data(name, data);
        }
    }
}