﻿using CharacterGen.Domain.Selectors.Selections;
using CharacterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGen.Domain.Selectors.Collections
{
    internal class FeatsSelector : IFeatsSelector
    {
        private ICollectionsSelector collectionsSelector;
        private IAdjustmentsSelector adjustmentsSelector;

        public FeatsSelector(ICollectionsSelector collectionsSelector, IAdjustmentsSelector adjustmentsSelector)
        {
            this.collectionsSelector = collectionsSelector;
            this.adjustmentsSelector = adjustmentsSelector;
        }

        public IEnumerable<RacialFeatSelection> SelectRacial(string race)
        {
            var racialFeats = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, race);
            var racialFeatSelections = new List<RacialFeatSelection>();

            foreach (var racialFeat in racialFeats)
            {
                var tableName = string.Format(TableNameConstants.Formattable.Collection.RACEFeatData, race);
                var featData = collectionsSelector.SelectFrom(tableName, racialFeat).ToArray();

                var racialFeatSelection = new RacialFeatSelection();
                racialFeatSelection.Feat = featData[DataIndexConstants.RacialFeatData.FeatNameIndex];
                racialFeatSelection.SizeRequirement = featData[DataIndexConstants.RacialFeatData.SizeRequirementIndex];
                racialFeatSelection.Power = Convert.ToInt32(featData[DataIndexConstants.RacialFeatData.PowerIndex]);
                racialFeatSelection.MinimumHitDieRequirement = Convert.ToInt32(featData[DataIndexConstants.RacialFeatData.MinimumHitDiceRequirementIndex]);
                racialFeatSelection.FocusType = featData[DataIndexConstants.RacialFeatData.FocusIndex];
                racialFeatSelection.Frequency.Quantity = Convert.ToInt32(featData[DataIndexConstants.RacialFeatData.FrequencyQuantityIndex]);
                racialFeatSelection.Frequency.TimePeriod = featData[DataIndexConstants.RacialFeatData.FrequencyTimePeriodIndex];
                racialFeatSelection.MaximumHitDieRequirement = Convert.ToInt32(featData[DataIndexConstants.RacialFeatData.MaximumHitDiceRequirementIndex]);

                var statNames = featData[DataIndexConstants.RacialFeatData.RequiredStatIndex].Split(',');
                var statValue = Convert.ToInt32(featData[DataIndexConstants.RacialFeatData.RequiredStatMinimumValueIndex]);

                if (string.IsNullOrEmpty(statNames[0]) == false)
                    for (var i = 0; i < statNames.Length; i++)
                        racialFeatSelection.MinimumStats[statNames[i]] = statValue;

                racialFeatSelections.Add(racialFeatSelection);
            }

            return racialFeatSelections;
        }

        public IEnumerable<AdditionalFeatSelection> SelectAdditional()
        {
            var additionalFeats = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.Additional);
            var additionalFeatSelections = new List<AdditionalFeatSelection>();

            foreach (var additionalFeat in additionalFeats)
            {
                var additionalFeatSelection = SelectAdditional(additionalFeat);
                additionalFeatSelections.Add(additionalFeatSelection);
            }

            return additionalFeatSelections;
        }

        private AdditionalFeatSelection SelectAdditional(string feat)
        {
            var additionalFeatSelection = new AdditionalFeatSelection();
            additionalFeatSelection.Feat = feat;

            var featData = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.AdditionalFeatData, feat).ToArray();
            additionalFeatSelection.RequiredBaseAttack = Convert.ToInt32(featData[DataIndexConstants.AdditionalFeatData.BaseAttackRequirementIndex]);
            additionalFeatSelection.FocusType = featData[DataIndexConstants.AdditionalFeatData.FocusTypeIndex];
            additionalFeatSelection.Frequency.Quantity = Convert.ToInt32(featData[DataIndexConstants.AdditionalFeatData.FrequencyQuantityIndex]);
            additionalFeatSelection.Frequency.TimePeriod = featData[DataIndexConstants.AdditionalFeatData.FrequencyTimePeriodIndex];
            additionalFeatSelection.Power = Convert.ToInt32(featData[DataIndexConstants.AdditionalFeatData.PowerIndex]);
            additionalFeatSelection.RequiredFeats = GetRequiredFeats(additionalFeatSelection.Feat);

            var featsWithClassRequirements = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.HasClassRequirements);
            if (featsWithClassRequirements.Contains(feat))
            {
                var tableName = string.Format(TableNameConstants.Formattable.Adjustments.FEATClassRequirements, feat);
                additionalFeatSelection.RequiredCharacterClasses = adjustmentsSelector.SelectFrom(tableName);
            }

            var featsWithSkillRequirements = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.HasSkillRequirements);
            if (featsWithSkillRequirements.Contains(feat))
            {
                var tableName = string.Format(TableNameConstants.Formattable.Adjustments.FEATSkillRankRequirements, feat);
                additionalFeatSelection.RequiredSkillRanks = adjustmentsSelector.SelectFrom(tableName);
            }

            var featWithStatRequirements = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.HasStatRequirements);
            if (featWithStatRequirements.Contains(feat))
            {
                var tableName = string.Format(TableNameConstants.Formattable.Adjustments.FEATStatRequirements, feat);
                additionalFeatSelection.RequiredStats = adjustmentsSelector.SelectFrom(tableName);
            }

            return additionalFeatSelection;
        }

        public IEnumerable<CharacterClassFeatSelection> SelectClass(string characterClassName)
        {
            var classFeats = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, characterClassName);
            var classFeatSelections = new List<CharacterClassFeatSelection>();

            foreach (var classFeat in classFeats)
            {
                var tableName = string.Format(TableNameConstants.Formattable.Collection.CLASSFeatData, characterClassName);
                var featData = collectionsSelector.SelectFrom(tableName, classFeat).ToArray();

                var classFeatSelection = new CharacterClassFeatSelection();
                classFeatSelection.Feat = featData[DataIndexConstants.CharacterClassFeatData.FeatNameIndex];
                classFeatSelection.FocusType = featData[DataIndexConstants.CharacterClassFeatData.FocusTypeIndex];
                classFeatSelection.Frequency.Quantity = Convert.ToInt32(featData[DataIndexConstants.CharacterClassFeatData.FrequencyQuantityIndex]);
                classFeatSelection.Frequency.TimePeriod = featData[DataIndexConstants.CharacterClassFeatData.FrequencyTimePeriodIndex];
                classFeatSelection.MinimumLevel = Convert.ToInt32(featData[DataIndexConstants.CharacterClassFeatData.MinimumLevelRequirementIndex]);
                classFeatSelection.Power = Convert.ToInt32(featData[DataIndexConstants.CharacterClassFeatData.PowerIndex]);
                classFeatSelection.MaximumLevel = Convert.ToInt32(featData[DataIndexConstants.CharacterClassFeatData.MaximumLevelRequirementIndex]);
                classFeatSelection.FrequencyQuantityStat = featData[DataIndexConstants.CharacterClassFeatData.FrequencyQuantityStatIndex];
                classFeatSelection.RequiredFeats = GetRequiredFeats(classFeat);
                classFeatSelection.SizeRequirement = featData[DataIndexConstants.CharacterClassFeatData.SizeRequirementIndex];
                classFeatSelection.AllowFocusOfAll = Convert.ToBoolean(featData[DataIndexConstants.CharacterClassFeatData.AllowFocusOfAllIndex]);

                classFeatSelections.Add(classFeatSelection);
            }

            return classFeatSelections;
        }

        private IEnumerable<RequiredFeatSelection> GetRequiredFeats(string feat)
        {
            var allRequiredFeats = collectionsSelector.SelectAllFrom(TableNameConstants.Set.Collection.RequiredFeats);
            var requiredFeats = new List<RequiredFeatSelection>();

            if (allRequiredFeats.ContainsKey(feat) == false)
                return requiredFeats;

            var requiredFeatsData = allRequiredFeats[feat];

            foreach (var requiredFeatData in requiredFeatsData)
            {
                var splitData = requiredFeatData.Split('/');
                var requiredFeat = new RequiredFeatSelection();
                requiredFeat.Feat = splitData[0];

                if (splitData.Length > 1)
                    requiredFeat.Focus = splitData[1];

                requiredFeats.Add(requiredFeat);
            }

            return requiredFeats;
        }
    }
}