﻿using CharacterGen.Domain.Selectors.Collections;
using CharacterGen.Domain.Selectors.Percentiles;
using CharacterGen.Domain.Tables;
using System.Linq;

namespace CharacterGen.Domain.Generators.Randomizers.Races.Metaraces
{
    internal class UndeadMetaraceRandomizer : ForcableMetaraceBase
    {
        public UndeadMetaraceRandomizer(IPercentileSelector percentileResultSelector, IAdjustmentsSelector adjustmentSelector, ICollectionsSelector collectionsSelector, Generator generator)
            : base(percentileResultSelector, adjustmentSelector, generator, collectionsSelector)
        { }

        protected override bool MetaraceIsAllowed(string metarace)
        {
            var metaraces = collectionSelector.SelectFrom(TableNameConstants.Set.Collection.MetaraceGroups, GroupConstants.Undead);
            return metaraces.Contains(metarace);
        }
    }
}
