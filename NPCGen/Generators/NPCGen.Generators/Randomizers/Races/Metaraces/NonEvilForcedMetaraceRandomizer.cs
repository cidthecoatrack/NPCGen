﻿using System;
using System.Linq;
using NPCGen.Common.Alignments;
using NPCGen.Selectors.Interfaces;
using NPCGen.Tables.Interfaces;

namespace NPCGen.Generators.Randomizers.Races.Metaraces
{
    public class NonEvilForcedMetaraceRandomizer : BaseMetarace
    {
        protected override Boolean forceMetarace
        {
            get { return true; }
        }

        private ICollectionsSelector collectionsSelector;

        public NonEvilForcedMetaraceRandomizer(IPercentileSelector percentileResultSelector, IAdjustmentsSelector levelAdjustmentsSelector, ICollectionsSelector collectionsSelector)
            : base(percentileResultSelector, levelAdjustmentsSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        protected override Boolean MetaraceIsAllowed(String metarace)
        {
            var evilMetaraces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups,
                AlignmentConstants.Evil);
            var neutralMetaraces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups,
                AlignmentConstants.Neutral);
            var goodMetaraces = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups,
                AlignmentConstants.Good);
            var forbiddenMetaraces = evilMetaraces.Except(neutralMetaraces).Except(goodMetaraces);

            return !forbiddenMetaraces.Contains(metarace);
        }
    }
}